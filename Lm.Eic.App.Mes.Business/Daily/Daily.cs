using Lm.Eic.App.Mes.Model;
using System;

/**
* 命名空间: Lm.Eic.App.Mes.Business
*
* 功 能： N/A
* 类 名： DailyBase
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2016/3/10 星期四 10:58:10 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　　　   　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.Business.Daily
{
    public class Daily : Orm<Model.Bpm_Daily>
    {
        public Daily() : base(Model.Operation.DbMes)
        {
        }
        public override bool Add(Bpm_Daily model)
        {
            model.Month = model.Date.Value.Date.ToString("yyyyMM");
            model.DateTime = DateTime.Now;
            return base.Add(model);
        }
    }
}