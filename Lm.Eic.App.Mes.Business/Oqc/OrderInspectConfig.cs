using Lm.Eic.App.Mes.Model;

/**
* 命名空间: Lm.Eic.App.Mes.Business.Oqc
* 类 名： InspectConfig
* 功 能： 检测配置
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 3/24/2016 3:37:09 PM 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　   　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.Business.Oqc
{
    public class OrderInspectConfig : Orm<OQC_OrderInspectConfig>
    {
        public OrderInspectConfig() : base(Model.Operation.DbTwoMes)
        {
        }

        public OrderInspectConfig(string orderID) : base(Model.Operation.DbTwoMes)
        {
            Detailed = GetModel(m => m.OrderID == orderID);
        }

       

    }
}