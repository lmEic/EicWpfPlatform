using GalaSoft.MvvmLight.Command;
using Lm.Eic.App.Mes.Business;
using Lm.Eic.App.Mes.Business.Ast;
using Lm.Eic.App.Mes.Business.Bpm;
using Lm.Eic.App.Mes.Business.Hr;
using Lm.Eic.App.Mes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ZhuiFengLib;
using ZhuiFengLib.Extension;
using msg = ZhuiFengLib.Message.Message;

/**
* 命名空间: Lm.Eic.App.Mes.ViewModel.Daily
* 类 名： DailyBase
* 功 能： N/A
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2016/3/15 星期二 13:04:36 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　　　   　　　　　　　　　│
*└──────────────────────────────────┘
*/

namespace Lm.Eic.App.Mes.ViewModel.Daily
{
    internal abstract class DailyBase : VMbase, IDailyBase
    {
        public DailyBase()
        {
            Daily.Detailed.Date = DateTime.Now;
            this.Daily.Detailed.SetHours = 12; //
            this.Daily.Detailed.InputHours = 12; //
            this.Daily.Detailed.AttendanceHours = 11; //
            this.Daily.Detailed.WorkHours = 10;
            this.Daily.Detailed.NotWorkHours = 0;
            this.Daily.Detailed.MouldChangeCount = 0;
            this.Daily.Detailed.QtyNG = 0;
        }

        #region Global Variable

        private ZhuiFengLib.VvmBtoB myTack = new VvmBtoB();
        public VvmBtoB MyTask { get { return myTack; } }

        private Business.Daily.Daily daily = new Business.Daily.Daily();

        /// <summary>
        /// Model
        /// </summary>
        public Business.Daily.Daily Daily
        {
            get { return daily; }
            set
            {
                daily = value;
                this.RaisePropertyChanged("Model");
            }
        }

        private Model.BPM_Daily selectDaily;

        /// <summary>
        ///
        /// </summary>
        public Model.BPM_Daily SelectDaily
        {
            get { return selectDaily; }
            set
            {
                selectDaily = value;
                this.RaisePropertyChanged(nameof(SelectDaily));
            }
        }

        private Hr_User dailyUser = new Hr_User();

        /// <summary>
        /// 日报人员
        /// </summary>
        public Hr_User DailyUser
        {
            get { return dailyUser; }
            set
            {
                dailyUser = value;
                this.RaisePropertyChanged("DailyUser");
            }
        }

        private Order order = new Order();

        /// <summary>
        /// 工单
        /// </summary>
        public Order Order
        {
            get { return order; }
            set
            {
                order = value;
                this.RaisePropertyChanged("Order");
            }
        }

        private Process process = new Process();

        /// <summary>
        /// 工序
        /// </summary>
        public Process Process
        {
            get { return process; }
            set
            {
                process = value;
                this.RaisePropertyChanged("Process");
            }
        }

        private ProcessTemplate processTemplate = new ProcessTemplate();

        /// <summary>
        /// 工序模板
        /// </summary>
        public ProcessTemplate ProcessTemplate
        {
            get { return processTemplate; }
            set
            {
                processTemplate = value;
                this.RaisePropertyChanged(nameof(ProcessTemplate));
            }
        }

        private BPM_ProductTemplate bpmProcessTemplate = new BPM_ProductTemplate();

        /// <summary>
        /// Model工序模板
        /// </summary>
        public BPM_ProductTemplate BpmProcessTemplate
        {
            get { return bpmProcessTemplate; }
            set
            {
                bpmProcessTemplate = value;
                this.RaisePropertyChanged("BpmProcessTemplate");
                if (BpmProcessTemplate != null)
                {
                    Daily.Detailed.ProcessID = BpmProcessTemplate.ProcessID;
                    Daily.Detailed.ProcessName = bpmProcessTemplate.ProcessName;
                    Daily.Detailed.ProcessNum = bpmProcessTemplate.Num;
                    Daily.Detailed.ProcessSign = bpmProcessTemplate.ProcessSign;
                  
                }
            }
        }

        private Wip wip = new Wip();

        /// <summary>
        /// WIP
        /// </summary>
        public Wip Wip
        {
            get { return wip; }
            set
            {
                wip = value;
                this.RaisePropertyChanged("Wip");
            }
        }

        private Equipment equipment = new Equipment();

        /// <summary>
        /// 机台
        /// </summary>
        public Equipment Equipment
        {
            get { return equipment; }
            set
            {
                equipment = value;
                this.RaisePropertyChanged("Equipment");
            }
        }

        #endregion Global Variable

        #region Input Parameters


        private Visibility isVisibilityEfficiency = Visibility.Hidden;
        /// <summary>
        /// 是否显示效率输入栏
        /// </summary>
        public Visibility IsVisibilityEfficiency
        {
            get { return isVisibilityEfficiency; }
            set
            {
                isVisibilityEfficiency = value;
                this.RaisePropertyChanged("IsVisibilityEfficiency");
            }
        }


        private string department = string.Empty;

        /// <summary>
        /// 设置部门
        /// </summary>
        public string Detartment
        {
            get { return department; }
            set
            {
                department = value;
                this.RaisePropertyChanged(nameof(Detartment));
                ProcessList = new Orm<BPM_Process>.ModelList_obs(Business.Operation.BpmHeper.Process.GetModelList(m => m.Department == value));
                ProcessTemplateList = new Orm<BPM_ProductTemplate>.ModelList_obs(Business.Operation.BpmHeper.ProcessTemplate.GetModelList(m => m.Department == "制七课"));
                UserList = new Orm<HR_User>.ModelList_obs(Business.Operation.HrHelper.User.GetModelList(m => m.Department == value));
                WorkShopList = Business.Operation.ConfigHelper.CommonParaSet.GetValueList(value);
            }
        }

        /// <summary>
        ///  机台编号
        /// </summary>
        virtual public string AssetNum
        {
            get { return Daily.Detailed.AssetNum; }
            set
            {
                Daily.Detailed.AssetNum = value;
                this.RaisePropertyChanged("AssetNum");
                if (!value.IsNullOrEmpty())
                {
                    Equipment = new Equipment(value);
                    if (!equipment.IsNull)
                    {
                        this.daily.Detailed.AssetName = equipment.Detailed.AssetName;
                    }
                }
            }
        }

        /// <summary>
        /// 工号
        /// </summary>
        public string Job_Num
        {
            get { return Daily.Detailed.Job_Num; }
            set
            {
                Daily.Detailed.Job_Num = value;
                this.RaisePropertyChanged("Job_Num");
                if (!value.IsNullOrEmpty())
                {
                   // DailyUser = new Hr_User(value);
                    if (value.IsNumber()) //如果输入的是工号 通过工号查找
                        DailyUser.Detailed = UserList.FirstOrDefault(m => m.Job_Num == value);
                    else
                    {
                        DailyUser.Detailed = UserList.FirstOrDefault(m => m.Name == value);
                        if (!DailyUser.IsNull) Job_Num = DailyUser.Detailed.Job_Num;
                    }
                    if (DailyUser.IsNull)
                        msg.MessageInfo("未找到此员工的任何信息！");
                    else
                    {
                        Daily.Detailed.Name = dailyUser.Detailed.Name;
                        UserDailyList = new Obs<BPM_Daily>(AllDailyList.Where(m => m.Job_Num == dailyUser.Detailed.Job_Num).ToList());
                    }
                }
                this.RaisePropertyChanged(nameof(DailyUser)); //刷新人员信息
            }
        }

        /// <summary>
        /// 师傅工号
        /// </summary>
        public string MasterName
        {
            get { return Daily.Detailed.MasterName; }
            set
            {
                Daily.Detailed.MasterName = value;
                this.RaisePropertyChanged("MasterName");
                //如果机台不为空 且机台师傅不为输入的师傅 更新机台师傅
                if (!Equipment.IsNull && Equipment?.Detailed?.MasterName != value)
                {
                    Equipment.Detailed.MasterName = value;
                    Equipment.Update();
                }
            }
        }

        /// <summary>
        /// 工单单号
        /// </summary>
        virtual public string OrderID
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
                        Daily.Detailed.ProductID = order.Detailed.ProductID;
                        Daily.Detailed.ProductName = order.Detailed.ProductName;
                        Daily.Detailed.Spec = order.Detailed.Spec;
                        Daily.Detailed.OrderCount = order.Detailed.Count;
                        Daily.Detailed.State = order.Detailed.State;
                        GetOrderProcessList();
                        //是否显示效率输入框
                        IsVisibilityEfficiency = order.Detailed.ProductName.Equals("无工单") ? Visibility.Visible : Visibility.Hidden;
                    }
                }
            }
        }

        /// <summary>
        /// 工序编号
        /// </summary>
        public virtual string ProcessID
        {
            get { return Daily.Detailed.ProcessID; }
            set
            {
                Daily.Detailed.ProcessID = value;
                this.RaisePropertyChanged("ProcessID");
                if (!value.IsNullOrEmpty())
                {
                    Process = new Process(value);
                }
            }
        }

        /// <summary>
        /// 设置时数
        /// </summary>
        public double? SetHours
        {
            get { return Daily.Detailed.SetHours; }
            set
            {
                Daily.Detailed.SetHours = value;
                this.RaisePropertyChanged("SetHours");
            }
        }

        /// <summary>
        /// 出勤时数
        /// </summary>
        public double? AttendanceHours
        {
            get { return Daily.Detailed.AttendanceHours; }
            set
            {
                Daily.Detailed.AttendanceHours = value;
                this.RaisePropertyChanged("AttendanceHours");
            }
        }

        /// <summary>
        /// 投入工时
        /// </summary>
        public int? InputHours
        {
            get { return Daily.Detailed.InputHours; }
            set
            {
                Daily.Detailed.InputHours = value; this.RaisePropertyChanged("InputHours");
            }
        }


        /// <summary>
        /// 效率 当对效率进行赋值时 计算标准工时
        /// </summary>
        public double? Efficiency
        {
            get { return Daily.Detailed.Efficiency; }
            set
            {
                Daily.Detailed.Efficiency = value;
               
                var temStandartHours = (value * WorkHours * 3600) / QtyOk;
                Process.Detailed.StandardHours = Math.Round(Convert.ToDouble( temStandartHours), 2);
                this.RaisePropertyChanged(nameof(Efficiency));
                this.RaisePropertyChanged(nameof(Process));
            }
        }


        /// <summary>
        /// 入库数量
        /// </summary>
        public int? InputStorageCount
        {
            get { return this.Daily.Detailed.InputStorageCount; }
            set
            {
                this.Daily.Detailed.InputStorageCount = value;
                this.RaisePropertyChanged("InputStorageCount");
            }
        }

        /// <summary>
        /// 良品数量
        /// </summary>
        public virtual int? QtyOk
        {
            get { return Daily.Detailed.QtyOK; }
            set
            {
                this.Daily.Detailed.QtyOK = value;
                this.RaisePropertyChanged("QtyOK");
            }
        }

        /// <summary>
        /// 不良品数量
        /// </summary>
        public int? QtyNg
        {
            get { return this.Daily.Detailed.QtyNG; }
            set
            {
                this.Daily.Detailed.QtyNG = value;
                this.RaisePropertyChanged("QtyNg");
            }
        }

        /// <summary>
        /// 生产工时
        /// </summary>
        public double? WorkHours
        {
            get { return this.Daily.Detailed.WorkHours; }
            set
            {
                this.Daily.Detailed.WorkHours = value;
                //if (value != null)
                //{
                //    if (VF_Efficiency() == false) WorksHours = null;
                //}
                this.RaisePropertyChanged("WorksHours");
            }
        }

        /// <summary>
        /// 非生产工时
        /// </summary>
        public double? NotWorkHours
        {
            get { return this.Daily.Detailed.NotWorkHours; }
            set
            {
                this.Daily.Detailed.NotWorkHours = value;
                this.RaisePropertyChanged("NotWorkHours");
            }
        }

        /// <summary>
        /// 非产原因
        /// </summary>
        public string NotWorkCause
        {
            get { return this.daily.Detailed.NotWorkCause; }
            set
            {
                this.daily.Detailed.NotWorkCause = value;
                this.RaisePropertyChanged("NotWorkCause");
            }
        }

        /// <summary>
        /// 换模次数
        /// </summary>
        public int? MouldChangeCount
        {
            get { return this.Daily.Detailed.MouldChangeCount; }
            set
            {
                this.Daily.Detailed.MouldChangeCount = value;
                this.RaisePropertyChanged("MouldChangeCount");
            }
        }

        /// <summary>
        /// 日报日期
        /// </summary>
        public DateTime? DailyDate
        {
            get { return Daily.Detailed.Date; }
            set
            {
                Daily.Detailed.Date = value;
                Daily.Detailed.Month = Daily.Detailed.Date.Value.ToString("yyyyMM");
                this.Daily.Detailed.DateTime = DateTime.Now.Date;
                this.RaisePropertyChanged("DailyDate");
            }
        }

        private BPM_Daily selectDailyUser = new BPM_Daily();

        /// <summary>
        ///
        /// </summary>
         public BPM_Daily SelectDailyUser
        {
            get { return selectDailyUser; }
            set
            {
                selectDailyUser = value;
                this.RaisePropertyChanged("SelectDailyUser");
                if (selectDailyUser != null)
                {
                    Job_Num = selectDailyUser.Job_Num;
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
      virtual  public BPM_Process SelectProcess
        {
            set
            {
                if (value?.ProcessID?.IsNullOrEmpty() == false)
                {
                    QtyOk = QtyOk;
                    Daily.Detailed.ProcessID = value.ProcessID.Replace($"{Order.Detailed?.ProductName?.Replace("-", "")}-", "");
                    ProcessID = value.ProcessID.Replace($"{Order.Detailed?.ProductName?.Replace("-", "")}-", "");
                }
                this.RaisePropertyChanged(nameof(SelectProcess));
            }
        }

        #endregion Input Parameters

        #region ObservableCollection

        private List<string> workShopList = new List<string>();

        /// <summary>
        /// 车间列表
        /// </summary>
        public virtual List<string> WorkShopList
        {
            get { return workShopList; }
            set
            {
                workShopList = value;
                this.RaisePropertyChanged(nameof(WorkShopList));
            }
        }

        /// <summary>
        /// 班别列表
        /// </summary>
        public List<string> ClassType => Business.Operation.ConfigHelper.CommonParaSet.GetValueList("班别");

        /// <summary>
        /// 当前选择用户的所有日报列表
        /// </summary>
        public Orm<BPM_Daily>.ModelList_obs AllDailyList { get; set; } = new Orm<BPM_Daily>.ModelList_obs();

        private Orm<BPM_Daily>.ModelList_obs totalDailyInfoList = new Orm<BPM_Daily>.ModelList_obs();

        /// <summary>
        /// 汇总后的日报信息 按工单，人员....
        /// </summary>
        public Orm<BPM_Daily>.ModelList_obs TotalDailyInfoList
        {
            get { return totalDailyInfoList; }
            set
            {
                totalDailyInfoList = value;
                this.RaisePropertyChanged("TotalDailyInfoList");
            }
        }

        private Obs<BPM_Daily> userDailyList = new Obs<BPM_Daily>();

        /// <summary>
        /// 当前用户的日报列表
        /// </summary>
        public Obs<BPM_Daily> UserDailyList
        {
            get { return userDailyList; }
            set
            {
                userDailyList = value;
                this.RaisePropertyChanged("UserDailyList");
            }
        }

        private Orm<BPM_Daily>.ModelList_obs yetInputDailyUserList = new Orm<BPM_Daily>.ModelList_obs();

        /// <summary>
        /// 已录入日报的用户列表
        /// </summary>
        public Orm<BPM_Daily>.ModelList_obs YetInputDailyUserList
        {
            get { return yetInputDailyUserList; }
            set
            {
                yetInputDailyUserList = value;
                this.RaisePropertyChanged("YetInputDailyUserList");
            }
        }

        private Orm<BPM_Daily>.ModelList_obs yetInputProcessQtySumList = new Orm<BPM_Daily>.ModelList_obs();

        /// <summary>
        /// 已录入的工序的总数量
        /// </summary>
        public Orm<BPM_Daily>.ModelList_obs YetInputProcessQtySumList
        {
            get { return yetInputProcessQtySumList; }
            set
            {
                yetInputProcessQtySumList = value;
                this.RaisePropertyChanged("YetInputProcessQtySumList");
            }
        }

        private Process.ModelList_obs processList = new Orm<BPM_Process>.ModelList_obs();

        /// <summary>
        /// 所有工序列表
        /// </summary>
        public Business.Bpm.Process.ModelList_obs ProcessList
        {
            get { return processList; }
            set
            {
                processList = value;
                this.RaisePropertyChanged(nameof(ProcessList));
            }
        }

        private Orm<BPM_ProductTemplate>.ModelList_obs processTemplateList = new Orm<BPM_ProductTemplate>.ModelList_obs();

        /// <summary>
        ///  工序模板列表
        /// </summary>
        public Orm<BPM_ProductTemplate>.ModelList_obs ProcessTemplateList
        {
            get { return processTemplateList; }
            set
            {
                processTemplateList = value;
                this.RaisePropertyChanged("ProcessTemplateList");
            }
        }

        private Hr_User.ModelList_obs userList = new Orm<HR_User>.ModelList_obs();

        /// <summary>
        /// 所有用户列表
        /// </summary>
        public Hr_User.ModelList_obs UserList
        {
            get { return userList; }
            set
            {
                userList = value;
                this.RaisePropertyChanged(nameof(UserList));
            }
        }

        private Orm<Model.BPM_Process>.ModelList_obs orderProcessList = new Orm<BPM_Process>.ModelList_obs();

        /// <summary>
        ///  工单中工序列表
        /// </summary>
        public Orm<Model.BPM_Process>.ModelList_obs OrderProcessList
        {
            get { return orderProcessList; }
            set
            {
                orderProcessList = value;
                this.RaisePropertyChanged(nameof(OrderProcessList));
            }
        }

        #endregion ObservableCollection

        #region Command

        /// <summary>
        /// 添加一个日报到数据库
        /// </summary>
        virtual public RelayCommand AddDilytToDbCommand => new RelayCommand(() =>
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

        /// <summary>
        /// 
        /// </summary>
        public RelayCommand<string> InputQtyOkCommand => new RelayCommand<string>((str) =>
        {
            if (!str.IsInt())
                QtyOk = null;
            else
            {
                QtyOk = Convert.ToInt32(str);
            }

        });



        /// <summary>
        ///
        /// </summary>
        virtual public RelayCommand GetDailyListFoDb => new RelayCommand(() =>
        {
           
            AllDailyList.Clear();
            AllDailyList.Add(Daily.GetModelList(m => m.Department == Detartment && m.WorkShop == Daily.Detailed.WorkShop && m.Date == DailyDate));
            CreateTotalInfo();
           // Daily.Detailed = new BPM_Daily();
        });

        /// <summary>
        /// 导出日报到Excel中
        /// </summary>
        virtual public RelayCommand ExportToExcelCommand => new RelayCommand(() =>
        {
            AllDailyList.ToList().ExportToExcel(true, 1);
        });

        /// <summary>
        /// 删除日报
        /// </summary>
        virtual public RelayCommand DeleteCommand => new RelayCommand(() =>
        {
            if (SelectDaily?.ProcessID?.Length > 0)
            {
                Daily.DelBy(m =>
           m.Department == SelectDaily.Department &&
           m.Date == SelectDaily.Date &&
           m.ClassType == SelectDaily.ClassType &&
           m.OrderID == SelectDaily.OrderID &&
           m.ProcessID == SelectDaily.ProcessID &&
           m.Job_Num == SelectDaily.Job_Num);
                AllDailyList.Remove(SelectDaily);
                CreateTotalInfo();
            }
            else { msg.MessageInfo("请选择需要删除的日报！"); }
        });

        #endregion Command

        #region Private Method

        /// <summary>
        /// 效率验证
        /// </summary>
        /// <returns></returns>
        private bool VF_Efficiency()
        {
            return true;
        }

        abstract public BPM_Daily CreateDaily();

        /// <summary>
        /// 获取工单中工序列表
        /// </summary>
        virtual public void GetOrderProcessList()
        {
            //刷新工序列表
            ProcessList = new Orm<BPM_Process>.ModelList_obs(Business.Operation.BpmHeper.Process.GetModelList(m => m.Department == Detartment));
            var _productName = $"{Order.Detailed?.ProductName?.Replace("-", "")}-"; ;
            this.OrderProcessList = new Orm<BPM_Process>.ModelList_obs(ProcessList.Where(m => m.ProcessID.StartsWith(_productName)).ToList());
        }

        /// <summary>
        /// 生成汇总信息
        /// </summary>
        internal void CreateTotalInfo()
        {
            YetInputDailyUserList.Clear();
            YetInputProcessQtySumList.Clear();
            foreach (var daily in AllDailyList)
            {
                #region 用户汇总 总览表

                if (YetInputDailyUserList.FirstOrDefault(x => x.Job_Num == daily.Job_Num) == null) //如果未找到了该作业元的汇总资料
                {
                    YetInputDailyUserList.Add(new BPM_Daily()
                    {
                        Job_Num = daily.Job_Num,
                        Name = daily.Name,
                        WorkHours = AllDailyList.Where(x => x.Job_Num == daily.Job_Num).Sum(x => x.WorkHours),
                        NotWorkHours = AllDailyList.Where(x => x.Job_Num == daily.Job_Num).Sum(x => x.NotWorkHours),
                        QtyNG = AllDailyList.Where(x => x.Job_Num == daily.Job_Num).Sum(x => x.QtyNG),
                        QtyOK = AllDailyList.Where(x => x.Job_Num == daily.Job_Num).Sum(x => x.QtyOK),
                        Efficiency = Convert.ToDouble((AllDailyList.Where(x => x.Job_Num == daily.Job_Num).Sum(x => x.TotalWorkHoursNotRelax) / AllDailyList.Where(x => x.Job_Num == daily.Job_Num).Sum(x => x.WorkHours)).Value.ToString("F2"))
                    });
                }

                #endregion 用户汇总 总览表

                #region 工序汇总 总览表

                if (YetInputProcessQtySumList.FirstOrDefault(p => p.ProcessID == daily.ProcessID) == null)
                {
                    YetInputProcessQtySumList.Add(new BPM_Daily()
                    {
                        ProcessID = daily.ProcessID,
                        ProcessName = daily.ProcessName,
                        Qty = AllDailyList.Where(x => x.ProcessID == daily.ProcessID).Sum(x => x.Qty),
                        WorkHours = AllDailyList.Where(x => x.ProcessID == daily.ProcessID).Sum(x => x.WorkHours)
                    });
                }

                #endregion 工序汇总 总览表

                #region 计算 按 工单 人员 工序 进行分组的信息

                if (TotalDailyInfoList.FirstOrDefault(p => p.OrderID == daily.OrderID && p.Job_Num == daily.Job_Num && p.ProcessID == daily.ProcessID) == null)
                {
                    var temdaily = ExList.ModelCopy(daily);
                    temdaily.Qty = AllDailyList.Where(x => (x.OrderID == daily.OrderID) && x.Job_Num == daily.Job_Num && x.ProcessID == daily.ProcessID).Sum(x => x.Qty);
                    temdaily.QtyOK = AllDailyList.Where(x => (x.OrderID == daily.OrderID) && x.Job_Num == daily.Job_Num && x.ProcessID == daily.ProcessID).Sum(x => x.QtyOK);
                    temdaily.QtyNG = AllDailyList.Where(x => (x.OrderID == daily.OrderID) && x.Job_Num == daily.Job_Num && x.ProcessID == daily.ProcessID).Sum(x => x.QtyNG);
                    temdaily.WorkHours = AllDailyList.Where(x => (x.OrderID == daily.OrderID) && x.Job_Num == daily.Job_Num && x.ProcessID == daily.ProcessID).Sum(x => x.WorkHours);
                    temdaily.NotWorkHours = AllDailyList.Where(x => (x.OrderID == daily.OrderID) && x.Job_Num == daily.Job_Num && x.ProcessID == daily.ProcessID).Sum(x => x.NotWorkHours);
                    TotalDailyInfoList.Add(temdaily);
                }

                #endregion 计算 按 工单 人员 工序 进行分组的信息
            }
            UserDailyList = new Obs<BPM_Daily>(AllDailyList.Where(m => m.Job_Num == dailyUser.Detailed.Job_Num).ToList());
        }

        #endregion Private Method
    }
}