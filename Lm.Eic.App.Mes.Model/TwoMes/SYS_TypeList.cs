namespace Lm.Eic.App.Mes.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_TypeList
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }

        [StringLength(50)]
        public string Module { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string Value { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }

        [StringLength(50)]
        public string R1 { get; set; }
    }
}
