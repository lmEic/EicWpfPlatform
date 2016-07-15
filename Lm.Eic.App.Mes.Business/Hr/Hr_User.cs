using Lm.Eic.App.Mes.Model;
using Lm.Eic.App.Mes.Utility.CacheStore;
using System.Linq;

namespace Lm.Eic.App.Mes.Business.Hr
{
    public class Hr_User : Orm<Model.HR_User>
    {
        public Hr_User() : base(Model.Operation.DbTwoMes)
        {
        }

        public Hr_User(string jobNum) : base(Model.Operation.DbTwoMes)
        {
            this.Detailed = GetModel(m => m.Job_Num == jobNum);
        }

       

        /// <summary>
        /// 用户是否存在
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool VerifyUser(Model.HR_User user)
        {
            var tem = (from s in Model.Operation.DbTwoMes.HR_User where s.Job_Num == user.Job_Num && s.Password == user.Password select s).ToList();
            if (tem.Count > 0)
            {
                BufferUser(tem[0]);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 缓存用户
        /// </summary>
        /// <param name="user"></param>
        private void BufferUser(Model.HR_User user)
        {
            LoginUser.UserInfo = user;
        }
    }
}