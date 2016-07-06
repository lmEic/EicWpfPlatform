namespace Lm.Eic.App.Mes.Model
{
    using System.ComponentModel.DataAnnotations;

    public partial class OQC_OrderPrintConfig
    {
        [Required]
        [StringLength(50)]
        public string OrderID { get; set; }

        [Key]
        [StringLength(50)]
        public string PackLot { get; set; }

        [StringLength(50)]
        public string PrintType { get; set; }

        public int? TriggerCount { get; set; }

        [StringLength(200)]
        public string LabName { get; set; }

        [StringLength(200)]
        public string LabPath { get; set; }

        [StringLength(200)]
        public string DataSourcesPath { get; set; }
       

        public int? LabID { get; set; }
    }
}