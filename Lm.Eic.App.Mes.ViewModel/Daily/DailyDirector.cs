using GalaSoft.MvvmLight.Command;
using Lm.Eic.App.Mes.Utility.CacheStore;
using Lm.Eic.App.Mes.Utility.Common;

/**
* 命名空间: Lm.Eic.App.Mes.ViewModel.Daily
* 类 名： DailyDirector
* 功 能： N/A
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2016/3/15 星期二 13:09:00 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　　　   　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.ViewModel.Daily
{
    public class DailyDirector
    {
        public DailyDirector()
        {
            if ( LoginUser.UserInfo.Department == Department.STR_DpPt)
                IDaily = new DailyPtOne();
            if ( LoginUser.UserInfo.Department == Department.STR_DpOne)
                IDaily = new DailyMsOne();
            if ( LoginUser.UserInfo.Department == Department.STR_MsSeven)
                IDaily = new DailyMsSeven();
            if ( LoginUser.UserInfo.Department == Department.STR_MsThree)
                IDaily = new DailyMsThree();
        }

       

        /// <summary>
        ///  日报
        /// </summary>
        public IDailyBase IDaily { get; set; }

        /// <summary>
        /// 添加一个日报到数据库 带验证
        /// </summary>
        public RelayCommand AddDailyToDbCommand => new RelayCommand(() =>
        {
        }, () => { return true; });
    }
}