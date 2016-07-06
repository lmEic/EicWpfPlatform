using Lm.Eic.App.Mes.Model;
using Lm.Eic.App.Mes.Utility.CacheStore;
using System.Linq;

namespace Lm.Eic.App.Mes.Business.Hr
{
    public class Hr_User : Orm<Model.Hr_UserInfo>
    {
        public Hr_User() : base(Model.Operation.DbMes)
        {
        }

        public Hr_User(string jobNum) : base(Model.Operation.DbMes)
        {
            this.Detailed = GetModel(m => m.JobNum == jobNum);
        }

       

        /// <summary>
        /// 用户是否存在
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool VerifyUser(Model.Hr_UserInfo user)
        {
            var tem = (from s in Model.Operation.DbMes.Hr_UserInfo where s.JobNum == user.JobNum && s.Password == user.Password select s).ToList();
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
        private void BufferUser(Model.Hr_UserInfo user)
        {
            LoginUser.UserInfo = user;
        }
    }
}