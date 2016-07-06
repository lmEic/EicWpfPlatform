using Lm.Eic.App.Mes.Model;
using System.Collections.Generic;

namespace Lm.Eic.App.Mes.Business.Bpm
{
    public class Product : Orm<Model.Bpm_Product>
    {
        public Product() : base(Model.Operation.DbMes)
        {
            this.Detailed = new Model.Bpm_Product();
        }

        public Product(string ProductID) : base(Model.Operation.DbMes)
        {
            this.Detailed = GetModel(m => m.ProductID == ProductID);
        }

      

        public List<Product> ProductList { get; }
    }
}