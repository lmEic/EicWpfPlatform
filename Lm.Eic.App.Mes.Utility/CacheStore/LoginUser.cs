using System.Collections.Generic;

namespace Lm.Eic.App.Mes.Utility.CacheStore
{
    public static class LoginUser
    {
        /// <summary>
        /// 登陆用户信息
        /// </summary>
        public static Model.HR_User UserInfo { get; set; }

        /// <summary>
        /// 权限列表
        /// </summary>
        public static List<object> AuthorityList { get; set; }
    }
}