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
        Orm<Bpm_Daily>.ModelList_obs AllDailyList { get; set; }
        string AssetNum { get; set; }
        double? AttendanceHours { get; set; }
        Bpm_ProcessTemplate BpmProcessTemplate { get; set; }
        List<string> ClassType { get; }
        Business.Daily.Daily Daily { get; set; }
        DateTime? DailyDate { get; set; }
        Hr_User DailyUser { get; set; }
        Equipment Equipment { get; set; }
        RelayCommand ExportToExcelCommand { get; }
        RelayCommand GetDailyListFoDb { get; }
        double? InputHours { get; set; }
        double? InputStorageCount { get; set; }
        string JobNum { get; set; }
        int? MouldChangeCount { get; set; }
        VvmBtoB MyTask { get; }
        string NotWorkCause { get; set; }
        double? NotWorkHours { get; set; }
        Order Order { get; set; }
        string OrderID { get; set; }
        Process Process { get; set; }
        string ProcessID { get; set; }
        Orm<Bpm_Process>.ModelList_obs ProcessList { get; set; }
        ProcessTemplate ProcessTemplate { get; set; }
        Orm<Bpm_ProcessTemplate>.ModelList_obs ProcessTemplateList { get; set; }
        int? QtyNg { get; set; }
        int? QtyOk { get; set; }
        Bpm_Daily SelectDailyUser { get; set; }
        double? SetHours { get; set; }
        Orm<Bpm_Daily>.ModelList_obs TotalDailyInfoList { get; set; }
        Obs<Bpm_Daily> UserDailyList { get; set; }
        Wip Wip { get; set; }
        double? WorkHours { get; set; }
        List<string> WorkShopList { get; }
        Orm<Bpm_Daily>.ModelList_obs YetInputDailyUserList { get; set; }
        Orm<Bpm_Daily>.ModelList_obs YetInputProcessQtySumList { get; set; }

        Bpm_Daily CreateDaily();
    }
}