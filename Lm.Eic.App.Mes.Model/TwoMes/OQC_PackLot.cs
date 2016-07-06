namespace Lm.Eic.App.Mes.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class OQC_PackLot
    {
        [Key]
        [StringLength(20)]
        public string PackLot { get; set; }

        [Required]
        [StringLength(20)]
        public string OrderID { get; set; }

        [StringLength(20)]
        public string ProductID { get; set; }

        [StringLength(100)]
        public string ProductName { get; set; }

        [StringLength(100)]
        public string Spec { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [StringLength(20)]
        public string State { get; set; }

        public int? OrderCount { get; set; }

        public int? PackLotCount { get; set; }

        public int? YetPackCout { get; set; }

        public int? NotPackCount { get; set; }
    }
}