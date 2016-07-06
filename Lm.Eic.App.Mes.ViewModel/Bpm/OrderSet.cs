using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Lm.Eic.App.Mes.ViewModel.Bpm
{
    public class OrderSet : ViewModelBase
    {
        private Business.Bpm.Order order = new Business.Bpm.Order();

        /// <summary>
        ///
        /// </summary>
        public Business.Bpm.Order Order
        {
            get { return order; }
            set
            {
                order = value;
                this.RaisePropertyChanged("Order");
            }
        }

        /// <summary>
        ///
        /// </summary>
        public RelayCommand<string> GetModelCommand => new RelayCommand<string>((orderId) =>
        {
            Order = new Business.Bpm.Order(orderId);
        });

        /// <summary>
        ///
        /// </summary>
        public RelayCommand SaveOrderCommand => new RelayCommand(() =>
        {
            if (Order.SavaToMes()) { ZhuiFengLib.Message.Message.MessageInfo("保存成功！"); }
        });
    }
}