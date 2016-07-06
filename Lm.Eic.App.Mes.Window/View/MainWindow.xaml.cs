namespace Lm.Eic.App.Mes.Window
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Fluent.RibbonWindow
    {
        private CommandCenter cs;

        public MainWindow()
        {
            InitializeComponent();
            cs = new CommandCenter(MainDocumentPane);  //初始化指挥中心
        }
    }
}