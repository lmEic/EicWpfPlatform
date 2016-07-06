using GalaSoft.MvvmLight.Command;
using Lm.Eic.App.Mes.Business;
using System.Collections.Generic;
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

namespace Lm.Eic.App.Mes.ViewModel.Oqc
{
    /// <summary>
    /// 检测结果
    /// </summary>
    public class InspectResult : VMbase
    {
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
    abstract public class BaggingInspectionBase : VMbase, IBaggingInspectionBase
    {
        /// <summary>
        /// 3D原始数据列表
        /// </summary>
        public ZhuiFengLib.Obs<Model.User_3D_Test_Good> User3DTestGoodList { get; set; } = new ZhuiFengLib.Obs<Model.User_3D_Test_Good>();

        /// <summary>
        /// Exfo原始数据列表
        /// </summary>
        public ZhuiFengLib.Obs<Model.User_JDS_Test_Good> UserJdsTestGoodList { get; set; } = new ZhuiFengLib.Obs<Model.User_JDS_Test_Good>();

        /// <summary>
        /// 工单检测标准
        /// </summary>
        private List<Model.OQC_OrderInspectStatnard> OrderInspectStardandList { get; set; } = new List<Model.OQC_OrderInspectStatnard>();

        /// <summary>
        /// 所有条码列表
        /// </summary>
        private List<Model.OQC_SerialNumber> AllSerialNumberList { get; set; } = new List<Model.OQC_SerialNumber>();

        private string orderid = string.Empty;

        /// <summary>
        /// 工单单号
        /// </summary>
        public string OrderID
        {
            get { return orderid; }
            set
            {
                orderid = value;
                this.RaisePropertyChanged("OrderID");
                LoadOrder();
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

        private Business.Bpm.Order order = new Business.Bpm.Order();

        /// <summary>
        /// 工单
        /// </summary>
        public Business.Bpm.Order Order
        {
            get { return order; }
            set
            {
                order = value;
                this.RaisePropertyChanged("Order");
            }
        }

        private Business.Oqc.OrderPackLot packLot = new Business.Oqc.OrderPackLot();

        /// <summary>
        /// 批号
        /// </summary>
        public Business.Oqc.OrderPackLot PackLot
        {
            get { return packLot; }
            set
            {
                packLot = value;
                this.RaisePropertyChanged("PackLot");
            }
        }

        private Business.Oqc.OrderInspectConfig inspectConfig = new Business.Oqc.OrderInspectConfig();

        /// <summary>
        /// 包装检测设置信息
        /// </summary>
        public Business.Oqc.OrderInspectConfig InspectConfig
        {
            get { return inspectConfig; }
            set
            {
                inspectConfig = value;
                this.RaisePropertyChanged("InspectConfig");
            }
        }

        private Business.Oqc.OrderBtPrintConfig btPrintConfig = new Business.Oqc.OrderBtPrintConfig();

        /// <summary>
        /// 标签打印配置
        /// </summary>
        public Business.Oqc.OrderBtPrintConfig BtPrintConfig
        {
            get { return btPrintConfig; }
            set
            {
                btPrintConfig = value;
                this.RaisePropertyChanged("BtPrintConfig");
            }
        }

        /// <summary>
        /// 打印服务类
        /// </summary>
        public Business.Oqc.Print.IBtPrintBase BtPrint;

        /// <summary>
        /// 初始化检测信息
        /// </summary>
        private void LoadOrder()
        {
            /*
             * Order=》初始工单
             * AllserialNumberList =》 初始化条码，获取工单中的所有条码
             * PackLot=》获取当前的包装批号
             * OrderInspectStandard =》获取检测标准
             * BTPrintConfig =》获取打印配置文件
             * InspectConfig => 获取检测配置信息
            **/
            Order = new Business.Bpm.Order(OrderID);
            AllSerialNumberList = Operation.OqcHelper.SerialNumber.GetModelList(m => m.OrderID == OrderID);
            PackLot = new Business.Oqc.OrderPackLot(OrderID);
            OrderInspectStardandList = Operation.OqcHelper.InspectStandard.GetModelList(m => m.OrderID == OrderID);
            BtPrintConfig = new Business.Oqc.OrderBtPrintConfig(OrderID);
            InspectConfig = new Business.Oqc.OrderInspectConfig(OrderID);
            if (order.IsNull)
            {
                msg.MessageInfo("未找到工单");
            }
        }

        /// <summary>
        /// 虚方法 进行标签检测
        /// </summary>
        /// <returns></returns>
        abstract public InspectResult Inspect(string barcode);

        /// <summary>
        ///
        /// </summary>
        public RelayCommand<string> InputBarcodeCommand => new RelayCommand<string>((str) =>
        {
            Inspect(str);
        });
    }

    /// <summary>
    /// 装袋检测 Pigtail检测
    /// </summary>
    public class BaggingInspectPigtail : BaggingInspectionBase, IBaggingInspectionBase
    {
        public BaggingInspectPigtail()
        {
        }

        public BaggingInspectPigtail(string orderid)
        {
            OrderID = orderid;
        }

        public override InspectResult Inspect(string barcode)
        {
            msg.MessageInfo($"Pigtail{barcode}");
            if (Order.IsNull) { msg.MessageInfo(""); return new InspectResult(); }
            else return null;
        }
    }

    /// <summary>
    /// 装袋检测 Connector
    /// </summary>
    public class BaggingInspectConnector : BaggingInspectionBase, IBaggingInspectionBase
    {
        public BaggingInspectConnector(string orderid)
        {
            OrderID = orderid;
        }

        public override InspectResult Inspect(string barcode)
        {
            msg.MessageInfo($"Connector{barcode}");
            return null;
        }
    }
}