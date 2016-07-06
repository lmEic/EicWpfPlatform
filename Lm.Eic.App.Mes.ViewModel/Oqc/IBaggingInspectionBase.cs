using GalaSoft.MvvmLight.Command;
using Lm.Eic.App.Mes.Business.Bpm;
using Lm.Eic.App.Mes.Business.Oqc;
using Lm.Eic.App.Mes.Model;
using ZhuiFengLib;

namespace Lm.Eic.App.Mes.ViewModel.Oqc
{
    public interface IBaggingInspectionBase
    {
        int AwaitPrintQty { get; set; }
        OrderBtPrintConfig BtPrintConfig { get; set; }
        RelayCommand<string> InputBarcodeCommand { get; }
        OrderInspectConfig InspectConfig { get; set; }
        InspectResult InspectResult { get; set; }
        Order Order { get; set; }
        string OrderID { get; set; }
        OrderPackLot PackLot { get; set; }
        Obs<User_3D_Test_Good> User3DTestGoodList { get; set; }
        Obs<User_JDS_Test_Good> UserJdsTestGoodList { get; set; }

        InspectResult Inspect(string barcode);
    }
}