using GalaSoft.MvvmLight.Command;
using Lm.Eic.App.Mes.Business.Oqc.Inspect;

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

namespace Lm.Eic.App.Mes.ViewModel.Oqc
{
    public class PackInspect : VMbase<InspectDirctor>
    {
        private IBaggingInspectionBase ibaggingInspection = new BaggingInspectPigtail();

        /// <summary>
        ///
        /// </summary>
        public IBaggingInspectionBase IBaggingInspection
        {
            get { return ibaggingInspection; }
            set
            {
                ibaggingInspection = value;
                this.RaisePropertyChanged("IBaggingInspection");
            }
        }

        /// <summary>
        /// 输入工单单号
        /// </summary>
        public RelayCommand<string> InputOrderIDCommand => new RelayCommand<string>((str) =>
        {
            IBaggingInspection = GetInspect(str);
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
                // IBaggingInspection.BtPrintConfig.Detailed.PrintType
            }
        }

        /// <summary>
        /// 返回检测方法
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        private IBaggingInspectionBase GetInspect(string orderID)
        {
            var InspectConfig = new Business.Oqc.OrderInspectConfig(orderID);
            if (!InspectConfig.IsNull)
            {
                switch (InspectConfig.Detailed.InspectMethod)
                {
                    case ("一码一签"):
                        return new BaggingInspectPigtail(orderID);

                    case ("跳线"):
                        return new BaggingInspectConnector(orderID);

                    default: return new BaggingInspectPigtail();
                }
            }
            else { return new BaggingInspectPigtail(); }
        }
    }
}