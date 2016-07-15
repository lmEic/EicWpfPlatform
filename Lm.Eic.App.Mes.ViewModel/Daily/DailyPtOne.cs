using GalaSoft.MvvmLight.Command;
using Lm.Eic.App.Mes.Business;
using Lm.Eic.App.Mes.Business.Ast;
using Lm.Eic.App.Mes.Business.Bpm;
using Lm.Eic.App.Mes.Model;
using System;
using System.Linq;
using ZhuiFengLib.Extension;
using msg = ZhuiFengLib.Message.Message;

/**
* 命名空间: Lm.Eic.App.Mes.ViewModel.Daily
* 类 名： DailyPtOne
* 功 能： 生技部日报录入
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2016/3/15 星期二 13:09:40 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　　　   　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.ViewModel.Daily
{
    internal class DailyPtOne : DailyBase, IDailyBase
    {
        internal DailyPtOne() : base()
        {
            Detartment = Utility.Common.Department.STR_DpPt;
        }

      

        public override string OrderID
        {
            get { return Daily.Detailed.OrderID; }
            set
            {
                Daily.Detailed.OrderID = value;
                this.RaisePropertyChanged("OrderID");
                if (!value.IsNullOrEmpty())
                {
                    Order = new Order(value);
                    if (!Order.IsNull)
                    {
                        Daily.Detailed.ProductID = Order.Detailed.ProductID;
                        Daily.Detailed.ProductName = Order.Detailed.ProductName;
                        Daily.Detailed.Spec = Order.Detailed.Spec;
                        Daily.Detailed.OrderCount = Order.Detailed.Count;
                        Daily.Detailed.State = Order.Detailed.State;
                        GetOrderProcessList();
                        if (!ProcessID.IsNullOrEmpty())
                        {
                            ProcessID = ProcessID;
                        }
                    }
                }
            }
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
                            MasterName = Equipment.Detailed.MasterName;
                        }
                    }
                }
                else { Equipment = null; }
            }
        }

        public override BPM_Daily CreateDaily()
        {
            AllDailyList.Clear();
            AllDailyList.Add(Daily.GetModelList(m => m.Department == Detartment && m.WorkShop == Daily.Detailed.WorkShop && m.Date == DailyDate));

            //-------------------------------------生成及更新出勤时数
            Double? _AttendanceHours = Daily.Detailed.InputHours;
            var temUserDailyList = AllDailyList.Where(m => m.Job_Num == Daily.Detailed.Job_Num).ToList();
            if (Equipment?.Detailed?.IsAuto == true && temUserDailyList.Count > 0) //如果是自动设备  平摊出勤工时
            {
                _AttendanceHours = Daily.Detailed.InputHours / (temUserDailyList.Count + 1);
                foreach (var daily in temUserDailyList)
                {
                    daily.AttendanceHours = _AttendanceHours;
                    Daily.Update(daily);
                }
            }

            Daily.Detailed.Department = Detartment;
            QtyNg = 0;
            WorkHours = InputHours;
            if (QtyNg == null) { QtyNg = 0; }
            Daily.Detailed.Qty = QtyOk + QtyNg;
            this.Daily.Detailed.TotalWorkHoursStandard = Math.Round(Convert.ToDouble(this.Daily.Detailed.Qty / Process.Detailed.StandardHours), 3);
            //效率计算公式
            //得到公式 产量/标准工时
            //效率 = 得到工时 /投入工时
            this.Daily.Detailed.Efficiency = Math.Round(Convert.ToDouble(Daily.Detailed.TotalWorkHoursStandard / this.Daily.Detailed.WorkHours), 2);
            Daily.Detailed.ProcessID = Process.Detailed.ProcessID;
            Daily.Detailed.ProcessName = Process.Detailed.Name;
            Daily.Detailed.StandardHours = Process.Detailed.StandardHours;
            Daily.Detailed.ProcessSign = Process.Detailed.ProcessSign;
            Daily.Detailed.AttendanceHours = _AttendanceHours;
            Daily.Detailed.MasterName = MasterName;
            return Daily.Detailed;
        }

        public override BPM_Process SelectProcess
        {
            set
            {
                if (value?.ProcessID?.IsNullOrEmpty() == false)
                {
                    QtyOk = QtyOk;
                    Daily.Detailed.ProcessID = value.ProcessID.Replace($"{Order.Detailed?.ProductName}-", "");
                    ProcessID = value.ProcessID.Replace($"{Order.Detailed?.ProductName}-", "");
                }
                this.RaisePropertyChanged(nameof(SelectProcess));
            }
        }


        public override void GetOrderProcessList()
        {
            //刷新工序列表
            ProcessList = new Orm<BPM_Process>.ModelList_obs(Business.Operation.BpmHeper.Process.GetModelList(m => m.Department == Detartment));
            var _productName = $"{Order.Detailed?.ProductName}-";
            this.OrderProcessList = new Orm<BPM_Process>.ModelList_obs(ProcessList.Where(m => m.ProcessID.StartsWith(_productName)).ToList());
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
        /// 良品数量
        /// </summary>
        public override int? QtyOk
        {
            get { return Daily.Detailed.QtyOK; }
            set
            {
                this.Daily.Detailed.QtyOK = value;
                this.RaisePropertyChanged("QtyOK");
                TotalWorkHoursStandard = Math.Round(Convert.ToDouble(value / Process.Detailed.StandardHours), 3);
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
                Daily.Detailed.ProcessID = value;
                MsgProcess = string.Empty;
                this.RaisePropertyChanged("ProcessID");
                if (!value.IsNullOrEmpty())
                {
                    if (Order.IsNull)
                    {
                        MsgProcess = "未找到该工单！"; return;
                    }
                    if (!Order.IsNull)
                    {
                        Process = new Process(Order.Detailed?.ProductName + "-" + value);
                    }
                    if (Process.IsNull) { MsgProcess = "未找到该工序"; }
                    //如果工序不为空且机台不为空 且机台工序不为输入的工序 更新机台工序
                    else if (!Equipment.IsNull && !Equipment.Detailed.ProcessID.Equals(value))
                    {
                        Equipment.Detailed.ProcessID = value;
                        Equipment.Update();
                    }
                }
            }
        }

        /// <summary>
        /// 添加一个日报到数据库
        /// </summary>
        public override RelayCommand AddDilytToDbCommand => new RelayCommand(() =>
        {
            var daily = CreateDaily();
            if (Daily.Add(daily))  //持久化到数据库
            {
                var temDaily = ExList.ModelCopy(daily);
                AllDailyList.Add(temDaily);//添加日报到个人日报列表

                CreateTotalInfo();   //生成日报汇总信息
                MyTask.Execute("获取焦点");
            }
        });

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