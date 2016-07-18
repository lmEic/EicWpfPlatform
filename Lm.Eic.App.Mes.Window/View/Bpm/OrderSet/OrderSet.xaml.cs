using System.Windows.Controls;

namespace Lm.Eic.App.Mes.View.Bpm.OrderSet
{
    /// <summary>
    /// OrderSet.xaml 的交互逻辑
    /// </summary>
    public partial class OrderSet : UserControl
    {
        public OrderSet()
        {
            InitializeComponent();
            this.DataContext = new Mes.ViewModel.Bpm.OrderSet.OrderSetDirector();
        }
    }
}