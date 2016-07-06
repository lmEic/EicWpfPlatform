/**
* 命名空间: Lm.Eic.App.Mes.Business.Oqc
* 类 名： UserText3D
* 功 能： N/A
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2016/3/10 星期四 16:10:49 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　　　   　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.Business.Oqc
{
    public class UserTest3D : Orm<Model.User_3D_Test_Good>
    {
        public UserTest3D() : base(Model.Operation.DbTwoLine)
        {
        }

     
    }
}