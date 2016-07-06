using Seagull.BarTender.Print;
using System.Collections.Generic;

namespace Lm.Eic.App.Mes.Business.Oqc.Print
{
    public interface IBtPrintBase
    {
       
        Engine BtEngine { get; }
        string GetLaberFormatName { get; set; }
        string SetLaberFormat { set; }
        string PrinterName { set; }
        OrderBtPrintConfig PrintConfig { get; set; }
        List<Model.User_JDS_Test_Good> ExfoDataList { get; set; }

        List<Model.OQC_OrderPrintLabInfo> LabContentList { get; set; }

        void OnPrint();

        void StartPrint();

        void Dispose();
    }
}