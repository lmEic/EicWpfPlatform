using System.Linq;
using msg = ZhuiFengLib.Message.Message;

namespace Lm.Eic.App.Mes.ViewModel.Oqc.Bagging
{
    /// <summary>
    /// 装袋检测 Connector
    /// </summary>
    public class BaggingConnector : BaggingBase, IBaggingBase
    {
        public override InspectResult Inspect(string barcode)
        {
            //1.判断条码是否属于此工单
            var SnIsBeLongOrder = OrderSet.SerialNumberSet.SnList.FirstOrDefault(m => m.SN == barcode);
            if (SnIsBeLongOrder == null)
            {
                msg.MessageInfo($"条码{barcode}不属于该工单");
            }
            this.User3DTestGoodList = new Business.Orm<Model.User_3D_Test_Good>.ModelList_obs(Business.Operation.OqcHelper.UserTest3D.GetModelList(m => m.SN == barcode));
            this.UserExfoTestGoodList = new Business.Orm<Model.User_JDS_Test_Good>.ModelList_obs(Business.Operation.OqcHelper.UserTestExfo.GetModelList(m => m.SN == barcode));
            // msg.MessageInfo($"Connector{barcode}");
            InspectResult.Flage = "没有标志位";
            InspectResult.MaxBarcode = barcode;
            InspectResult.Ng3dConnector = "meiyou3DNg";
            InspectResult.NgExfoConnector = "meiyouExfoNg";

            if (InspectResult.Result)
            {
                IBtPrint.ExfoDataList.Add(UserExfoTestGoodList[0]);
            }
            return InspectResult;
        }
    }
}