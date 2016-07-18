using System.Windows.Controls;
using System.Windows.Media;

namespace Lm.Eic.App.Mes.View.Oqc
{
    /// <summary>
    /// PackInspection.xaml 的交互逻辑
    /// </summary>
    public partial class PackInspection : UserControl
    {
        public PackInspection()
        {
            InitializeComponent();
            var vm = new Mes.ViewModel.Oqc.Bagging.PackInspect();
            vm.MyTask.MyTask += MyTast;
            this.DataContext = vm;
        }

        public void MyTast(string str)
        {
            if (str == "OK")
            {
                txb_result.Foreground = new SolidColorBrush(Color.FromRgb(46, 172, 23)); //定义纯色绘制 变量
                txb_result.Text = "PASS";
            }
            if (str == "NG")
            {
                txb_result.Foreground = Brushes.Red;
                txb_result.Text = "FAIL";
            }
            if(str == "Barcode获取焦点")
            {
                txb_Barcode.Focus();
                txb_Barcode.SelectAll();
            }
          
            
        }
    }
}