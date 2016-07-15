namespace Lm.Eic.App.Mes.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BPM_Process
    {
        [Key]
        [StringLength(50)]
        public string ProcessID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Num { get; set; }

        public double? StandardHours { get; set; }

        public int? PCSH { get; set; }

        public double? Relax { get; set; }

        [StringLength(50)]
        public string ProcessSign { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        [StringLength(50)]
        public string WorkShop { get; set; }

        [StringLength(50)]
        public string Workstation { get; set; }

        public int? MaxMachine { get; set; }

        public int? MinMachine { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }
    }
}
