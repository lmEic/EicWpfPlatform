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
    public class OrderSerialNumber : Orm<OQC_SerialNumber>
    {
        public OrderSerialNumber() : base(Model.Operation.DbTwoMes)
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

     

        /// <summary>
        /// 生成条码
        /// </summary>
        /// <param name="order">工单</param>
        /// <param name="snType">SN类型</param>
        /// <param name="startSn">开始SN</param>
        /// <param name="count">要生成的数量</param>
        /// <returns></returns>
        public ModelList_obs CreateSerialNumber(Business.Bpm.Order order, SerialNumberType snType, long? startSn, int? count)
        {
            if (startSn != null && count != null)
            {
                var temSnList = new ModelList_obs();
                for (int i = 0; i < count; i++)
                {
                    temSnList.Add(new OQC_SerialNumber()
                    {
                        OrderID = order.Detailed.OrderID,
                        Type = snType.ToString(),
                        SN = (startSn + i).ToString(),
                        IsPack = false,
                        IsPrint = false,
                        Qty = 1
                    });
                }
                return temSnList;
            }
            else { return null; }
        }
    }

    public enum SerialNumberType
    {
        Pigtail,
        Connector
    }
}