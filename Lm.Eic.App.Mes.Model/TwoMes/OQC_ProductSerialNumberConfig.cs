namespace Lm.Eic.App.Mes.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class OQC_ProductSerialNumberConfig
    {
        [Column(TypeName = "numeric")]
        public decimal ProductID { get; set; }

        [StringLength(500)]
        public string ConnectorList { get; set; }

        [StringLength(500)]
        public string PigtailList { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID_Key { get; set; }
    }
}