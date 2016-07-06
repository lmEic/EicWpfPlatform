using Lm.Eic.App.Mes.Model;

namespace Lm.Eic.App.Mes.Business.Oqc
{
    /// <summary>
    /// 提供测试标准的存储列表 供检测设置界面调用
    /// </summary>
    public class InspectStatnard : Orm<Model.OQC_InspectStatnard>
    {
        public InspectStatnard() : base(Model.Operation.DbTwoMes)
        {
        }

       


         
    }
}
