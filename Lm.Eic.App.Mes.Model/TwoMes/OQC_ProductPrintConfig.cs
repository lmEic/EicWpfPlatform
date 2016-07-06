namespace Lm.Eic.App.Mes.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class OQC_ProductPrintConfig
    {
        [Required]
        [StringLength(50)]
        public string ProductID { get; set; }

        [StringLength(50)]
        public string PrintType { get; set; }

        public int? TriggerCount { get; set; }

        [StringLength(200)]
        public string LabName { get; set; }

        [StringLength(200)]
        public string LabPath { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID_Key { get; set; }
    }
}