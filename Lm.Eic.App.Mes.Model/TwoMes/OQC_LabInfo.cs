namespace Lm.Eic.App.Mes.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Serializable]
    public partial class OQC_LabInfo
    {
        public int LabID { get; set; }

        [StringLength(100)]
        public string Term { get; set; }

        [StringLength(255)]
        public string Value { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID_Key { get; set; }
    }
}