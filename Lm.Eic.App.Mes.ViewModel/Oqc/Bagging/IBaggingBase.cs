using GalaSoft.MvvmLight.Command;
using Lm.Eic.App.Mes.Business;
using Lm.Eic.App.Mes.Model;
using Lm.Eic.App.Mes.ViewModel.Bpm.OrderSet;
using ZhuiFengLib;

namespace Lm.Eic.App.Mes.ViewModel.Oqc.Bagging
{
    public interface IBaggingBase
    {
        int AwaitPrintQty { get; set; }
        RelayCommand<string> InputBarcodeCommand { get; }
        InspectResult InspectResult { get; set; }
        RelayCommand LabPrint { get; }
        VvmBtoB MyTask { get; set; }
        OrderSetDirector OrderSet { get; set; }
        Orm<User_3D_Test_Good>.ModelList_obs User3DTestGoodList { get; set; }
        Orm<User_JDS_Test_Good>.ModelList_obs UserExfoTestGoodList { get; set; }

        InspectResult Inspect(string barcode);
        bool IsAccordInspectStandard();
        bool IsSnForOrder(string Sn);
    }
}