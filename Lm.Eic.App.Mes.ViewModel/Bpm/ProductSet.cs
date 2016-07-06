using Lm.Eic.App.Mes.Utility.CacheStore;
using System.Collections.Generic;
using System.Linq;
using ZhuiFengLib.Extension;
using msg = ZhuiFengLib.Message.Message;

namespace Lm.Eic.App.Mes.ViewModel.Bpm
{
    public  class ProductSet : VMbase<Model.Bpm_Product>
    {

        public ProductSet() : base(Business.Operation.BpmHeper.Product)
        {
            string Department = LoginUser.UserInfo?.Department;
            AllProduct = BusinessOperation?.GetModelList(m => m.Department == Department);
            ModelList_Obs = AllProduct;
        }

        private IList<Model.Bpm_Product> AllProduct { get; set; }

        /// <summary>
        /// 添加 对Detailed属性 实例化一个新的实体类
        /// </summary>
        public override void Add()
        {
            Detailed = new Model.Bpm_Product();
        }

        

        public List<string> SeachOption { get; set; } = new List<string>() { "产品品号", "产品名称" };

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
            if (SelectSeachOption == "产品品号")
            {
                ModelList_Obs = AllProduct.Where(m => m.ProductID.StartsWith(SeachValue)).ToList();
            }
            else if (selectSeachOption == "产品名称")
            {
                ModelList_Obs = AllProduct.Where(m => m.Name.StartsWith(SeachValue)).ToList();
            }
            else if (SeachValue.IsNullOrEmpty())
            {
                ModelList_Obs = AllProduct;
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
