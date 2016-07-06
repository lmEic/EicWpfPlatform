using Lm.Eic.App.Mes.Model;
using msg = ZhuiFengLib.Message.Message;

/**
* 命名空间: Lm.Eic.App.Mes.Business
* 类 名： BtTemplate
* 功 能： 标签模板
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2016/3/10 星期四 16:05:37 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　　　   　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.Business.Oqc
{
    /// <summary>
    /// 标签打印配置
    /// </summary>
    public class OrderBtPrintConfig : Orm<Model.OQC_OrderPrintConfig>
    {
        public OrderBtPrintConfig() : base(Model.Operation.DbTwoMes)
        {
        }

        /// <summary>
        /// 根据工单单号 返回一个打印配置文件
        /// </summary>
        /// <param name="orderID"></param>
        public OrderBtPrintConfig(string orderID) : base(Model.Operation.DbTwoMes)
        {
            var btPrintConfigList = GetModelList(m => m.OrderID == orderID);

            if (btPrintConfigList?.Count > 1)
            {
                msg.MessageInfo("工单中存在两个打印配置文件，这是不合法的");
            }
            else if (btPrintConfigList?.Count < 1)
            {
                msg.MessageInfo("工单中未建立任何标签打印信息，请联系工程师录入！");
            }
            else
            {
                Detailed = btPrintConfigList[0];
            }
        }

      

        /// <summary>
        /// 打印类型列表
        /// </summary>
        public ZhuiFengLib.Obs<string> PrintType { get; set; } = new ZhuiFengLib.Obs<string>() {"无打印", "BT打印", "HP打印", "HP&BT打印", };

        /// <summary>
        /// 所有标签模板的名字列表
        /// </summary>
        public ZhuiFengLib.Obs<string> AllLabNames { get; set; } = new ZhuiFengLib.Obs<string>(Print.BtPrintBase.GetFileLabNames());
    }
}