namespace Lm.Eic.App.Mes.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    public class Bpm_OrderWip
    {
        [StringLength(20)]
        public string OrderID { get; set; }

        [StringLength(100)]
        public string ClientName { get; set; }

        [StringLength(100)]
        public string ProductName { get; set; }

        [StringLength(100)]
        public string Spec { get; set; }

        public int? Count { get; set; }

        public int? ProcessCount { get; set; }

        [StringLength(20)]
        public string ProcessID { get; set; }

        [StringLength(100)]
        public string ProcessName { get; set; }

        public double? StandardHours { get; set; }

        public int? ConnectorQty { get; set; }

        [StringLength(30)]
        public string ProcessSign { get; set; }

        public double? TotalStandatdHours { get; set; }

        public int? Qty { get; set; }

        public int? Qty_OK { get; set; }

        public int? Qty_NG { get; set; }

        public int? Qty_NotInput { get; set; }

        public double? GetTime { get; set; }

        public double? WorkHours { get; set; }

        public double? Efficiency { get; set; }

        public int? Wip { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID_Key { get; set; }
    }
}