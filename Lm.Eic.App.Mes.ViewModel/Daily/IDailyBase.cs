using GalaSoft.MvvmLight.Command;
using Lm.Eic.App.Mes.Business;
using Lm.Eic.App.Mes.Business.Ast;
using Lm.Eic.App.Mes.Business.Bpm;
using Lm.Eic.App.Mes.Business.Hr;
using Lm.Eic.App.Mes.Model;
using System;
using System.Collections.Generic;
using ZhuiFengLib;

namespace Lm.Eic.App.Mes.ViewModel.Daily
{
    public interface IDailyBase
    {
        RelayCommand AddDilytToDbCommand { get; }
        Orm<BPM_Daily>.ModelList_obs AllDailyList { get; set; }
        string AssetNum { get; set; }
        double? AttendanceHours { get; set; }
        BPM_ProductTemplate BpmProcessTemplate { get; set; }
        List<string> ClassType { get; }
        Business.Daily.Daily Daily { get; set; }
        DateTime? DailyDate { get; set; }
        Hr_User DailyUser { get; set; }
        Equipment Equipment { get; set; }
        RelayCommand ExportToExcelCommand { get; }
        RelayCommand GetDailyListFoDb { get; }
        int? InputHours { get; set; }
        int? InputStorageCount { get; set; }
        string Job_Num { get; set; }
        int? MouldChangeCount { get; set; }
        VvmBtoB MyTask { get; }
        string NotWorkCause { get; set; }
        double? NotWorkHours { get; set; }
        Order Order { get; set; }
        string OrderID { get; set; }
        Process Process { get; set; }
        string ProcessID { get; set; }
        Orm<BPM_Process>.ModelList_obs ProcessList { get; set; }
        ProcessTemplate ProcessTemplate { get; set; }
        Orm<BPM_ProductTemplate>.ModelList_obs ProcessTemplateList { get; set; }
        int? QtyNg { get; set; }
        int? QtyOk { get; set; }
        BPM_Daily SelectDailyUser { get; set; }
        double? SetHours { get; set; }
        Orm<BPM_Daily>.ModelList_obs TotalDailyInfoList { get; set; }
        Obs<BPM_Daily> UserDailyList { get; set; }
        Wip Wip { get; set; }
        double? WorkHours { get; set; }
        List<string> WorkShopList { get; }
        Orm<BPM_Daily>.ModelList_obs YetInputDailyUserList { get; set; }
        Orm<BPM_Daily>.ModelList_obs YetInputProcessQtySumList { get; set; }

        BPM_Daily CreateDaily();
    }
}