namespace Lm.Eic.App.Mes.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BPM_Machines
    {
        [Key]
        [StringLength(20)]
        public string AssetNum { get; set; }

        [StringLength(100)]
        public string AssetName { get; set; }

        [StringLength(100)]
        public string AssetSpec { get; set; }

        [StringLength(20)]
        public string AliasName { get; set; }

        [StringLength(20)]
        public string MakeNum { get; set; }

        [StringLength(20)]
        public string AssetType { get; set; }

        public bool? IsAuto { get; set; }

        [StringLength(20)]
        public string ProcessID { get; set; }

        [StringLength(20)]
        public string MouldNum { get; set; }

        [StringLength(20)]
        public string MouldName { get; set; }

        public int? MouldCavityCount { get; set; }

        [StringLength(20)]
        public string MasterJobNum { get; set; }

        [StringLength(20)]
        public string MasterName { get; set; }

        [StringLength(20)]
        public string Department { get; set; }

        [StringLength(20)]
        public string WorkShop { get; set; }

        [StringLength(20)]
        public string Workstation { get; set; }
    }
}
