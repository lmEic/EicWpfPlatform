using Lm.Eic.App.Mes.Business;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Lm.Eic.App.Mes.ViewModel.Oqc.Bagging
{
    /// <summary>
    /// 双并检测与打印
    /// </summary>
    internal class BaggingTwin : BaggingBase, IBaggingBase
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
                User3DTestGoodList = new Orm<Model.User_3D_Test_Good>.ModelList_obs(Operation.OqcHelper.UserTest3D.GetModelList(m => m.SN.StartsWith(barcode)));
                UserExfoTestGoodList = new Orm<Model.User_JDS_Test_Good>.ModelList_obs(Operation.OqcHelper.UserTestExfo.GetModelList(m => m.SN.StartsWith(barcode)));
                if (IsAccordInspectStandard())
                {
                   // IBtPrint.ExfoDataList.Add(UserExfoTestGoodList?[0]);
                    // SavaDataToDb(barcode);
                   // InsertDataToExcel();
                    Result = true;
                }
                else { Result = false; }
            }
            MyTask.Execute("Barcode获取焦点");
            return InspectResult;
        }

      

        /// <summary>
        /// 插入数据到模板
        /// </summary>
        public void InsertDataToExcel()
        {
            if (UserExfoTestGoodList.Count == 2)
            {

                var dataSourcsPath = OrderSet.PrintSet.BtPrintConfig.Detailed.DataSourcesPath;
                ZhuiFengLib.OfficeHelper.ExcelHelper excelHelper = new ZhuiFengLib.OfficeHelper.ExcelHelper(dataSourcsPath);
                var ParList = new List<ZhuiFengLib.OfficeHelper.InsertExcelParameter>();

                //设置标签其他内容
                foreach (var labContent in OrderSet.PrintSet.LabContentList)
                    ParList.Add(new ZhuiFengLib.OfficeHelper.InsertExcelParameter() { Type = labContent.Name, Paramenter = labContent.Value });

                //设置数据
                var exfoOne = UserExfoTestGoodList[0];
                var exfoTwo = UserExfoTestGoodList[1];
                ParList.Add(new ZhuiFengLib.OfficeHelper.InsertExcelParameter() { Type = "SN_1", Paramenter = exfoOne.SN });
                ParList.Add(new ZhuiFengLib.OfficeHelper.InsertExcelParameter() { Type = "IL_1", Paramenter = exfoOne.IL_A });
                ParList.Add(new ZhuiFengLib.OfficeHelper.InsertExcelParameter() { Type = "RL_1", Paramenter = exfoOne.Refl_A });
                ParList.Add(new ZhuiFengLib.OfficeHelper.InsertExcelParameter() { Type = "SN_2", Paramenter = exfoTwo.SN });
                ParList.Add(new ZhuiFengLib.OfficeHelper.InsertExcelParameter() { Type = "IL_2", Paramenter = exfoTwo.IL_A });
                ParList.Add(new ZhuiFengLib.OfficeHelper.InsertExcelParameter() { Type = "RL_2", Paramenter = exfoTwo.Refl_A });
                excelHelper.InsertRow(ParList);
            }
        }


        /// <summary>
        /// 保存测试数据到数据库
        /// </summary>
        /// <returns></returns>
        public override bool SavaDataToDb(string serialNumber)
        {
            //后台存储
            Thread t = new Thread(() =>
            {
                foreach (var user3D in User3DTestGoodList)
                    Operation.OqcHelper.Pack3D.Add(user3D, user3D.SN, OrderSet.PackLotSet.SelectPackLot);
                foreach (var exfo in UserExfoTestGoodList)
                {
                    Operation.OqcHelper.PackExfo.Add(exfo, exfo.SN, OrderSet.PackLotSet.SelectPackLot);
                    var serialnumber = OrderSet.SerialNumberSet.SnList.FirstOrDefault(m => m.SN == exfo.SN);
                    if (serialnumber != null)
                    {
                        serialnumber.IsPack = true;
                        serialnumber.PackLot = OrderSet.PackLotSet.SelectPackLot.Detailed.PackLot;
                        Operation.OqcHelper.SerialNumber.Update(serialnumber);
                    }
                }

                User3DTestGoodList.Clear();
                UserExfoTestGoodList.Clear();
            });
            //  t.IsBackground = true;
            t.Start();

            MyTask.Execute("Barcode获取焦点");
            InspectResult.PackLotYetPackCout++;
            InspectResult.OrderYetPackCount++;
            InspectResult.NotPrintCount++;
            if (OrderSet.PrintSet.BtPrintConfig.Detailed.TriggerCount == InspectResult.NotPrintCount)
            {
                IBtPrint.StartPrint();
                InspectResult.NotPrintCount = 0;
            }
            return false;
        }

    }
}
