namespace Lm.Eic.App.Mes.Model
{
    using System.ComponentModel.DataAnnotations;

    public partial class OQC_SerialNumber
    {
        [Key]
        [StringLength(50)]
        public string SN { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public bool? IsPack { get; set; }

        public bool? IsPrint { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        public int? Qty { get; set; }

        [StringLength(20)]
        public string PackLot { get; set; }

        [StringLength(50)]
        public string OrderID { get; set; }

        [StringLength(50)]
        public string R1 { get; set; }
    }
}