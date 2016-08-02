namespace Lm.Eic.App.Mes.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Config_CommonParaSet
    {
        [StringLength(30)]
        public string ParameterName { get; set; }

        [StringLength(50)]
        public string ParameterValue { get; set; }

        [StringLength(10)]
        public string CurrentTemperature { get; set; }

        [StringLength(50)]
        public string Memo { get; set; }

        [StringLength(10)]
        public string OpPerson { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? OpDate { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id_Key { get; set; }
    }
}
