using Lm.Eic.App.Mes.Business.Bpm;

namespace Lm.Eic.App.Mes.Business.Oqc.Inspect
{
    public interface IInspectBase
    {
        Print.IBtPrintBase BtPrint { get; set; }
        OrderBtPrintConfig BtTemplate { get; set; }
        OrderInspectStandard InspectStandard { get; set; }
        Order Order { get; set; }
        OrderPackLot PackLot { get; set; }

        bool Inspect(string barcode);
    }
}