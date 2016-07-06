using Lm.Eic.App.Mes.Utility.CacheStore;

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ZhuiFengLib.Extension;

namespace Lm.Eic.App.Mes.ViewModel.Bpm
{
    public class ProcessSet : VMbase<Model.Bpm_Process>
    {
        public ProcessSet() : base(Business.Operation.BpmHeper.Process)
        {
            string Department = LoginUser.UserInfo?.Department;
            if (Department.Contains(Utility.Common.Department.STR_DpOne))
            {
                AllProcess = BusinessOperation?.GetModelList(m => m.Department == Utility.Common.Department.STR_MsOne
                || m.Department == Utility.Common.Department.STR_MsSix);
            }
            else
            {
                AllProcess = BusinessOperation?.GetModelList(m => m.Department == Department);
            }

            ModelList_Obs = AllProcess;
        }

        private IList<Model.Bpm_Process> AllProcess { get; set; }

        /// <summary>
        /// 添加 对Detailed属性 实例化一个新的实体类
        /// </summary>
        public override void Add()
        {
            Detailed = new Model.Bpm_Process();
        }


        public List<string> SeachOption { get; set; } = new List<string>() { "工序编号", "工序名称" };

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
            if (SelectSeachOption == "工序编号")
            {
                ModelList_Obs = AllProcess.Where(m => m.ProcessID.StartsWith(SeachValue)).ToList();
            }
            else if (selectSeachOption == "工序名称")
            {
                ModelList_Obs = AllProcess.Where(m => m.Name.StartsWith(SeachValue)).ToList();
            }
            else if (SeachValue.IsNullOrEmpty())
            {
                AllProcess = BusinessOperation?.GetModelList(m => m.Department == Utility.Common.Department.STR_MsOne
               || m.Department == Utility.Common.Department.STR_MsSix);
                ModelList_Obs = AllProcess;
            }
        }

        /// <summary>
        /// 保存一条记录
        /// </summary>
        public override void Sava()
        {
            // Detailed.Department = LoginUser.UserInfo?.Department;
            if (ModeControl.IsEnEdit)
                BusinessOperation.Update(Detailed);
            else
            {
                BusinessOperation.Add(Detailed);
                ModelList_Obs.Add(Detailed);
            }
        }
    }
}