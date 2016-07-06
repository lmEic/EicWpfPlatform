using GalaSoft.MvvmLight.Command;
using System;

/**
* 命名空间: Lm.Eic.App.Mes.ViewModel.Bpm.OrderSet
* 类 名： PackLotSet
* 功 能： N/A
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 3/25/2016 1:24:56 PM 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　   　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.ViewModel.Bpm.OrderSet
{
    public class PackLotSet : OrderSetBase
    {
        public PackLotSet() { }
        public PackLotSet(string orderId)
        {
            PackLotList = new Business.Orm<Model.OQC_OrderPackLot>.ModelList_obs(Business.Operation.OqcHelper.PackLot.GetModelList(m => m.OrderID == orderId));
            SelectPackLot = new Business.Oqc.OrderPackLot(orderId);
        }

        private Business.Oqc.OrderPackLot.ModelList_obs packLotList = new Business.Orm<Model.OQC_OrderPackLot>.ModelList_obs();

        /// <summary>
        /// 包装批号列表
        /// </summary>
        public Business.Oqc.OrderPackLot.ModelList_obs PackLotList
        {
            get { return packLotList; }
            set
            {
                packLotList = value;
                this.RaisePropertyChanged("PackLotList");
            }
        }


        private Business.Oqc.OrderPackLot seletPackLot = new Business.Oqc.OrderPackLot();
        /// <summary>
        /// 包装批号
        /// </summary>
        public Business.Oqc.OrderPackLot SelectPackLot
        {
            get { return seletPackLot; }
            set
            {
                seletPackLot = value;
                this.RaisePropertyChanged(nameof(SelectPackLot));
            }
        }


        private string packLot = string.Empty;

        /// <summary>
        ///
        /// </summary>
        public string PackLot
        {
            get { return packLot; }
            set
            {
                packLot = value;
                this.RaisePropertyChanged(nameof(PackLot));
            }
        }

        private int? packLotCount;

        /// <summary>
        ///
        /// </summary>
        public int? PacklotCount
        {
            get { return packLotCount; }
            set
            {
                packLotCount = value;
                this.RaisePropertyChanged(nameof(PacklotCount));
            }
        }

        private DateTime deliverydate = DateTime.Now;
     

      

        /// <summary>
        ///
        /// </summary>
        public DateTime DeliveryDate
        {
            get { return deliverydate; }
            set
            {
                deliverydate = value;
                RaisePropertyChanged(nameof(DeliveryDate));
            }
        }

        /// <summary>
        /// 添加一个包装批号
        /// </summary>
        public RelayCommand AddCommand => new RelayCommand(() =>
        {
            var temPackLot = new Model.OQC_OrderPackLot() { OrderID = order.Detailed.OrderID, ProductID = order.Detailed.ProductID, ProductName = order.Detailed.ProductName, Spec = order.Detailed.Spec, OrderCount = order.Detailed.Count, DeliveryDate = DeliveryDate, PackLot = PackLot, PackLotCount = PacklotCount, YetPackCout = 0, NotPackCount = PacklotCount, State = "待包装" };
            Business.Operation.OqcHelper.PackLot.Add(temPackLot);
            PackLotList.Add(temPackLot);
        });


    }
}