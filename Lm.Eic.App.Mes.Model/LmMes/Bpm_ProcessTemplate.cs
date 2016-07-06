namespace Lm.Eic.App.Mes.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    public class Bpm_ProcessTemplate
    {
        [StringLength(50)]
        public string Department { get; set; }

        [StringLength(50)]
        public string WorkShop { get; set; }

        [Required]
        [StringLength(100)]
        public string PtID { get; set; }

        [StringLength(100)]
        public string Alias { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int? Num { get; set; }

        [StringLength(100)]
        public string ProcessID { get; set; }

        [StringLength(100)]
        public string ProcessName { get; set; }

        [StringLength(100)]
        public string ProcessSign { get; set; }

        [StringLength(20)]
        public string MouldNum { get; set; }

        [StringLength(50)]
        public string MouldName { get; set; }

        public int? MouldCavityCount { get; set; }

        public int? OnceQty { get; set; }

        public double? StandardHours { get; set; }

        public int? ConnectorQty { get; set; }

        public bool? IsCheckTotalCount { get; set; }

        public decimal? TL { get; set; }

        [StringLength(10)]
        public string IsVital { get; set; }

        [StringLength(10)]
        public string IsControl { get; set; }

        [StringLength(1000)]
        public string ReWorkProcess { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID_Key { get; set; }
    }
}