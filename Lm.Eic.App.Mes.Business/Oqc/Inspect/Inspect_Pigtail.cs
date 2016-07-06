using System;

/**
* 命名空间: Lm.Eic.App.Mes.Business.Oqc.Inspect
* 类 名： Inspect_Pigtail
* 功 能： N/A
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 3/22/2016 1:26:25 PM 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　   　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.Business.Oqc.Inspect
{
    /// <summary>
    /// Pigtail数据检测
    /// </summary>
    public class Inspect_Pigtail : InspectBase, IInspectBase
    {
        public override bool Inspect(string barcode)
        {
            throw new NotImplementedException();
        }
    }
}