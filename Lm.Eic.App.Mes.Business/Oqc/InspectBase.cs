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

namespace Lm.Eic.App.Mes.Business.Oqc
{
    internal class InspectBase : IInspectBase
    {
        /// <summary>
        ///  工单
        /// </summary>
        public Bpm.Order Order { get; set; } = new Bpm.Order();

        /// <summary>
        /// 包装批号
        /// </summary>
        public PackLot PackLot { get; set; } = new PackLot();

        /// <summary>
        /// 检测标准
        /// </summary>
        public InspectStandard InspectStandard { get; set; } = new InspectStandard();

        /// <summary>
        /// 标签模板
        /// </summary>
        public BtTemplate BtTemplate { get; set; } = new BtTemplate();

        /// <summary>
        ///  标签打印服务
        /// </summary>
        public BtPrint BtPrint { get; set; } = new BtPrint();

        /// <summary>
        /// 进行检测
        /// </summary>
        /// <returns></returns>
        public bool Inspect()
        {
            return false;
        }

        /// <summary>
        /// 进行打印
        /// </summary>
        /// <returns></returns>
        public bool Print()
        {
            return false;
        }
    }
}