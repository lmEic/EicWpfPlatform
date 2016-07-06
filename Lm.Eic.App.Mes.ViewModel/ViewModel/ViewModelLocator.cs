/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Lm.Eic.App.Mes.ViewModel"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Lm.Eic.App.Mes.ViewModel.ViewModel
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

           

            //ViewModel×¢²á
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<Mes.ViewModel.Daily.DailyDirector>();
            SimpleIoc.Default.Register<Mes.ViewModel.Config.CommonParaSet>();
            //  SimpleIoc.Default.Register<Mes.ViewModel.Bpm.OrderSet.OrderSetDirector>();
            SimpleIoc.Default.Register<Mes.ViewModel.Bpm.ProcessSet>();
            SimpleIoc.Default.Register<Mes.ViewModel.Bpm.ProductSet>();
            // SimpleIoc.Default.Register<Mes.ViewModel.Oqc.PackInspect>();
        }

        #region View

       
        #endregion View

        #region ViewModel

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

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