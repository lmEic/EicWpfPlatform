using Lm.Eic.App.Mes.Model;
using System.Collections.Generic;

namespace Lm.Eic.App.Mes.Business.Bpm
{
    public class Product : Orm<BPM_Product>
    {
        public Product() : base(Model.Operation.DbTwoMes)
        {
            this.Detailed = new BPM_Product();
        }

        public Product(string ProductID) : base(Model.Operation.DbTwoMes)
        {
            this.Detailed = GetModel(m => m.ProductID == ProductID);
        }

      

        public List<Product> ProductList { get; }
    }
}