/**
* 命名空间: Lm.Eic.App.Mes.ViewModel.Bpm.OrderSet
* 类 名： OrderSetBase
* 功 能： N/A
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 3/25/2016 1:33:10 PM 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　   　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.ViewModel.Bpm.OrderSet
{
    public class OrderSetBase : VMbase
    {
      
        public Business.Bpm.Order order = new Business.Bpm.Order();

        /// <summary>
        ///
        /// </summary>
        public Business.Bpm.Order Order
        {
            get { return order; }
            set
            {
                order = value;
                this.RaisePropertyChanged("Order");
            }
        }
    }
}