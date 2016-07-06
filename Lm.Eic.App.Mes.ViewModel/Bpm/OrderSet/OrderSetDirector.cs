using GalaSoft.MvvmLight.Command;
using System;
using msg = ZhuiFengLib.Message.Message;

namespace Lm.Eic.App.Mes.ViewModel.Bpm.OrderSet
{
    public class OrderSetDirector : OrderSetBase
    {
        public OrderSetDirector() {}

        /// <summary>
        /// 初始化为一个工单的设置信息
        /// </summary>
        /// <param name="orderId"></param>
        public OrderSetDirector(string orderId)
        {
            try
            {
                LoadOrderSetInfo(orderId);
            }catch(Exception ex) { msg.MessageInfo(ex.Message); }
        }

        /// <summary>
        ///  初始化工单设置信息
        /// </summary>
        public RelayCommand<string> GetModelCommand => new RelayCommand<string>((orderId) =>
        {
            LoadOrderSetInfo(orderId);
        });

        /// <summary>
        /// 初始化工单设置信息
        /// </summary>
        /// <param name="orderId"></param>
        private void LoadOrderSetInfo(string orderId)
        {
            Order = new Business.Bpm.Order(orderId);
            PrintSet = new PrintSet(orderId);
            PackLotSet = new PackLotSet(orderId);
            SerialNumberSet = new SerialNumberSet(orderId);
            InspectSet = new InspectSet(orderId);
        }

        /// <summary>
        /// 保存工单信息到数据库
        /// </summary>
        public RelayCommand SaveOrderCommand => new RelayCommand(() =>
        {
            if (Order.SavaToMes()) { ZhuiFengLib.Message.Message.MessageInfo("保存成功！"); }
        });

        private PrintSet printSet = new OrderSet.PrintSet();

        /// <summary>
        /// 打印设置
        /// </summary>
        public PrintSet PrintSet
        {
            get { return printSet; }
            set
            {
                printSet = value;
                this.RaisePropertyChanged(nameof(PrintSet));
            }
        }

        private PackLotSet packLotSet = new OrderSet.PackLotSet();

        /// <summary>
        /// 包装批号设置
        /// </summary>
        public PackLotSet PackLotSet
        {
            get { return packLotSet; }
            set
            {
                packLotSet = value;
                this.RaisePropertyChanged(nameof(PackLotSet));
            }
        }

        private SerialNumberSet serialNumberSet = new SerialNumberSet();

        /// <summary>
        /// 条码设置
        /// </summary>
        public SerialNumberSet SerialNumberSet
        {
            get { return serialNumberSet; }
            set
            {
                serialNumberSet = value;
                this.RaisePropertyChanged(nameof(SerialNumberSet));
            }
        }

        private InspectSet inspectSet = new InspectSet();

        /// <summary>
        /// 检测设置
        /// </summary>
        public InspectSet InspectSet
        {
            get { return inspectSet; }
            set
            {
                inspectSet = value;
                this.RaisePropertyChanged(nameof(InspectSet));
            }
        }
    }
}