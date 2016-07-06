using System;
using Lm.Eic.App.Mes.Model;

/**
* 命名空间: Lm.Eic.App.Mes.Business
* 类 名： Equipment
* 功 能： N/A
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2016/3/15 星期二 11:19:29 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　　　   　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.Business.Ast
{
    public class Equipment : Orm<Model.Ast_Equipment>
    {
        public Equipment() : base(Model.Operation.DbMes)
        {
        }

        public Equipment(string assetNum) : base(Model.Operation.DbMes)
        {
            Detailed = GetModel(m => m.AssetNum == assetNum && m.Department == Utility.CacheStore.LoginUser.UserInfo.Department);
        }
    }
}