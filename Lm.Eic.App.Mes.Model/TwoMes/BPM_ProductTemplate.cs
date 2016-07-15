namespace Lm.Eic.App.Mes.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BPM_ProductTemplate
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

        public bool? IsCheckTotalCount { get; set; }

        public int? OnceQty { get; set; }

        public decimal? StandardHours { get; set; }

        public int? ConnectorQty { get; set; }

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
