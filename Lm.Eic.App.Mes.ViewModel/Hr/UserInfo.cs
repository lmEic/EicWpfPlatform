using System;
using System.Collections.Generic;
using Lm.Eic.App.Mes.Utility.CacheStore;

namespace Lm.Eic.App.Mes.ViewModel.Hr
{
    class UserInfo : VMbase<Model.HR_User>
    {
        public UserInfo() : base(Mes.Business.Operation.HrHelper.User)
        {
            Detailed =  LoginUser.UserInfo;
        }

        public Option Option { get; set; } = new Option();

        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void ImportForExcel()
        {
            throw new NotImplementedException();
        }

        public override void Seach()
        {
            throw new NotImplementedException();
        }
    }


    public class Option
    {
        public List<string> ClassTypeList = Business.Operation.ConfigHelper.CommonParaSet.GetValueList("班别");

        public List<string> Workstation = Business.Operation.ConfigHelper.CommonParaSet.GetValueList("站别");

        public List<string> Department = Business.Operation.ConfigHelper.CommonParaSet.GetValueList("部门");

        public List<string> JobTitle = Business.Operation.ConfigHelper.CommonParaSet.GetValueList("职位");

        public List<string> Is_Job = Business.Operation.ConfigHelper.CommonParaSet.GetValueList("是否在职");

        public List<string> Sex = Business.Operation.ConfigHelper.CommonParaSet.GetValueList("性别");
       
    }
}
