namespace Lm.Eic.App.Mes.Window
{
    /// <summary>
    /// Land.xaml 的交互逻辑
    /// </summary>
    public partial class Land : System.Windows.Window
    {
        public Land()
        {
            InitializeComponent();
            this.DataContext = new LandViewModel(this.Close);
        }
    }
}