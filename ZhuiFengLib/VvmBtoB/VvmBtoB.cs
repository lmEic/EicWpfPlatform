﻿using System;

/**
* 命名空间: ZhuiFengLib
* 类 名： VvmBtoB
* 功 能： N/A
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 3/21/2016 10:12:26 AM 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　   　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace ZhuiFengLib
{
    /// <summary>
    /// 提供VM与view之间的通许
    /// </summary>
    public class VvmBtoB
    {
        /// <summary>
        /// 具体的任务
        /// </summary>
        public Action<string> MyTask;

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="pr"></param>
        public void Execute(string pr)
        {
            if (MyTask != null)
            {
                MyTask(pr);
            }
        }
    }
}