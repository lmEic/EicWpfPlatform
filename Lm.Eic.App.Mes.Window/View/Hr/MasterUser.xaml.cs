using DevExpress.Xpf.LayoutControl;
using System.Windows.Controls;
using ZhuiFengLib.Simulation;

namespace Lm.Eic.App.Mes.View.Hr
{
    /// <summary>
    /// MasterUser.xaml 的交互逻辑
    /// </summary>
    public partial class MasterUser : UserControl
    {
        public MasterUser()
        {
            InitializeComponent();
        }

        private void TextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                Keyboard.Press(System.Windows.Input.Key.Tab);
                if((sender as DataLayoutItem).Name == "layoutItemIsJob")
                {
                    layoutItemJobNum.Focus();
                }
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

        
    }
}
