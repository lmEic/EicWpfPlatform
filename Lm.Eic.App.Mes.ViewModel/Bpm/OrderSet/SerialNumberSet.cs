
using msg = ZhuiFengLib.Message.Message;
using GalaSoft.MvvmLight.Command;
using System.Linq;
/**
* 命名空间: Lm.Eic.App.Mes.ViewModel.Bpm.OrderSet
* 类 名： SetialNumberSet
* 功 能： N/A
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 3/25/2016 11:21:51 AM 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　   　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
namespace Lm.Eic.App.Mes.ViewModel.Bpm.OrderSet
{
    /// <summary>
    /// 条码设置
    /// </summary>
    public class SerialNumberSet : OrderSetBase
    {
        public SerialNumberSet() { }

        public SerialNumberSet(string orderID)
        {
            SnList = new Business.Orm<Model.OQC_SerialNumber>.ModelList_obs(Business.Operation.OqcHelper.SerialNumber.GetModelList(m => m.OrderID == orderID));
        }

        private Business.Oqc.OrderSerialNumber.ModelList_obs snList = new Business.Orm<Model.OQC_SerialNumber>.ModelList_obs();
        /// <summary>
        /// Sn列表
        /// </summary>
        public Business.Oqc.OrderSerialNumber.ModelList_obs SnList
        {
            get { return snList; }
            set
            {
                snList = value;
                this.RaisePropertyChanged(nameof(SnList));
            }
        }


        private long? connectorStartSn;

        /// <summary>
        /// Connector开始SN
        /// </summary>
        public long? ConnectorStartSn
        {
            get { return connectorStartSn; }
            set
            {
                connectorStartSn = value;
                this.RaisePropertyChanged(nameof(ConnectorStartSn));
            }
        }

        private int? connectorCount;

        /// <summary>
        /// Connector数量
        /// </summary>
        public int? ConnectorCount
        {
            get { return connectorCount; }
            set
            {
                connectorCount = value;
                this.RaisePropertyChanged(nameof(ConnectorCount));
            }
        }

        private bool isCreateConnectorSn = true;

        /// <summary>
        /// 是否生成ConnectorSN
        /// </summary>
        public bool IsCreateConnectorSn
        {
            get { return isCreateConnectorSn; }
            set
            {
                isCreateConnectorSn = value;
                this.RaisePropertyChanged(nameof(IsCreateConnectorSn));
            }
        }

        private long? pigtailStartSn;

        /// <summary>
        /// Pigtail开始SN
        /// </summary>
        public long? PigtailStartSn
        {
            get { return pigtailStartSn; }
            set
            {
                pigtailStartSn = value;
                this.RaisePropertyChanged(nameof(PigtailStartSn));
            }
        }

        private int? pigtailCount;

        /// <summary>
        /// Pigtail数量
        /// </summary>
        public int? PigtailCount
        {
            get { return pigtailCount; }
            set
            {
                pigtailCount = value;
                this.RaisePropertyChanged(nameof(PigtailCount));
            }
        }

        private bool isCreatePigtailSn = false;

        /// <summary>
        /// 是否生成PigtailSN
        /// </summary>
        public bool IsCreatePigtailSn
        {
            get { return isCreatePigtailSn; }
            set
            {
                isCreatePigtailSn = value;
                this.RaisePropertyChanged(nameof(IsCreatePigtailSn));
            }
        }



        /// <summary>
        /// 生成SN编码
        /// </summary>
        public RelayCommand CreateSerialNumberCommand => new RelayCommand(() =>
        {
            SnList.Clear();
            if (IsCreateConnectorSn) //生成ConnectorSN列表
                SnList.Add(Business.Operation.OqcHelper.SerialNumber.CreateSerialNumber(order, Business.Oqc.SerialNumberType.Connector, ConnectorStartSn, ConnectorCount).ToList());
            if (IsCreatePigtailSn) //生成PigtailSN列表
                SnList.Add(Business.Operation.OqcHelper.SerialNumber.CreateSerialNumber(order, Business.Oqc.SerialNumberType.Pigtail, PigtailStartSn, PigtailCount).ToList());
        });


        /// <summary>
        /// 保存条码到数据库
        /// </summary>
        public RelayCommand SavaToDbCommand => new RelayCommand(() =>
        {
          var count =  Business.Operation.OqcHelper.SerialNumber.Add(SnList);
            msg.MessageInfo($"保存成功{count}条记录！");
        });




    }
}