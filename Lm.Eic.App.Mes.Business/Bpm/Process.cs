using Lm.Eic.App.Mes.Model;

namespace Lm.Eic.App.Mes.Business.Bpm
{
    public class Process : Orm<Bpm_Process>,IOrm<Bpm_Process>
    {
        public Process() : base(Model.Operation.DbMes)
        {

        }

        public Process(string ProcessId) : base(Model.Operation.DbMes)
        {
            this.Detailed = GetModel(m => m.ProcessID == ProcessId && m.Department == Utility.CacheStore.LoginUser.UserInfo.Department);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProcessId">工序</param>
        /// <param name="Department">部门</param>
        public Process(string ProcessId ,string Department) : base(Model.Operation.DbMes)
        {
            this.Detailed = GetModel(m => m.ProcessID == ProcessId && m.Department ==  Department);
        }

        public override bool Add(Bpm_Process model)
        {
            var temModel = GetModel(m => m.ProcessID == model.ProcessID && m.Department == model.Department);
            if (temModel != null)
                return base.Update(model);
            else
            {
                return base.Add(model);
            }

        }


    }
}