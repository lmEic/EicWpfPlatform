namespace Lm.Eic.App.Mes.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BPM_Order
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

        public double? TotalWorkHoursStandard { get; set; }

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
        public string PN { get; set; }

        [StringLength(50)]
        public string PO { get; set; }

        [StringLength(50)]
        public string WorkDepartment { get; set; }

        [StringLength(50)]
        public string WorkShop { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        public decimal? Relax { get; set; }

        public bool? IsRemind { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID_Key { get; set; }
    }
}
