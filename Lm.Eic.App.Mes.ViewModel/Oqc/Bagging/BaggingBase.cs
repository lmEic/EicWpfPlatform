using GalaSoft.MvvmLight.Command;
using Lm.Eic.App.Mes.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using msg = ZhuiFengLib.Message.Message;

/**
* 命名空间: Lm.Eic.App.Mes.ViewModel.Oqc
* 类 名： BaggingInspection
* 功 能： 装袋检测
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 3/23/2016 8:45:31 AM 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　   　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.ViewModel.Oqc.Bagging
{
    /// <summary>
    /// 检测结果
    /// </summary>
    public class InspectResult : VMbase
    {
        private int? orderYetPackCount = 0;
        /// <summary>
        /// 
        /// </summary>
        public int? OrderYetPackCount
        {
            get { return orderYetPackCount; }
            set
            {
                orderYetPackCount = value;
                this.RaisePropertyChanged(nameof(OrderYetPackCount));
            }
        }


        private int? packLotYetPackCout = 0;

        /// <summary>
        /// 本批已包装数量
        /// </summary>
        public int? PackLotYetPackCout
        {
            get { return packLotYetPackCout; }
            set
            {
                packLotYetPackCout = value;
                this.RaisePropertyChanged(nameof(PackLotYetPackCout));
            }
        }

        private int? notPrintCount = 0;

        /// <summary>
        /// 待打印的条码数量
        /// </summary>
        public int? NotPrintCount
        {
            get { return notPrintCount; }
            set
            {
                notPrintCount = value;
                this.RaisePropertyChanged(nameof(NotPrintCount));
            }
        }

        private bool result = false;

        /// <summary>
        /// 返回检测结果
        /// </summary>
        public bool Result
        {
            get { return result; }
            set
            {
                result = value;
                this.RaisePropertyChanged("Result");
            }
        }

        private string maxBarcode = string.Empty;

        /// <summary>
        /// 大条码
        /// </summary>
        public string MaxBarcode
        {
            get { return maxBarcode; }
            set
            {
                maxBarcode = value;
                this.RaisePropertyChanged("MaxBarcode");
            }
        }

        private string flage = string.Empty;

        /// <summary>
        ///  标志位
        /// </summary>
        public string Flage
        {
            get { return flage; }
            set
            {
                flage = value;
                this.RaisePropertyChanged("Flage");
            }
        }

        private string ng3dConnector = string.Empty;

        /// <summary>
        /// 3D不良接头列表
        /// </summary>
        public string Ng3dConnector
        {
            get { return ng3dConnector; }
            set
            {
                ng3dConnector = value;
                this.RaisePropertyChanged("Ng3dConnector");
            }
        }

        private string ngExfoConnector = string.Empty;

        /// <summary>
        /// Exfo不良接头列表
        /// </summary>
        public string NgExfoConnector
        {
            get { return ngExfoConnector; }
            set
            {
                ngExfoConnector = value;
                this.RaisePropertyChanged("NgExfoConnector");
            }
        }
    }

    /// <summary>
    /// 标签检测抽象类，父类
    /// </summary>
    abstract public class BaggingBase : VMbase, IBaggingBase
    {
        private Business.Oqc.UserTest3D.ModelList_obs user3DTestGoodList = new Orm<Model.User_3D_Test_Good>.ModelList_obs();

        /// <summary>
        /// 3D原始数据
        /// </summary>
        public Business.Oqc.UserTest3D.ModelList_obs User3DTestGoodList
        {
            get { return user3DTestGoodList; }
            set
            {
                user3DTestGoodList = value;
                this.RaisePropertyChanged(nameof(User3DTestGoodList));
            }
        }

        private ZhuiFengLib.VvmBtoB myTask = new ZhuiFengLib.VvmBtoB();

        /// <summary>
        /// 提供与ViewMode的通讯
        /// </summary>
        public ZhuiFengLib.VvmBtoB MyTask { get { return myTask; } set { myTask = value; } }

        private Business.Oqc.UserTestExfo.ModelList_obs userExfoTestGoodList = new Business.Oqc.UserTestExfo.ModelList_obs();

        /// <summary>
        /// Exfo数据列表
        /// </summary>
        public Business.Oqc.UserTestExfo.ModelList_obs UserExfoTestGoodList
        {
            get { return userExfoTestGoodList; }
            set
            {
                userExfoTestGoodList = value;
                this.RaisePropertyChanged(nameof(UserExfoTestGoodList));
            }
        }

        /// <summary>
        ///
        /// </summary>
        public bool Result
        {
            get { return InspectResult.Result; }
            set
            {
                InspectResult.Result = value;
                this.RaisePropertyChanged(nameof(Result));
                if (value) { MyTask.Execute("OK"); } else { MyTask.Execute("NG"); }
            }
        }

        private Bpm.OrderSet.OrderSetDirector orderSet = new Bpm.OrderSet.OrderSetDirector();

        /// <summary>
        /// 检测设置信息
        /// </summary>
        public Bpm.OrderSet.OrderSetDirector OrderSet
        {
            get { return orderSet; }
            set
            {
                orderSet = value;
                this.RaisePropertyChanged(nameof(OrderSet));
                //Print Set
                IBtPrint.PrintConfig = value.PrintSet.BtPrintConfig;
                if (value.PrintSet.SelectPrintType == "HP打印")
                    IBtPrint.SetLaberFormat = $@"D:\模板\PrintTemplates\HP_Templates\{OrderSet.PrintSet.SelectLabName}";
                else if (value.PrintSet.SelectPrintType == "BT打印")
                    IBtPrint.SetLaberFormat = $@"D:\模板\PrintTemplates\BT_Templates\{OrderSet.PrintSet.SelectLabName}";
                IBtPrint.LabContentList = OrderSet.PrintSet.LabContentList.ToList();
                //OrderCount Get

                InspectResult.OrderYetPackCount = value.SerialNumberSet.SnList.Where(m => m.IsPack == true).Count();
                inspectResult.PackLotYetPackCout =
                    value.SerialNumberSet.SnList.Where(m => m.PackLot == value.PackLotSet.SelectPackLot.Detailed.PackLot && m.IsPack == true).Count();
                
            }
        }

        private int awaitPrintQty = 0;

        /// <summary>
        /// 等待打印的条码
        /// </summary>
        public int AwaitPrintQty
        {
            get { return awaitPrintQty; }
            set
            {
                awaitPrintQty = value;
                this.RaisePropertyChanged(nameof(AwaitPrintQty));
            }
        }

        private InspectResult inspectResult = new InspectResult();

        /// <summary>
        /// 检测结果
        /// </summary>
        public InspectResult InspectResult
        {
            get { return inspectResult; }
            set
            {
                inspectResult = value;
                this.RaisePropertyChanged("InspectResult");
            }
        }

        /// <summary>
        /// SN检测
        /// </summary>
        /// <param name="Sn"></param>
        /// <returns></returns>
        public bool IsSnForOrder(string Sn)
        {
            if (OrderSet.SerialNumberSet.SnList.FirstOrDefault(m => m.SN == Sn) == null)
            {
                msg.MessageInfo("条码不属于此工单！"); return false;
            }
            else if (OrderSet.SerialNumberSet.SnList.FirstOrDefault(m => m.SN == Sn && m.IsPack == false) == null)
            {
                msg.MessageInfo($"条码已包装！\r\n批号:{OrderSet.SerialNumberSet.SnList.FirstOrDefault(m => m.SN == Sn && m.IsPack == true)?.PackLot}"); return false;
            }
            else return true;
        }

        public bool IsAccordInspectStandard(List<object> ls, List<object> lp)
        {
            return false;
        }

        /// <summary>
        /// 检测测试数据是否在标准范围内
        /// </summary>
        public bool IsAccordInspectStandard()
        {
            inspectResult.Result = true;
            //存储检测结果
            List<inspectResultModel> resultList = new List<inspectResultModel>();

            //检测3D数据
            if (OrderSet.InspectSet.SelectInspectConfig.Detailed.IsInspect3D == true)
            {
                foreach (var user3D in User3DTestGoodList)
                {
                    resultList.Add(new inspectResultModel() { sn = user3D.SN, type = "3D", fieldName = "Curvature", result = VfParameter("Curvature", user3D.Curvature) });
                    resultList.Add(new inspectResultModel() { sn = user3D.SN, type = "3D", fieldName = "Apex_Offset", result = VfParameter("Apex_Offset", user3D.Apex_Offset) });
                    resultList.Add(new inspectResultModel() { sn = user3D.SN, type = "3D", fieldName = "Spherical", result = VfParameter("Spherical", user3D.Spherical) });
                    resultList.Add(new inspectResultModel() { sn = user3D.SN, type = "3D", fieldName = "Tilt_Angle", result = VfParameter("Tilt_Angle", user3D.Tilt_Angle) });
                }
            }
            //检测Exfo数据
            if (OrderSet.InspectSet.SelectInspectConfig.Detailed.IsInspectExfo == true)
            {
                foreach (var userExfo in UserExfoTestGoodList)
                {
                    resultList.Add(new inspectResultModel() { sn = userExfo.SN, type = "Exfo", fieldName = "IL_A", result = VfParameter("IL_A", userExfo.IL_A) });
                    resultList.Add(new inspectResultModel() { sn = userExfo.SN, type = "Exfo", fieldName = "Refl_A", result = VfParameter("Refl_A", userExfo.Refl_A) });
                }
            }
            //查看检测结果是否有不符合的
            inspectResult.Result = resultList.Count > 0 && resultList.FirstOrDefault(m => m.result == false) == null ? true : false;
            inspectResult.Ng3dConnector = string.Empty;
            inspectResult.NgExfoConnector = string.Empty;
            foreach (var result in resultList)
            {
                if (result.result == false && result.type == "3D" && !inspectResult.Ng3dConnector.Contains(result.sn))
                    InspectResult.Ng3dConnector += $"{result.sn} ";
                else if (result.result == false && result.type == "Exfo" && !inspectResult.NgExfoConnector.Contains(result.sn))
                    inspectResult.NgExfoConnector += $"{result.sn} ";
            }
            return InspectResult.Result;
        }

      
        /// <summary>
        /// 验证传入的参数是否符合标准
        /// </summary>
        /// <param name="fieldName">参数名</param>
        /// <param name="textData">值</param>
        /// <returns></returns>
        private bool VfParameter(string fieldName, string textData)
        {
            var inspectStandard = OrderSet.InspectSet.InspectStandardList.FirstOrDefault(m => m.FieldName == fieldName);
            if (inspectStandard != null)
            {
                var testData = Convert.ToDouble(textData);
                return (testData > inspectStandard.Min && testData < inspectStandard.Max) ? true : false;
            }
            else return false;
        }


        private class inspectResultModel
        {
            public string sn { get; set; }
            public string type { get; set; }
            public string fieldName { get; set; }
            public bool result { get; set; }
        }

        /// <summary>
        /// 保存测试数据到数据库
        /// </summary>
        /// <returns></returns>
        public virtual bool SavaDataToDb(string serialNumber)
        {
            Thread t = new Thread(() =>
            {
                Operation.OqcHelper.Pack3D.Add(User3DTestGoodList, serialNumber, OrderSet.PackLotSet.SelectPackLot);
                Operation.OqcHelper.PackExfo.Add(UserExfoTestGoodList, serialNumber, OrderSet.PackLotSet.SelectPackLot);
                var serialnumber = orderSet.SerialNumberSet.SnList.FirstOrDefault(m => m.SN == serialNumber);
                if (serialnumber != null)
                {
                    serialnumber.IsPack = true;
                    serialnumber.PackLot = OrderSet.PackLotSet.SelectPackLot.Detailed.PackLot;
                    Operation.OqcHelper.SerialNumber.Update(serialnumber);
                }
            });
            t.IsBackground = true;
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



        /// <summary>
        /// 虚方法 进行标签检测
        /// </summary>
        /// <returns></returns>
        abstract public InspectResult Inspect(string barcode);


        Business.Oqc.Print.IBtPrintBase iBtPrint = new Business.Oqc.Print.BtPrintBase();
        /// <summary>
        /// 打印服务类
        /// </summary>
        public Business.Oqc.Print.IBtPrintBase IBtPrint => iBtPrint;

        /// <summary>
        /// 进行检测
        /// </summary>
        public RelayCommand<string> InputBarcodeCommand => new RelayCommand<string>((str) =>
        {
            InspectResult = Inspect(str);
        });

        /// <summary>
        /// 进行打印
        /// </summary>
        public RelayCommand LabPrint => new RelayCommand(() =>
        {
            StartPeint();
        });

        private void StartPeint()
        {
            IBtPrint.StartPrint();
            InspectResult.NotPrintCount = 0;
        }
    }
}