using Lm.Eic.App.Mes.Business.Bpm;
using Lm.Eic.App.Mes.Model;
using System;
using ZhuiFengLib.Extension;
using msg = ZhuiFengLib.Message.Message;
using Lm.Eic.App.Mes.Utility.Common;
using Lm.Eic.App.Mes.Business.Ast;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using Lm.Eic.App.Mes.Business;
using System.Linq;

/**
* 命名空间: Lm.Eic.App.Mes.ViewModel.Daily
* 类 名： DailyMsOne
* 功 能： N/A
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2016/3/15 星期二 13:09:23 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　　　   　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.ViewModel.Daily
{
    internal class DailyMsOne : DailyBase, IDailyBase
    {

        internal DailyMsOne() : base()
        {
            Detartment = Department.STR_DpOne;
            this.Daily.Detailed.AttendanceHours = 12; //
            ProcessList = new Business.Orm<BPM_Process>.ModelList_obs( Business.Operation.BpmHeper.Process.GetModelList(m=>m.Department==Department.STR_MsOne || m.Department == Department.STR_MsSix));
        }

        /// <summary>
        /// 机台编号
        /// </summary>
        public override string AssetNum
        {
            get { return Daily.Detailed.AssetNum; }
            set
            {
                Daily.Detailed.AssetNum = value;
                this.RaisePropertyChanged("AssetNum");
                if (!value.IsNullOrEmpty())
                {
                    Equipment = new Equipment(value);
                    if (!Equipment.IsNull)
                    {
                        this.Daily.Detailed.AssetName = Equipment.Detailed.AssetName;
                        if (!Equipment.Detailed.ProcessID.IsNullOrEmpty())
                        {
                            ProcessID = Equipment.Detailed.ProcessID;
                        }
                    }
                }
            }
        }

      

        public override BPM_Daily CreateDaily()
        {
            Daily.Detailed.Department = Department.STR_DpOne;
            Daily.Detailed.Qty = QtyOk + QtyNg;
            this.Daily.Detailed.StandardHours = Process.Detailed.StandardHours;
            Daily.Detailed.ProcessID = Process.Detailed.ProcessID;
            Daily.Detailed.ProcessName = Process.Detailed.Name;
            Daily.Detailed.ProcessSign = Process.Detailed.ProcessSign;
            Daily.Detailed.Fpy = (1 - (Convert.ToDouble(QtyNg)/(QtyNg+QtyOk))) ;
            return Daily.Detailed;
        }

        /// <summary>
        /// 得到工时
        /// </summary>
        public double? TotalWorkHoursStandard
        {
            get { return this.Daily.Detailed.TotalWorkHoursStandard; }
            set
            {
                this.Daily.Detailed.TotalWorkHoursStandard = value;
                this.RaisePropertyChanged(nameof(TotalWorkHoursStandard));
            }
        }

        /// <summary>
        /// 良品数量
        /// </summary>
        public override int? QtyOk
        {
            get { return Daily.Detailed.QtyOK; }
            set
            {
                this.Daily.Detailed.QtyOK = value;
                this.RaisePropertyChanged("QtyOK");
                //得到工时计算=良品产出*秒数/3600
                TotalWorkHoursStandard = Math.Round(Convert.ToDouble(value * Process.Detailed.StandardHours / 3600), 3);
                //效率计算公式
                //得到公式 产量 * 标准工时 /3600
                //效率 = 得到工时 /投入工时
                Efficiency = Math.Round(Convert.ToDouble(TotalWorkHoursStandard / WorkHours), 2);
            }
        }

        private string notWorkProcessID = string.Empty;
        /// <summary>
        /// 非生成工时ID
        /// </summary>
        public string NotWorkProcessID
        {
            get { return notWorkProcessID; }
            set
            {
                notWorkProcessID = value;
                this.RaisePropertyChanged(nameof(NotWorkProcessID));
                NotWorkCause = new Process(value).Detailed?.Name;
            }
        }

        /// <summary>
        /// 工序输入
        /// </summary>
        public override string ProcessID
        {
            get
            {
                return Daily.Detailed.ProcessID; ;
            }

            set
            {
                this.RaisePropertyChanged("ProcessID");
                Daily.Detailed.ProcessID = value;
                if (!value.IsNullOrEmpty())
                {
                    if (Order.IsNull)
                    {
                        MsgProcess = "未找到该工单！"; return;
                    }
                    //  var tem = Order.Product.Detailed?.Alias?.Replace("-", "");
                    var tem = Order.Detailed?.ProductName?.Replace("-", "");
                    if (tem.IsNullOrEmpty()) { msg.MessageInfo("未找到此产品，请设置产品！"); return; }
                    if (!Order.IsNull)
                    {
                        if (Order.Detailed.OrderID.Contains("520"))  //520 是制六课
                            Process = new Process(tem + "-" + value, Department.STR_MsSix);
                        else if (Order.Detailed.OrderID.Contains("511")) //511 是制一课
                            Process = new Process(tem + "-" + value, Department.STR_MsOne);
                        else
                            Process = new Process(tem + "-" + value);
                    }
                    if (Process.IsNull) { msg.MessageInfo("未找到该工序"); }
                }
            }
        }

        public override void GetOrderProcessList()
        {
            if (Order.Detailed.OrderID.Contains("520"))  //520 是制六课
                ProcessList = new Orm<BPM_Process>.ModelList_obs(Business.Operation.BpmHeper.Process.GetModelList(m =>  m.Department == "制六课"));
            else if (Order.Detailed.OrderID.Contains("511")) //511 是制一课
                ProcessList = new Orm<BPM_Process>.ModelList_obs(Business.Operation.BpmHeper.Process.GetModelList(m => m.Department == "制一课"));
            else
                ProcessList = new Orm<BPM_Process>.ModelList_obs(Business.Operation.BpmHeper.Process.GetModelList(m => m.Department == "制一课" || m.Department == "制六课"));

            var _productName = $"{Order.Detailed?.ProductName?.Replace("-", "")}-"; ;
            this.OrderProcessList = new Orm<BPM_Process>.ModelList_obs(ProcessList.Where(m => m.ProcessID.StartsWith(_productName)).ToList());
        }

        private string msgProcess = string.Empty;
        /// <summary>
        /// 工序提示信息
        /// </summary>
        public string MsgProcess
        {
            get { return msgProcess; }
            set
            {
                msgProcess = value;
                this.RaisePropertyChanged(nameof(MsgProcess));
            }
        }


    }
}