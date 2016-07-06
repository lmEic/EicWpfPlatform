namespace Lm.Eic.App.Mes.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class OQC_OrderInspectStatnard
    {
        [Required]
        [StringLength(50)]
        public string OrderID { get; set; }

        [StringLength(50)]
        public string InspectStandardName { get; set; }

        [StringLength(50)]
        public string FieldName { get; set; }

        public double? Max { get; set; }

        public double? Min { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID_Key { get; set; }
    }
}