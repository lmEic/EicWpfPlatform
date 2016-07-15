namespace Lm.Eic.App.Mes.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BPM_OrderRelevance
    {
        [StringLength(20)]
        public string MainOrder { get; set; }

        [Key]
        [StringLength(20)]
        public string AdditionalOrder { get; set; }

        [StringLength(100)]
        public string ProductName { get; set; }

        [StringLength(100)]
        public string Spec { get; set; }

        public double? Qty { get; set; }
    }
}
