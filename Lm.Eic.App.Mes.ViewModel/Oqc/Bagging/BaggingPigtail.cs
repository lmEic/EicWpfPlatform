using Lm.Eic.App.Mes.Business;
using System.Collections.Generic;

namespace Lm.Eic.App.Mes.ViewModel.Oqc.Bagging
{
    /// <summary>
    /// 装袋检测 Pigtail检测
    /// </summary>
    public class BaggingPigtail : BaggingBase, IBaggingBase
    {
        public override InspectResult Inspect(string barcode)
        {
            //条码是否属于此工单
            if (!IsSnForOrder(barcode))
            {
                Result = false;
            }
            else
            {
                //取得测试数据
                User3DTestGoodList = new Orm<Model.User_3D_Test_Good>.ModelList_obs(Business.Operation.OqcHelper.UserTest3D.GetModelList(m => m.SN.StartsWith(barcode)));
                UserExfoTestGoodList = new Orm<Model.User_JDS_Test_Good>.ModelList_obs(Business.Operation.OqcHelper.UserTestExfo.GetModelList(m => m.SN.StartsWith(barcode)));
                if (IsAccordInspectStandard())
                {
                    IBtPrint.ExfoDataList.Add(UserExfoTestGoodList?[0]);
                    SavaDataToDb(serialNumber:barcode);
                    InsertDataToExcel();
                    Result = true;
                }
                else { Result = false; }
            }
            MyTask.Execute("Barcode获取焦点");
            return InspectResult;
        }

        public void InsertDataToExcel()
        {
            var dataSourcsPath = OrderSet.PrintSet.BtPrintConfig.Detailed.DataSourcesPath;
            ZhuiFengLib.OfficeHelper.ExcelHelper excelHelper = new ZhuiFengLib.OfficeHelper.ExcelHelper(dataSourcsPath);
            var ParList = new List<ZhuiFengLib.OfficeHelper.InsertExcelParameter>();

            //设置标签其他内容
            foreach (var labContent in OrderSet.PrintSet.LabContentList)
                ParList.Add(new ZhuiFengLib.OfficeHelper.InsertExcelParameter() { Type = labContent.Name, Paramenter = labContent.Value });

            var exfo = UserExfoTestGoodList[0];
            ParList.Add(new ZhuiFengLib.OfficeHelper.InsertExcelParameter() { Type = "SN_1", Paramenter = exfo.SN });
            ParList.Add(new ZhuiFengLib.OfficeHelper.InsertExcelParameter() { Type = "IL_1", Paramenter = exfo.IL_A });
            ParList.Add(new ZhuiFengLib.OfficeHelper.InsertExcelParameter() { Type = "RL_1", Paramenter = exfo.Refl_A });
            excelHelper.InsertRow(ParList);

           
        }
    }
}