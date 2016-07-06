using Lm.Eic.App.Mes.Model;
using msg = ZhuiFengLib.Message.Message;

/**
* 命名空间: Lm.Eic.App.Mes.Business.Oqc
* 类 名： PackLot
* 功 能： 包装批号
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2016/3/10 星期四 17:00:21 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　　　   　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.Business.Oqc
{
    public class OrderPackLot : Orm<OQC_OrderPackLot>
    {
        public OrderPackLot() : base(Model.Operation.DbTwoMes) { }


        /// <summary>
        /// 初始化一个批号
        /// 根据工单单号 返回正在生产中的包装批号
        /// </summary>
        /// <param name="orderID"></param>
        public OrderPackLot(string orderID) : base(Model.Operation.DbTwoMes)
        {
            var packLotList = GetModelList(m => m.OrderID == orderID && m.State=="生产中");

            if (packLotList?.Count > 1)
            {
                msg.MessageInfo("工单中存在两个生产中的批号，这是不合法的");
            }
            else if (packLotList?.Count < 1)
            {
                msg.MessageInfo("工单中未建立任何批号信息，请联系工程师录入！");
            }
            else
            {
                Detailed = packLotList[0];
            }
        }

      


        
    }
}