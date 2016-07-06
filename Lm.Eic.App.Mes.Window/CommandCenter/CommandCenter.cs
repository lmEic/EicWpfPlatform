using Xceed.Wpf.AvalonDock.Layout;

namespace Lm.Eic.App.Mes.Window
{
    /// <summary>
    /// 指挥中心
    /// </summary>
    public class CommandCenter
    {
        private LayoutDocumentPane MainDocumentPane;

        public CommandCenter(LayoutDocumentPane mainDocumentPane)
        {
            this.MainDocumentPane = mainDocumentPane;
            //注册消息 进行界面显示调度
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<LayoutDocument>(this, (page) => { MainDocumentPane.Children.Add(page); });

            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<System.Windows.Window>(this, (page) => { page.ShowDialog(); });
        }
    }
}