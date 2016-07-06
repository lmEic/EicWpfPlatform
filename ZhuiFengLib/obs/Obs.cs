using System.Collections.Generic;
using System.Collections.ObjectModel;

/**
* 命名空间: ZhuiFengLib
* 类 名： Obs
* 功 能： 提供具有消息通知能力的List类型
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2016/3/15 星期二 9:05:29 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　　　   　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace ZhuiFengLib
{
    public class Obs<T> : ObservableCollection<T>
    {
        public Obs()
        {
        }

        public Obs(List<T> list) : base(list)
        {
        }

        public void Add(List<T> list)
        {
            this.Clear();
            foreach (var tem in list)
            {
                this.Add(tem);
            }
        }
    }
}