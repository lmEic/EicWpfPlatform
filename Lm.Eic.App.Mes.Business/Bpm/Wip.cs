using Lm.Eic.App.Mes.Model;

namespace Lm.Eic.App.Mes.Business.Bpm
{
    public class Wip : Orm<Model.Bpm_OrderWip>
    {
        public Wip() : base(Model.Operation.DbMes)
        {
        }

      
    }
}