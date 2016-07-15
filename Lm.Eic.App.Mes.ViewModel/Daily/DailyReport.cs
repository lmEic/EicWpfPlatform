using GalaSoft.MvvmLight.Command;
using Lm.Eic.App.Mes.Model;
using Lm.Eic.App.Mes.Utility.CacheStore;
using Lm.Eic.App.Mes.Utility.Common;
using System;

namespace Lm.Eic.App.Mes.ViewModel.Daily
{
    public class DailyReport : VMbase<BPM_Daily>
    {

        Business.Daily.Reports.IReport m_ExportReport;
        string m_Department;

        public DailyReport() : base(Business.Operation.DailyHelper.Daily)
        {
            m_Department =  LoginUser.UserInfo.Department;
            switch (m_Department)
            {
                case Department.STR_DpOne:
                    m_ExportReport = new Business.Daily.Reports.MsOne();
                    break;
                case Department.STR_MsSeven:
                    m_ExportReport = new Business.Daily.Reports.MsSeven();
                    break;
            }
        }


        private DateTime selectDate = DateTime.Now;
        /// <summary>
        /// 选择的日报日期
        /// </summary>
        public DateTime SelectDate
        {
            get { return selectDate; }
            set
            {
                selectDate = value;
                this.RaisePropertyChanged(nameof(SelectDate));
            }
        }

        /// <summary>
        /// 获取日报列表
        /// </summary>
        public RelayCommand GetDailyList => new RelayCommand(() =>
        {
            ModelList_Obs = BusinessOperation.GetModelList(m => m.Department == m_Department && m.Date == SelectDate);
        });

        /// <summary>
        /// 导出日报到Excel
        /// </summary>
        public RelayCommand ExportReportToExcelCommand => new RelayCommand(() =>
        {
            m_ExportReport.ExportReportToExcel(ModelList_Obs);
        });

        #region NotMethod

        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Seach()
        {
            throw new NotImplementedException();
        }

        public override void ImportForExcel()
        {
            throw new NotImplementedException();
        }

        #endregion NotMethod
    }
}