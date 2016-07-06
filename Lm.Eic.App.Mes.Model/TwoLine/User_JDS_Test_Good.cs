namespace Lm.Eic.App.Mes.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    public class User_JDS_Test_Good
    {
        [StringLength(25)]
        public string TestDate { get; set; }

        [StringLength(50)]
        public string PartNumber { get; set; }

        [StringLength(35)]
        public string SN { get; set; }

        [StringLength(10)]
        public string Result { get; set; }

        [StringLength(10)]
        public string Wave { get; set; }

        [StringLength(10)]
        public string IL_A { get; set; }

        [StringLength(10)]
        public string Refl_A { get; set; }

        [StringLength(10)]
        public string IL_B { get; set; }

        [StringLength(10)]
        public string Refl_B { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID_Key { get; set; }
    }
}