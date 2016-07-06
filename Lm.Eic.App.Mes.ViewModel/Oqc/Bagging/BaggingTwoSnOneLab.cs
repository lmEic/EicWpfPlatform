using Lm.Eic.App.Mes.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ZhuiFengLib.Extension;
using msg = ZhuiFengLib.Message.Message;

namespace Lm.Eic.App.Mes.ViewModel.Oqc.Bagging
{
    /// <summary>
    /// 两码一签检测方法
    /// </summary>
    internal class BaggingTwoSnOneLab : BaggingBase, IBaggingBase
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
                    IBtPrint.ExfoDataList.Add(UserExfoTestGoodList?[0]);
                    // SavaDataToDb(barcode);
                    User3DList.Add(User3DTestGoodList[0]);
                    UserExfoList.Add(UserExfoTestGoodList[0]);
                    InsertDataToExcel();
                    Result = true;
                }
                else { Result = false; }
            }
            MyTask.Execute("Barcode获取焦点");
            return InspectResult;
        }

        private List<Model.User_JDS_Test_Good> UserExfoList = new List<Model.User_JDS_Test_Good>();
        private List<Model.User_3D_Test_Good> User3DList = new List<Model.User_3D_Test_Good>();

        /// <summary>
        /// 插入数据到模板
        /// </summary>
        public void InsertDataToExcel()
        {
            if (UserExfoList.Count == 2)
            {
                if (IsOddAndEven())
                {
                    var dataSourcsPath = OrderSet.PrintSet.BtPrintConfig.Detailed.DataSourcesPath;
                    ZhuiFengLib.OfficeHelper.ExcelHelper excelHelper = new ZhuiFengLib.OfficeHelper.ExcelHelper(dataSourcsPath);
                    var ParList = new List<ZhuiFengLib.OfficeHelper.InsertExcelParameter>();

                    //设置标签其他内容
                    foreach (var labContent in OrderSet.PrintSet.LabContentList)
                        ParList.Add(new ZhuiFengLib.OfficeHelper.InsertExcelParameter() { Type = labContent.Name, Paramenter = labContent.Value });

                    //设置数据
                    var exfoOne = UserExfoList[0];
                    var exfoTwo = UserExfoList[1];
                    ParList.Add(new ZhuiFengLib.OfficeHelper.InsertExcelParameter() { Type = "SN_1", Paramenter = exfoOne.SN });
                    ParList.Add(new ZhuiFengLib.OfficeHelper.InsertExcelParameter() { Type = "IL_1", Paramenter = exfoOne.IL_A });
                    ParList.Add(new ZhuiFengLib.OfficeHelper.InsertExcelParameter() { Type = "RL_1", Paramenter = exfoOne.Refl_A });
                    ParList.Add(new ZhuiFengLib.OfficeHelper.InsertExcelParameter() { Type = "SN_2", Paramenter = exfoTwo.SN });
                    ParList.Add(new ZhuiFengLib.OfficeHelper.InsertExcelParameter() { Type = "IL_2", Paramenter = exfoTwo.IL_A });
                    ParList.Add(new ZhuiFengLib.OfficeHelper.InsertExcelParameter() { Type = "RL_2", Paramenter = exfoTwo.Refl_A });
                    excelHelper.InsertRow(ParList);

                    SavaDataToDb("");
                }
                else { msg.MessageInfo("两个条码不属于同一条线，请检查！"); User3DList.Clear(); UserExfoList.Clear(); }
            }
        }

        /// <summary>
        /// 判断输入的是否为奇偶两个条码
        /// </summary>
        /// <returns></returns>
        public bool IsOddAndEven()
        {
            if (UserExfoList.Count > 1)
            {
                List<int> snList = new List<int>() {
                    Convert.ToInt32( UserExfoList[0].SN.Substring(UserExfoList[0].SN.Length-2,2)),
                    Convert.ToInt32( UserExfoList[1].SN.Substring(UserExfoList[1].SN.Length-2,2)) };
                return (snList.Max().IsEven() && snList.Max() - snList.Min() == 1) ? true : false;
            }
            else return false;
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
                foreach (var user3D in User3DList)
                    Operation.OqcHelper.Pack3D.Add(user3D, user3D.SN, OrderSet.PackLotSet.SelectPackLot);
                foreach (var exfo in UserExfoList)
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

                UserExfoList.Clear();
                User3DList.Clear();
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