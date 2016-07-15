using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Lm.Eic.App.Mes.Window
{
    /// <summary>
    /// 系统登陆 ViewModel
    /// </summary>
    internal class LandViewModel : ViewModelBase
    {
        public LandViewModel(Action closeAction)
        {
            this.closeAction = closeAction;
        }

        /// <summary>
        /// 窗体关闭方法
        /// </summary>
        private Action closeAction;

        private Model.HR_User user = new Model.HR_User();

        /// <summary>
        /// 用户
        /// </summary>
        public Model.HR_User User
        {
            get { return user; }
            set
            {
                user = value;
                this.RaisePropertyChanged("User");
            }
        }

        private string tipinfo;

        public string TipInfo
        {
            get { return tipinfo; }
            set
            {
                tipinfo = value;
                this.RaisePropertyChanged("TipInfo");
            }
        }

        /// <summary>
        /// 登陆
        /// </summary>
        private void LogCommand()
        {
            try
            {
                if (Business.Operation.HrHelper.User.VerifyUser(User))
                {
                    MainWindow mainFrom = new MainWindow();
                    mainFrom.Show();
                    this.closeAction.Invoke();
                }
                else
                    TipInfo = "用户名或密码错误！";
            }
            catch (Exception ex) { ZhuiFengLib.Message.Message.MessageInfo(ex.Message); }
        }

        #region CloseBtn

        /// <summary>
        /// 关闭窗体命令
        /// </summary>
        public RelayCommand Close
        {
            get { return new RelayCommand(() => { this.closeAction.Invoke(); }); }
        }

        /// <summary>
        /// 鼠标移入处理
        /// </summary>
        public ICommand Close_MouseLeave
        {
            get { return new RelayCommand<Label>(Close_mouse); }
        }

        /// <summary>
        /// 鼠标按下处理
        /// </summary>
        public ICommand Close_MouseEnter
        {
            get { return new RelayCommand<Label>(Close_mouseEnter); }
        }

        private void Close_mouse(Label tem)
        {
            try
            {
                //pack://application:,,,/你的dll名称;component/文件夹/1.jpg
                Uri uri = new Uri("pack://application:,,,/Lm.Eic.App.Mes.Resources;Component/Images/cancel.png", UriKind.RelativeOrAbsolute);
                ImageBrush berriesBrush = new ImageBrush();
                berriesBrush.ImageSource = new BitmapImage(uri);

                tem.Background = berriesBrush;
            }
            catch (Exception ef)
            {
                MessageBox.Show("出现错误！：" + ef.ToString());
            }
        }

        private void Close_mouseEnter(Label tem)
        {
            try
            {
                //pack://application:,,,/你的dll名称;component/文件夹/1.jpg
                Uri uri = new Uri("pack://application:,,,/Lm.Eic.App.Mes.Resources;Component/Images/cancel_1.png", UriKind.RelativeOrAbsolute);
                ImageBrush berriesBrush = new ImageBrush();
                berriesBrush.ImageSource = new BitmapImage(uri);

                tem.Background = berriesBrush;
            }
            catch (Exception ef)
            {
                MessageBox.Show("出现错误！：" + ef.ToString());
            }
        }

        #endregion CloseBtn

        #region LoginBtn

        /// <summary>
        /// 登陆按钮 鼠标移入处理
        /// </summary>
        public ICommand Login_MouseLeave
        {
            get { return new RelayCommand<Button>(Login_Mouse); }
        }

        /// <summary>
        /// 登陆按钮 鼠标按下处理
        /// </summary>
        public ICommand Login_MouseEnter
        {
            get { return new RelayCommand<Button>(login_MouseEnter); }
        }

        private void Login_Mouse(Button btn)
        {
            Label lb1 = (Label)btn.Template.FindName("tips_for_login", btn);
            lb1.Foreground = new SolidColorBrush(Colors.White);
        }

        private void login_MouseEnter(Button btn)
        {
            Label lb1 = (Label)btn.Template.FindName("tips_for_login", btn);
            lb1.Foreground = new SolidColorBrush(Colors.Red);
        }

        #endregion LoginBtn

        #region KeyEnter

        public ICommand PasswordKeyCommand
        {
            get { return new RelayCommand<PasswordBox>((pbr) => { user.Password = pbr.Password; LogCommand(); }); }
        }

        public ICommand UserKeyCommand
        {
            get { return new RelayCommand<PasswordBox>((pbr) => { pbr.Focus(); }); }
        }

        #endregion KeyEnter
    }
}