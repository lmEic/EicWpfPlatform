using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Lm.Eic.App.Mes.View
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //View注册
            SimpleIoc.Default.Register<View.Bpm.ProductSet>();
            SimpleIoc.Default.Register<View.Bpm.OrderSet.OrderSet>();
            SimpleIoc.Default.Register<View.Bpm.ProcessSet>();
            SimpleIoc.Default.Register<View.Bpm.ProductSet>();
            SimpleIoc.Default.Register<View.Config.CommonParaSet>();
            SimpleIoc.Default.Register<View.Daily.DailyInput>();
            SimpleIoc.Default.Register<View.Daily.DailyReport>();
            SimpleIoc.Default.Register<View.Hr.AddUser>();
            //  SimpleIoc.Default.Register<View.Oqc.PackInspection>();

            //ViewModel注册
           
            SimpleIoc.Default.Register<Mes.ViewModel.Daily.DailyDirector>();
            SimpleIoc.Default.Register<Mes.ViewModel.Config.CommonParaSet>();
            //  SimpleIoc.Default.Register<Mes.ViewModel.Bpm.OrderSet.OrderSetDirector>();
            SimpleIoc.Default.Register<Mes.ViewModel.Bpm.ProcessSet>();
            SimpleIoc.Default.Register<Mes.ViewModel.Bpm.ProductSet>();
            // SimpleIoc.Default.Register<Mes.ViewModel.Oqc.PackInspect>();
        }

        #region View

        public static View.Bpm.ProductSet ProductSetView => ServiceLocator.Current.GetInstance<View.Bpm.ProductSet>();

        //  public static View.Oqc.PackInspection PackInspectionView => ServiceLocator.Current.GetInstance<View.Oqc.PackInspection>();
        public static View.Bpm.ProcessSet ProcessSetView => ServiceLocator.Current.GetInstance<View.Bpm.ProcessSet>();

        public static View.Bpm.OrderSet.OrderSet OrderSetView => ServiceLocator.Current.GetInstance<View.Bpm.OrderSet.OrderSet>();
        public static View.Config.CommonParaSet CommonPataSetView => ServiceLocator.Current.GetInstance<View.Config.CommonParaSet>();
        public static View.Daily.DailyInput DailyInputView => ServiceLocator.Current.GetInstance<View.Daily.DailyInput>();
        public static View.Daily.DailyReport DailyReportView => ServiceLocator.Current.GetInstance<View.Daily.DailyReport>();
        public static View.Hr.AddUser AddUser => ServiceLocator.Current.GetInstance<View.Hr.AddUser>();

        #endregion View

        #region ViewModel

      

        public Mes.ViewModel.Daily.DailyDirector DailyInputViewModel => ServiceLocator.Current.GetInstance<Mes.ViewModel.Daily.DailyDirector>();

        public Mes.ViewModel.Config.CommonParaSet CommonParaSetViewModel => ServiceLocator.Current.GetInstance<Mes.ViewModel.Config.CommonParaSet>();

        // public Mes.ViewModel.Bpm.OrderSet.OrderSetDirector OrderSetViewModel => ServiceLocator.Current.GetInstance<Mes.ViewModel.Bpm.OrderSet.OrderSetDirector>();

        public Mes.ViewModel.Bpm.ProcessSet ProcessSetViewModel => ServiceLocator.Current.GetInstance<Mes.ViewModel.Bpm.ProcessSet>();

        public Mes.ViewModel.Bpm.ProductSet ProductSetViewModel => ServiceLocator.Current.GetInstance<Mes.ViewModel.Bpm.ProductSet>();

        //  public Mes.ViewModel.Oqc.PackInspect PackInspect => ServiceLocator.Current.GetInstance<Mes.ViewModel.Oqc.PackInspect>();

        #endregion ViewModel

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
