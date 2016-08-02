using System.Windows.Controls;

namespace Lm.Eic.App.Mes.View.Ast
{
    /// <summary>
    /// Ast_Equipment.xaml 的交互逻辑
    /// </summary>
    public partial class Equipment : UserControl
    {
        public Equipment()
        {
            InitializeComponent();
            this.DataContext = new ViewModel.Ast.Equipment();
        }
    }
}
