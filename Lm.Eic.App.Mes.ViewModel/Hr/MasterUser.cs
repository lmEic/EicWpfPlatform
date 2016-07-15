using System.Collections.Generic;
using System.Linq;
using msg = ZhuiFengLib.Message.Message;
using ZhuiFengLib.Extension;
using Lm.Eic.App.Mes.Utility.CacheStore;

namespace Lm.Eic.App.Mes.ViewModel.Hr
{
    public class MasterUser:VMbase<Model.HR_User>
    {
        public MasterUser() : base(Business.Operation.HrHelper.User)
        {
            string Department =  LoginUser.UserInfo?.Department;
            AllUser = BusinessOperation?.GetModelList(m => m.Department == Department);
            ModelList_Obs = AllUser;
        }

        private IList<Model.HR_User> AllUser {get;set; }

        /// <summary>
        /// 添加 对Detailed属性 实例化一个新的实体类
        /// </summary>
        public override void Add()
        {
            Detailed = new Model.HR_User();
        }

        /// <summary>
        /// 从Excel中导入一条 或多条数据
        /// 抽象方法 必须实现
        /// </summary>
        public override void ImportForExcel()
        {
            msg.MessageInfo("暂未开放");
        }

        public List<string> SeachOption { get; set; } = new List<string>() { "工号", "姓名","班别","站别" };

        private string selectSeachOption = string.Empty;

        /// <summary>
        /// 选择的搜索选项
        /// </summary>
        public string SelectSeachOption
        {
            get { return selectSeachOption; }
            set
            {
                selectSeachOption = value;
                this.RaisePropertyChanged(nameof(SelectSeachOption));
            }
        }

        private string seachValue = string.Empty;

        /// <summary>
        ///  搜索的参数
        /// </summary>
        public string SeachValue
        {
            get { return seachValue; }
            set
            {
                seachValue = value;
                this.RaisePropertyChanged(nameof(SeachValue));
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override void Seach()
        {
            if (SelectSeachOption == "工号")
            {
                ModelList_Obs = AllUser.Where(m => m.Job_Num.StartsWith(SeachValue)).ToList();
            }
            else if (selectSeachOption == "姓名")
            {
                ModelList_Obs = AllUser.Where(m => m.Name.StartsWith(SeachValue)).ToList();
            }
            else if (selectSeachOption == "班别")
            {
                ModelList_Obs = AllUser.Where(m => m.ClassType.StartsWith(SeachValue)).ToList();
            }
            else if (selectSeachOption == "站别")
            {
                ModelList_Obs = AllUser.Where(m => m.Workstation.StartsWith(SeachValue)).ToList();
            }
            else if (SeachValue.IsNullOrEmpty())
            {
                ModelList_Obs = AllUser;
            }
        }

        /// <summary>
        /// 保存一条记录
        /// </summary>
        public override void Sava()
        {
            Detailed.Department =  LoginUser.UserInfo?.Department;
            if (ModeControl.IsEnEdit)
                BusinessOperation.Update(Detailed);
            else
                BusinessOperation.Add(Detailed);
        }
    }
}
