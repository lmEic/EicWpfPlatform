using GalaSoft.MvvmLight.Command;
using Lm.Eic.App.Mes.Model;
using System;
using System.Collections.Generic;

/**
* 命名空间: Lm.Eic.App.Mes.ViewModel.Daily
* 类 名： DailyMsTwo
* 功 能： N/A
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2016/3/19 星期六 10:19:38 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　　　   　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.ViewModel.Daily
{
    internal class DailyMsTwo : DailyBase, IDailyBase
    {
        public override RelayCommand ExportToExcelCommand
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override RelayCommand GetDailyListFoDb
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override List<string> WorkShopList
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override BPM_Daily CreateDaily()
        {
            throw new NotImplementedException();
        }
    }
}