using System.Collections.Generic;

namespace Lm.Eic.App.Mes.Business.Bpm
{
    /// <summary>
    /// 部门类
    /// </summary>
    internal class Department
    {
        /// <summary>
        /// 车间
        /// </summary>
        public List<WorkShop> WorkShops { get; }

        /// <summary>
        /// 工单列表
        /// </summary>
        public List<Order> OrderList { get; }

        /// <summary>
        /// 日报
        /// </summary>
        public Daily.Daily Daily { get; }
    }
}