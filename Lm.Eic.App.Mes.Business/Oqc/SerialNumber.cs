

using System;
using Lm.Eic.App.Mes.Model;
/**
* 命名空间: Lm.Eic.App.Mes.Business
* 类 名： SerialNumber
* 功 能： N/A
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2016/3/10 星期四 15:48:47 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　　　   　　　　　　　　　│
*└──────────────────────────────────┘
*/
namespace Lm.Eic.App.Mes.Business.Oqc
{
    internal class SerialNumber : Orm<Model.OQC_SerialNumber>
    {
        public SerialNumber() : base(Model.Operation.DbTwoMes)
        {
            Detailed = new Model.OQC_SerialNumber();
        }

        /// <summary>
        ///  工单所有条码列表
        /// </summary>
        public ModelList_obs OrderSerialNumberList { get; set; } = new ModelList_obs();

        public ModelList_obs GetOrderAllSerialNumber(Bpm.Order order)
        {
            OrderSerialNumberList = new ModelList_obs(GetModelList(m => m.OrderID == order.Detailed.OrderID));
            return OrderSerialNumberList;
        }

        /// <summary>
        /// 工单中是否有条码
        /// </summary>
        public bool IsOrderSerialNumberNull => OrderSerialNumberList.Count > 0 ? true : false;

        public override OQC_SerialNumber Detailed { get; set; } = new OQC_SerialNumber();
         
    }
}