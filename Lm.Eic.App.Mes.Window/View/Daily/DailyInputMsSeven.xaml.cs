using System.Windows.Controls;

using ZhuiFengLib.Simulation;


namespace Lm.Eic.App.Mes.View.Daily
{
    /// <summary>
    /// DailyInputMsSeven.xaml 的交互逻辑
    /// </summary>
    public partial class DailyInputMsSeven : UserControl
    {
        public DailyInputMsSeven()
        {
            InitializeComponent();
        }

        private void TextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                Keyboard.Press(System.Windows.Input.Key.Tab);
            }
            var uie = e.OriginalSource as System.Windows.UIElement;
            if (e.Key == System.Windows.Input.Key.Up)
            {
                uie.MoveFocus(new System.Windows.Input.TraversalRequest(System.Windows.Input.FocusNavigationDirection.Previous));
                e.Handled = true;
            }
            if (e.Key == System.Windows.Input.Key.Down)
            {
                uie.MoveFocus(new System.Windows.Input.TraversalRequest(System.Windows.Input.FocusNavigationDirection.Next));
                e.Handled = true;
            }
        }

        private void TextBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            var txb = sender as Fluent.TextBox;
            txb.SelectAll();
        }

        internal void TaskControl(string v)
        {
            if (v == "获取焦点")
            {
                txb_AssentNum.Focus();
            }
        }


        //private void Grid_KeyDown(object sender, KeyEventArgs e)
        //{
        //    var uie = e.OriginalSource as UIElement;
        //    if (e.Key == Key.Enter)
        //    {
        //        uie.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        //        e.Handled = true;
        //    }
        //}
    }
}
