using System;
using msg = ZhuiFengLib.Message.Message;

/**
* 命名空间: Lm.Eic.App.Mes.Business.Oqc
* 类 名： Inspect
* 功 能： N/A
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2016/3/10 星期四 16:13:39 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　　　   　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.Business.Oqc.Inspect
{
    abstract public class InspectBase : IInspectBase,IDisposable
    {
        private Bpm.Order order = new Bpm.Order();

        /// <summary>
        ///  工单
        /// </summary>
        public Bpm.Order Order
        {
            get { return order; }
            set
            {
                if (Order.IsNull) msg.MessageInfo("未找到对应的工单");
            }
        }

        /// <summary>
        /// 包装批号
        /// </summary>
        public OrderPackLot PackLot { get; set; } = new OrderPackLot();

        /// <summary>
        /// 检测标准
        /// </summary>
        public OrderInspectStandard InspectStandard { get; set; } = new OrderInspectStandard();

        /// <summary>
        /// 标签模板
        /// </summary>
        public OrderBtPrintConfig BtTemplate { get; set; } = new OrderBtPrintConfig();

        /// <summary>
        ///  标签打印服务
        /// </summary>
        public Print.IBtPrintBase BtPrint { get; set; }

        /// <summary>
        /// 进行检测
        /// </summary>
        /// <returns></returns>
        abstract public bool Inspect(string barcode);

        public void Dispose()
        {
            Order.Dispose();
            PackLot.Dispose();
            InspectStandard.Dispose();
            BtPrint.Dispose();
            BtTemplate.Dispose();
            
        }
    }
}