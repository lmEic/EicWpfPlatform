using msg = ZhuiFengLib.Message.Message;

namespace Lm.Eic.App.Mes.Business.Oqc.Print
{
    public class PrintTwoSnOneLab : BtPrintBase, IBtPrintBase
    {
        /// <summary>
        /// 具体的打印方法
        /// </summary>
        public override void OnPrint()
        {
            ExfoDataToExcel tt = new ExfoDataToExcel();
            tt.Delete_ExcelData(@"D:\myxls", 2, 21);  //清除Excel中的数据
            foreach (var snData in ExfoDataList)
            {
                string _lineName = string.Empty, _lineValue = string.Empty;
                foreach (var labContent in LabContentList)
                {
                    if (labContent.Name == "SN") { _lineValue += $"'{snData.SN}',"; }
                    else if (labContent.Name == "RL_1") { _lineValue += $"'{snData.Refl_A}',"; }
                    else if (labContent.Name == "IL_1") { _lineValue += $"'{snData.IL_A}',"; }
                    else { _lineValue += $"'{labContent.Value}',"; }
                    _lineName += $"'{labContent.Name}',";
                }
                var tem = $"INSERT INTO [sheet1$] {_lineName} VALUES {_lineValue}";
            }

            int? laCount = LabContentList?.Count;
            msg.MessageInfo("我是两碼两签");
        }
    }
}