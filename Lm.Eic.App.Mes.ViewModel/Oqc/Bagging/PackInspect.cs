using GalaSoft.MvvmLight.Command;
using System;
using msg = ZhuiFengLib.Message.Message;

/**
* 命名空间: Lm.Eic.App.Mes.ViewModel.Oqc
* 类 名： PackInspect
* 功 能： N/A
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 3/22/2016 1:54:42 PM 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　   　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.ViewModel.Oqc.Bagging
{
    public class PackInspect : VMbase
    {
        private IBaggingBase ibagging = new BaggingPigtail();

        /// <summary>
        ///
        /// </summary>
        public IBaggingBase IBagging
        {
            get { return ibagging; }
            set
            {
                ibagging = value;
                this.RaisePropertyChanged(nameof(IBagging));
            }
        }

        private ZhuiFengLib.VvmBtoB myTask = new ZhuiFengLib.VvmBtoB();

        /// <summary>
        ///
        /// </summary>
        public ZhuiFengLib.VvmBtoB MyTask
        {
            get { return myTask; }
            set
            {
                myTask = value;
                this.RaisePropertyChanged(nameof(MyTask));
            }
        }

        /// <summary>
        /// 检测设置信息
        /// </summary>
        public Bpm.OrderSet.OrderSetDirector OrderSet { get; set; } = new Bpm.OrderSet.OrderSetDirector();

        /// <summary>
        /// 输入工单单号
        /// </summary>
        public RelayCommand<string> InputOrderIDCommand => new RelayCommand<string>((str) =>
        {
            try
            {
                OrderSet = new Bpm.OrderSet.OrderSetDirector(str);
                IBagging = GetInspect();
                IsEnOrderID = false;
            }catch(Exception ex) { msg.MessageInfo(ex.Message); }
           
        });

        private bool isEnOrderId = true;

        /// <summary>
        /// 是否启用工单单号编辑
        /// </summary>
        public bool IsEnOrderID
        {
            get { return isEnOrderId; }
            set
            {
                isEnOrderId = value;
                this.RaisePropertyChanged("IsEnOrderID");
            }
        }

        /// <summary>
        /// 返回检测方法
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        private IBaggingBase GetInspect()
        {
            if (!OrderSet.InspectSet.SelectInspectConfig.IsNull)
            {
                switch (OrderSet.InspectSet.SelectInspectConfig.Detailed.InspectMethod)
                {
                    case ("一码一签"):
                        {
                            var tm = new BaggingPigtail();
                            tm.OrderSet = OrderSet;
                            tm.MyTask = this.MyTask;
                            return tm;
                        }

                    case ("两码一签"):
                        {
                            var tm = new BaggingTwoSnOneLab();
                            tm.OrderSet = OrderSet;
                            tm.MyTask = this.MyTask;
                            return tm;
                        }
                    case ("双并"):
                        {
                            var tm = new BaggingTwin();
                            tm.OrderSet = OrderSet;
                            tm.MyTask = this.MyTask;
                            return tm;
                        }

                    case ("跳线"):
                        {
                            var tm = new BaggingConnector();
                            tm.OrderSet = OrderSet;
                            tm.MyTask = this.MyTask;
                            return tm;
                        }
                        

                    default: return new BaggingPigtail();
                }
            }
            else { return new BaggingPigtail(); }
        }
    }
}