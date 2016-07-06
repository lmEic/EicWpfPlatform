namespace Lm.Eic.App.Mes.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class OQC_PackExfo
    {
        [Required]
        [StringLength(25)]
        public string SN { get; set; }

        [StringLength(25)]
        public string TestDate { get; set; }

        [StringLength(50)]
        public string PartNumber { get; set; }

        [StringLength(10)]
        public string Result { get; set; }

        [StringLength(10)]
        public string Wave { get; set; }

        [StringLength(10)]
        public string IL_A { get; set; }

        [StringLength(10)]
        public string Refl_A { get; set; }

        [StringLength(10)]
        public string IL_B { get; set; }

        [StringLength(10)]
        public string Refl_B { get; set; }

        [StringLength(25)]
        public string ClientSN { get; set; }

        [StringLength(20)]
        public string PackLot { get; set; }

        [StringLength(20)]
        public string OrderID { get; set; }

        [StringLength(35)]
        public string BatchNo { get; set; }

        public DateTime? PackDate { get; set; }

        [StringLength(25)]
        public string CustomerName { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID_Key { get; set; }
    }
}