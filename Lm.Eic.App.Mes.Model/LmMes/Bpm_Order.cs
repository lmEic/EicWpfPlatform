namespace Lm.Eic.App.Mes.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [Serializable]
    public class Bpm_Order
    {
        [Key]
        [StringLength(50)]
        public string OrderID { get; set; }

        [StringLength(50)]
        public string ClientName { get; set; }

        [StringLength(50)]
        public string ProductID { get; set; }

        [StringLength(100)]
        public string ProductName { get; set; }

        [StringLength(300)]
        public string Spec { get; set; }

        public int? Count { get; set; }

        public int? YetPackCount { get; set; }

        [StringLength(50)]
        public string StartDate { get; set; }

        [StringLength(50)]
        public string EndDate { get; set; }

        [StringLength(8)]
        public string ActualStartDate { get; set; }

        [StringLength(8)]
        public string ActualEndDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [StringLength(50)]
        public string Qty { get; set; }

        [StringLength(50)]
        public string WorkDepartment { get; set; }

        [StringLength(50)]
        public string WorkShop { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        public decimal? Relax { get; set; }

        public bool? IsRemind { get; set; }
    }
}