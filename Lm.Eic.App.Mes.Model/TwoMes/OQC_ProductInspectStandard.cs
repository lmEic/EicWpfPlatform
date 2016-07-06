namespace Lm.Eic.App.Mes.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class OQC_ProductInspectStandard
    {
        [Required]
        [StringLength(50)]
        public string ProductID { get; set; }

        [StringLength(50)]
        public string TabName { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string FieldName { get; set; }

        public double? Max { get; set; }

        public double? Min { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID_Key { get; set; }
    }
}