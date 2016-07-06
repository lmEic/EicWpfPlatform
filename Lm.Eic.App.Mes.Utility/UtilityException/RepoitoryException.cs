using System;
using System.Runtime.Serialization;

/**
* 命名空间: Lm.Eic.App.Mes.Utility
* 类 名： RepoitoryException
* 功 能： N/A
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2016/3/10 星期四 11:36:29 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　　　   　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.Utility.UtilityException
{
    [Serializable]
    public class RepoitoryException : Exception
    {
        public RepoitoryException()
        {
        }

        public RepoitoryException(string message)
        {
            ZhuiFengLib.Message.Message.MessageInfo(message);
        }

        public RepoitoryException(string message, Exception innerException)
        {
            ZhuiFengLib.Message.Message.MessageInfo(message);
        }

        protected RepoitoryException(SerializationInfo info, StreamingContext context)
        {
            ZhuiFengLib.Message.Message.MessageInfo($"{info.AssemblyName}\r\n{context}");
        }
    }
}