using Lm.Eic.App.Mes.Model;
using System;
using System.Data;
using System.Linq;
using ZhuiFengLib.Extension;

namespace Lm.Eic.App.Mes.Business.Bpm
{
    public class Order : Orm<Model.Bpm_Order>
    {
        public Order() : base(Model.Operation.DbMes) { }
 
        /// <summary>
        /// 初始化一个工单
        /// </summary>
        /// <param name="OrderID"></param>
        public Order(string OrderID) : base(Model.Operation.DbMes)
        {
            this.OrderID = OrderID;
            Detailed = GetModel();
            if (!this.IsNull)
            {
                Product = new Product(Detailed.ProductID);
            }
        }

        /// <summary>
        /// 全局变量 工单单号
        /// </summary>
        private string OrderID = string.Empty;

        /// <summary>
        /// 产品
        /// </summary>
        public Product Product { get; }

       

      
       


        /// <summary>
        /// 获取工单信息
        /// </summary>
        /// <param name="orderID">工单单号</param>
        /// <param name="selectDb">数据源选择</param>
        /// <returns></returns>
        private Bpm_Order GetModel()
        {
            if (!OrderID.IsNullOrEmpty() && OrderID.Length > 7)
            {
                var Order_forMes = GetModel_foDbMes(OrderID);
                return Order_forMes != null ? Order_forMes : GetModel_forDbErp(OrderID);
            }
            else return null;
        }

        /// <summary>
        /// 从ERP中获取一个工单
        /// </summary>
        /// <param name="orderID_sp"></param>
        /// <returns></returns>
        private Model.Bpm_Order GetModel_forDbErp(string orderID)
        {
            var orderID_sp = orderID.Split('-');
            if (orderID_sp.Count() < 2)
            {
                return null;
            }
            else
            {

                string od1 = orderID_sp[0], od2 = orderID_sp[1];
                var tem = Model.Operation.DbErp.MOCTA.Where(m => m.TA001 == od1 && m.TA002 == od2).ToList();
                if (tem.Count < 1) return null;
                else
                {
                    var ds = tem.ToDataTable();
                    return MoctaToModel(ds.Rows[0]);
                }
            }
        }

        /// <summary>
        /// 从MES数据库获取一个工单
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        private static Model.Bpm_Order GetModel_foDbMes(string orderID)
        {
            var orderList = Model.Operation.DbMes.Bpm_Order.Where(m => m.OrderID == orderID).ToList();
            return orderList.Count() <= 0 ? null : orderList[0];
        }

        /// <summary>
        /// DataRow 转 Model.Order
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Model.Bpm_Order MoctaToModel(DataRow row)
        {
            Model.Bpm_Order model = new Model.Bpm_Order();
            if (row != null)
            {
                if (row["TA001"] != null && row["TA002"] != null)
                {
                    model.OrderID = string.Format("{0}-{1}", 
                                        row["TA001"].ToString().Replace(" ", ""), 
                                        row["TA002"].ToString().Replace(" ", ""));
                }
                if (row["TA006"] != null)
                {
                    model.ProductID = row["TA006"].ToString();
                }
                if (row["TA034"] != null)
                {
                    model.ProductName = row["TA034"].ToString();
                }
                if (row["TA035"] != null)
                {
                    model.Spec = row["TA035"].ToString();
                }
                if (row["TA015"] != null)
                {
                    model.Count = Convert.ToInt32( double.Parse(row["TA015"].ToString()));
                }
                if (row["TA009"] != null)
                {
                    model.StartDate = row["TA009"].ToString();
                }
                if (row["TA010"] != null)
                {
                    model.EndDate = row["TA010"].ToString();
                }
                if (row["TA011"] != null)
                {
                    string state = row["TA011"].ToString();
                    switch (state)
                    {
                        case "1":
                            model.State = "未生产"; break;
                        case "2":
                            model.State = "已发料"; break;
                        case "3":
                            model.State = "生产中"; break;
                        case "Y":
                            model.State = "已完工"; break;
                        case "y":
                            model.State = "指定完工"; break;
                        default:
                            break;
                    }
                }
                if (row["TA012"] != null)
                {
                    model.ActualStartDate = row["TA012"].ToString();
                }
                if (row["TA014"] != null)
                {
                    model.ActualEndDate = row["TA014"].ToString();
                }

                model.IsRemind = false;
            }
            //BPM_Product product = new BPM_Product();
            //model.Product = product.GetModel(model.ProductID);  //产品信息
            return model;
        }

        /// <summary>
        /// 数据迁移至MES数据库
        /// </summary>
        /// <returns></returns>
        public bool SavaToMes()
        {
            Model.Operation.DbMes.Bpm_Order.Add(Detailed);
            return Model.Operation.DbMes.SaveChanges() > 0 ? true : false;
        }
    }
}