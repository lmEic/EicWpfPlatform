using Lm.Eic.App.Mes.Utility.CacheStore;
using Lm.Eic.App.Mes.Utility.Common;
using Microsoft.Practices.ServiceLocation;
using System.Windows;
using System.Windows.Controls;

namespace Lm.Eic.App.Mes.View.Daily
{
    /// <summary>
    /// DailyInput.xaml 的交互逻辑
    /// </summary>
    public partial class DailyInput : UserControl
    {
        public DailyInput()
        {
            this.DataContext = DailyInputViewModel;
            InitializeComponent();
            if ( LoginUser.UserInfo.Department == Department.STR_DpPt)
            {
                var tem = new DailyInputPtOne();
                this.DailyInputViewModel.IDaily.MyTask.MyTask += tem.TaskControl;
                cnt_DailyContent.Content = tem;
            }
            if ( LoginUser.UserInfo.Department == Department.STR_DpOne)
            {
                var tem = new DailyInputMsOne();
                this.DailyInputViewModel.IDaily.MyTask.MyTask += tem.TaskControl;
                cnt_DailyContent.Content = tem;
            }
            if ( LoginUser.UserInfo.Department == Department.STR_MsSeven)
            {
                var tem = new DailyInputMsSeven();
                this.DailyInputViewModel.IDaily.MyTask.MyTask += tem.TaskControl;
                cnt_DailyContent.Content = tem;
            }
            if ( LoginUser.UserInfo.Department == Department.STR_MsThree)  //制三课与制七课共用一个日报录入界面
            {
                var tem = new DailyInputMsSeven();
                this.DailyInputViewModel.IDaily.MyTask.MyTask += tem.TaskControl;
                cnt_DailyContent.Content = tem;
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var tem = sender as TextBox;
            tem.SelectAll();
        }

        public Mes.ViewModel.Daily.DailyDirector DailyInputViewModel => ServiceLocator.Current.GetInstance<Mes.ViewModel.Daily.DailyDirector>();
    }
}