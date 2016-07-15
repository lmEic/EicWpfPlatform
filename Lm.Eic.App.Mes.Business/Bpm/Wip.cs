using Lm.Eic.App.Mes.Model;

namespace Lm.Eic.App.Mes.Business.Bpm
{
    public class Wip : Orm<BPM_WIP>
    {
        public Wip() : base(Model.Operation.DbTwoMes)
        {
        }

      
    }
}