namespace Lm.Eic.App.Mes.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class OQC_OrderInspectConfig
    {
        [Required]
        [StringLength(20)]
        public string OrderID { get; set; }

        public bool? IsInspect { get; set; }

        [StringLength(50)]
        public string InspectMethod { get; set; }

        public bool? IsPrint { get; set; }

        [StringLength(50)]
        public string PrintMethod { get; set; }

        [StringLength(50)]
        public string InspectStandardName { get; set; }

        [StringLength(200)]
        public string ConnectList { get; set; }

        public bool? IsInspect3D { get; set; }

        [StringLength(200)]
        public string InspectStandard_3D { get; set; }

        public bool? IsInspectExfo { get; set; }

        [StringLength(200)]
        public string InspectStandard_Exfo { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID_Key { get; set; }
    }
}