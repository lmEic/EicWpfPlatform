using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Xceed.Wpf.AvalonDock.Layout;

namespace Lm.Eic.App.Mes.Window
{
    /// <summary>
    /// 主菜单
    /// </summary>
    public class PrimaryMenu
    {
        private static BpmMenu bpmMenu;

        /// <summary>
        ///  过程管控菜单
        /// </summary>
        public static BpmMenu BpmMenu => bpmMenu = bpmMenu == null ? new BpmMenu() : bpmMenu;

        private static HrMenu hrMenu;

        /// <summary>
        /// 人事管理菜单
        /// </summary>
        public static HrMenu HrMenu => hrMenu = hrMenu == null ? new HrMenu() : hrMenu;

        private static OqcMenu oqcMenu;

        /// <summary>
        ///
        /// </summary>
        public static OqcMenu OqcMenu => oqcMenu = oqcMenu == null ? new OqcMenu() : oqcMenu;

        static AstMenu astMenu;
        /// <summary>
        /// 
        /// </summary>
        public static AstMenu AstMenu => astMenu = astMenu == null ? new AstMenu() : astMenu;

    }


    public class AstMenu
    {
        /// <summary>
        /// 日报整理
        /// </summary>
        public RelayCommand ShowEquipmentCommand => new RelayCommand(() =>
        {
            Messenger.Default.Send(new LayoutDocument()
            {
                Title = "设备管理",
                IsActive = true,
                Content = new View.Ast.Equipment()
            });
        });
    }

    /// <summary>
    /// 过程管控菜单
    /// </summary>
    public class BpmMenu
    {
        #region 日报

        /// <summary>
        /// 日报整理
        /// </summary>
        public RelayCommand ShowDailyReportCommand => new RelayCommand(() =>
        {
            Messenger.Default.Send(new LayoutDocument()
            {
                Title = "日报整理",
                IsActive = true,
                Content = ViewModel.ViewModelLocator.DailyReportView
            });
        });

        /// <summary>
        /// 日报整理
        /// </summary>
        public RelayCommand ShowDailyInputCommand => new RelayCommand(() =>
        {
            Messenger.Default.Send(new LayoutDocument()
            {
                Title = "日报录入",
                IsActive = true,
                Content = ViewModel.ViewModelLocator.DailyInputView
            });
        });

        #endregion 日报
    }

    /// <summary>
    /// 人事管理
    /// </summary>
    public class HrMenu
    {
        #region user

        /// <summary>
        /// 人员新增
        /// </summary>
        public RelayCommand ShowAddUserCommand => new RelayCommand(() =>
        {
            Messenger.Default.Send((System.Windows.Window)ViewModel.ViewModelLocator.AddUser);
        });

        /// <summary>
        /// 员工管理
        /// </summary>
        public RelayCommand ShowMasterUserCommand => new RelayCommand(() =>
        {
            Messenger.Default.Send(new LayoutDocument()
            {
                Title = "员工管理",
                IsActive = true,
                // Content = ViewModel.ViewModelLocator.PackInspectionView
                Content = ViewModel.ViewModelLocator.MasterUserView
            });
        });

        #endregion user
    }

    public class OqcMenu
    {
        /// <summary>
        /// 显示出货检测与打印
        /// </summary>
        public RelayCommand ShowPackInspectionCommand => new RelayCommand(() =>
        {
            Messenger.Default.Send(new LayoutDocument()
            {
                Title = "出货检测与打印",
                IsActive = true,
                // Content = ViewModel.ViewModelLocator.PackInspectionView
                Content = new View.Oqc.PackInspection()
            });
        });

        #region 工序与产品

        /// <summary>
        /// 工序管理
        /// </summary>
        public RelayCommand ShowProcessSetCommand => new RelayCommand(() =>
        {
            Messenger.Default.Send(new LayoutDocument()
            {
                Title = "工序管理",
                IsActive = true,
                Content = ViewModel.ViewModelLocator.ProcessSetView
            });
        });

        /// <summary>
        /// 产品管理
        /// </summary>
        public RelayCommand ShowProductSetCommand => new RelayCommand(() =>
        {
            Messenger.Default.Send(new LayoutDocument()
            {
                Title = "产品管理",
                IsActive = true,
                Content = ViewModel.ViewModelLocator.ProductSetView
            });
        });

        /// <summary>
        /// 产品管理
        /// </summary>
        public RelayCommand ShowProcessTemplateSetCommand => new RelayCommand(() =>
        {
            Messenger.Default.Send(new LayoutDocument()
            {
                Title = "模板管理",
                IsActive = true,
                Content = ViewModel.ViewModelLocator.ProcessTemplateSetView
            });
        });

        /// <summary>
        /// 工单设置
        /// </summary>
        public RelayCommand ShowOrderSetCommand => new RelayCommand(() =>
        {
            Messenger.Default.Send(new LayoutDocument()
            {
                Title = "工单设置",
                IsActive = true,
                Content = ViewModel.ViewModelLocator.OrderSetView
            });
        });

        #endregion 工序与产品
    }
}