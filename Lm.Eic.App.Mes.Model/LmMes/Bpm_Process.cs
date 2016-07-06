namespace Lm.Eic.App.Mes.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Serializable]
    public class Bpm_Process
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string ProcessID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public double? StandardHours { get; set; }

        public double? Relax { get; set; }

        public int? PCSH { get; set; }

        public int? Num { get; set; }
        [StringLength(50)]
        public string ProcessSign { get; set; }
        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Department { get; set; }

        [StringLength(50)]
        public string WorkShop { get; set; }

        [StringLength(50)]
        public string Workstation { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }
    }
}