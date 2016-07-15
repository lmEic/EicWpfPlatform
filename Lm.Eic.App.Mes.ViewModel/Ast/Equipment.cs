
using msg = ZhuiFengLib.Message.Message;
using System.Collections.Generic;
using System.Linq;
using ZhuiFengLib.Extension;
using Lm.Eic.App.Mes.Utility.CacheStore;
/**
* 命名空间: Lm.Eic.App.Mes.ViewModel.Ast
* 类 名： Equipment
* 功 能： N/A
*
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2016/3/15 星期二 13:44:20 张明 初版
*
* Copyright (c) 2015 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司 　　　　　   　　　　　　　　　│
*└──────────────────────────────────┘
*/
namespace Lm.Eic.App.Mes.ViewModel.Ast
{
    public class Equipment : VMbase<Model.BPM_Machines>
    {
        public Equipment() : base(Business.Operation.AstHeper.Equitment)
        {
            string Department = LoginUser.UserInfo?.Department;
            AllModelList = BusinessOperation?.GetModelList(m => m.Department == Department);
            ModelList_Obs = AllModelList;
        }

        private IList<Model.BPM_Machines> AllModelList { get; set; }

        /// <summary>
        /// 添加 对Detailed属性 实例化一个新的实体类
        /// </summary>
        public override void Add()
        {
            Detailed = new Model.BPM_Machines();
        }

       

        public List<string> SeachOption { get; set; } = new List<string>() { "设备编号", "设备名称" };

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
            if (SelectSeachOption == "设备编号")
            {
                ModelList_Obs = AllModelList.Where(m => m.AssetNum.StartsWith(SeachValue)).ToList();
            }
            else if (selectSeachOption == "设备名称")
            {
                ModelList_Obs = AllModelList.Where(m => m.AssetName.StartsWith(SeachValue)).ToList();
            }
            else if (SeachValue.IsNullOrEmpty())
            {
                ModelList_Obs = AllModelList;
            }
        }

        /// <summary>
        /// 保存一条记录
        /// </summary>
        public override void Sava()
        {
            Detailed.Department = LoginUser.UserInfo?.Department;
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