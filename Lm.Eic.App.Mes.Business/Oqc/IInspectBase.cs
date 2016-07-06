using Lm.Eic.App.Mes.Business.Bpm;

namespace Lm.Eic.App.Mes.Business.Oqc
{
    internal interface IInspectBase
    {
        BtPrint BtPrint { get; set; }
        BtTemplate BtTemplate { get; set; }
        InspectStandard InspectStandard { get; set; }
        Order Order { get; set; }
        PackLot PackLot { get; set; }

        bool Inspect();

        bool Print();
    }
}