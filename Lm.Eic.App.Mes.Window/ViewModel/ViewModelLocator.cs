/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Lm.Eic.App.Mes.Window"
                           x:Key="Locator" />
  </Application.Resources>

  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Lm.Eic.App.Mes.Window.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //View×¢²á
            SimpleIoc.Default.Register<View.Bpm.ProductSet>();
            SimpleIoc.Default.Register<View.Bpm.OrderSet.OrderSet>();
            SimpleIoc.Default.Register<View.Bpm.ProcessSet>();
            SimpleIoc.Default.Register<View.Bpm.ProductSet>();
            SimpleIoc.Default.Register<View.Bpm.ProcessTemplateSet>();
            SimpleIoc.Default.Register<View.Config.CommonParaSet>();
            SimpleIoc.Default.Register<View.Daily.DailyInput>();
            SimpleIoc.Default.Register<View.Daily.DailyReport>();
            SimpleIoc.Default.Register<View.Hr.AddUser>();
            SimpleIoc.Default.Register<View.Hr.MasterUser>();
            //  SimpleIoc.Default.Register<View.Oqc.PackInspection>();

            //ViewModel×¢²á
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<Mes.ViewModel.Daily.DailyDirector>();
            SimpleIoc.Default.Register<Mes.ViewModel.Daily.DailyReport>();
            SimpleIoc.Default.Register<Mes.ViewModel.Config.CommonParaSet>();
            //  SimpleIoc.Default.Register<Mes.ViewModel.Bpm.OrderSet.OrderSetDirector>();
            SimpleIoc.Default.Register<Mes.ViewModel.Bpm.ProcessSet>();
            SimpleIoc.Default.Register<Mes.ViewModel.Bpm.ProductSet>();
            SimpleIoc.Default.Register<Mes.ViewModel.Bpm.ProcessTemplateSet>();
            SimpleIoc.Default.Register<Mes.ViewModel.Hr.MasterUser>();
            
            // SimpleIoc.Default.Register<Mes.ViewModel.Oqc.PackInspect>();
        }

        #region View

        //  public static View.Oqc.PackInspection PackInspectionView => ServiceLocator.Current.GetInstance<View.Oqc.PackInspection>();
        public static View.Bpm.ProcessSet ProcessSetView => ServiceLocator.Current.GetInstance<View.Bpm.ProcessSet>();

        public static View.Bpm.ProductSet ProductSetView => ServiceLocator.Current.GetInstance<View.Bpm.ProductSet>();
        public static View.Bpm.ProcessTemplateSet ProcessTemplateSetView => ServiceLocator.Current.GetInstance<View.Bpm.ProcessTemplateSet>();

        public static View.Bpm.OrderSet.OrderSet OrderSetView => ServiceLocator.Current.GetInstance<View.Bpm.OrderSet.OrderSet>();
        public static View.Config.CommonParaSet CommonPataSetView => ServiceLocator.Current.GetInstance<View.Config.CommonParaSet>();
        public static View.Daily.DailyInput DailyInputView => ServiceLocator.Current.GetInstance<View.Daily.DailyInput>();
        public static View.Daily.DailyReport DailyReportView => ServiceLocator.Current.GetInstance<View.Daily.DailyReport>();
        public static View.Hr.AddUser AddUser => ServiceLocator.Current.GetInstance<View.Hr.AddUser>();

        public static View.Hr.MasterUser MasterUserView => ServiceLocator.Current.GetInstance<View.Hr.MasterUser>();

        #endregion View

        #region ViewModel

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public Mes.ViewModel.Daily.DailyDirector DailyInputViewModel => ServiceLocator.Current.GetInstance<Mes.ViewModel.Daily.DailyDirector>();

        public Mes.ViewModel.Daily.DailyReport DailyReportViewModel => ServiceLocator.Current.GetInstance<Mes.ViewModel.Daily.DailyReport>();

        public Mes.ViewModel.Config.CommonParaSet CommonParaSetViewModel => ServiceLocator.Current.GetInstance<Mes.ViewModel.Config.CommonParaSet>();

        // public Mes.ViewModel.Bpm.OrderSet.OrderSetDirector OrderSetViewModel => ServiceLocator.Current.GetInstance<Mes.ViewModel.Bpm.OrderSet.OrderSetDirector>();

        public Mes.ViewModel.Bpm.ProcessSet ProcessSetViewModel => ServiceLocator.Current.GetInstance<Mes.ViewModel.Bpm.ProcessSet>();

        public Mes.ViewModel.Bpm.ProductSet ProductSetViewModel => ServiceLocator.Current.GetInstance<Mes.ViewModel.Bpm.ProductSet>();

        public Mes.ViewModel.Bpm.ProcessTemplateSet PeocessTemplateSetViewModel => ServiceLocator.Current.GetInstance<Mes.ViewModel.Bpm.ProcessTemplateSet>();

        public Mes.ViewModel.Hr.MasterUser MasterUserViewModel => ServiceLocator.Current.GetInstance<Mes.ViewModel.Hr.MasterUser>();
        //  public Mes.ViewModel.Oqc.PackInspect PackInspect => ServiceLocator.Current.GetInstance<Mes.ViewModel.Oqc.PackInspect>();

        #endregion ViewModel

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}