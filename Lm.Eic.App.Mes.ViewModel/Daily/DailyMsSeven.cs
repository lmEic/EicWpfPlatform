using GalaSoft.MvvmLight.Command;
using Lm.Eic.App.Mes.Business;
using Lm.Eic.App.Mes.Business.Ast;
using Lm.Eic.App.Mes.Business.Bpm;
using Lm.Eic.App.Mes.Model;
using System;
using System.Linq;
using ZhuiFengLib.Extension;

namespace Lm.Eic.App.Mes.ViewModel.Daily
{
    internal class DailyMsSeven : DailyBase, IDailyBase
    {
        internal DailyMsSeven() : base()
        {
            Detartment = Utility.Common.Department.STR_MsSeven;
        }

        internal DailyMsSeven(string detartment) : base()
        {
            Detartment = detartment;
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
                    this.Daily.Detailed.AssetName = Equipment?.Detailed?.AssetName;
                    ProcessID = Equipment?.Detailed?.ProcessID;
                    MasterName = Equipment?.Detailed?.MasterName;
                }
            }
        }

        public override Bpm_Daily CreateDaily()
        {
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
            Daily.Detailed.AttendanceHours = WorkHours;
            Daily.Detailed.MasterName = MasterName;
            return Daily.Detailed;
        }

        public override Bpm_Process SelectProcess
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
            ProcessList = new Orm<Bpm_Process>.ModelList_obs(Business.Operation.BpmHeper.Process.GetModelList(m => m.Department == Detartment));
            var _productName = $"{Order.Detailed?.ProductName}-";
            this.OrderProcessList = new Orm<Bpm_Process>.ModelList_obs(ProcessList.Where(m => m.ProcessID.StartsWith(_productName)).ToList());
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
                    else if (Equipment?.Detailed?.ProcessID  != value)  
                    {
                        Equipment.Detailed.ProcessID = value;
                        Equipment.Update();
                    }
                }
                else { Process = null; }
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
               AllDailyList.Add(ExList.ModelCopy(daily));//添加日报到个人日报列表

               //-------------------------------------生成及更新出勤时数
               var temAllDailyList = Daily.GetModelList(m => m.Department == Detartment && m.WorkShop == Daily.Detailed.WorkShop && m.Date == DailyDate);
               Double? _AttendanceHours = Daily.Detailed.InputHours;
               var temUserDailyList = temAllDailyList.Where(m => m.JobNum == Daily.Detailed.JobNum).ToList();
               if (Equipment?.Detailed?.IsAuto == true && temUserDailyList.Count > 0) //如果是自动设备  平摊出勤工时
               {
                   _AttendanceHours = Daily.Detailed.InputHours / (temUserDailyList.Count + 1);
                   foreach (var temdaily in temUserDailyList)
                   {
                       temdaily.AttendanceHours = _AttendanceHours;
                       Daily.Update(temdaily);
                   }
               }

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