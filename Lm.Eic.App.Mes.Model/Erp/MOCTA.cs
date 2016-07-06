namespace Lm.Eic.App.Mes.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    [Table("MOCTA")]
    public class MOCTA
    {
        [StringLength(10)]
        public string COMPANY { get; set; }

        [StringLength(10)]
        public string CREATOR { get; set; }

        [StringLength(10)]
        public string USR_GROUP { get; set; }

        [StringLength(17)]
        public string CREATE_DATE { get; set; }

        [StringLength(10)]
        public string MODIFIER { get; set; }

        [StringLength(17)]
        public string MODI_DATE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FLAG { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string TA001 { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(11)]
        public string TA002 { get; set; }

        [StringLength(8)]
        public string TA003 { get; set; }

        [StringLength(8)]
        public string TA004 { get; set; }

        [StringLength(4)]
        public string TA005 { get; set; }

        [StringLength(20)]
        public string TA006 { get; set; }

        [StringLength(4)]
        public string TA007 { get; set; }

        [StringLength(4)]
        public string TA008 { get; set; }

        [StringLength(8)]
        public string TA009 { get; set; }

        [StringLength(8)]
        public string TA010 { get; set; }

        [StringLength(1)]
        public string TA011 { get; set; }

        [StringLength(8)]
        public string TA012 { get; set; }

        [StringLength(1)]
        public string TA013 { get; set; }

        [StringLength(8)]
        public string TA014 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TA015 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TA016 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TA017 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TA018 { get; set; }

        [StringLength(6)]
        public string TA019 { get; set; }

        [StringLength(10)]
        public string TA020 { get; set; }

        [StringLength(10)]
        public string TA021 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TA022 { get; set; }

        [StringLength(4)]
        public string TA023 { get; set; }

        [StringLength(4)]
        public string TA024 { get; set; }

        [StringLength(11)]
        public string TA025 { get; set; }

        [StringLength(4)]
        public string TA026 { get; set; }

        [StringLength(11)]
        public string TA027 { get; set; }

        [StringLength(4)]
        public string TA028 { get; set; }

        [StringLength(255)]
        public string TA029 { get; set; }

        [StringLength(1)]
        public string TA030 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TA031 { get; set; }

        [StringLength(10)]
        public string TA032 { get; set; }

        [StringLength(20)]
        public string TA033 { get; set; }

        [StringLength(60)]
        public string TA034 { get; set; }

        [StringLength(60)]
        public string TA035 { get; set; }

        [StringLength(1)]
        public string TA036 { get; set; }

        [StringLength(1)]
        public string TA037 { get; set; }

        [StringLength(1)]
        public string TA038 { get; set; }

        [StringLength(1)]
        public string TA039 { get; set; }

        [StringLength(8)]
        public string TA040 { get; set; }

        [StringLength(10)]
        public string TA041 { get; set; }

        [StringLength(4)]
        public string TA042 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TA043 { get; set; }

        [StringLength(1)]
        public string TA044 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TA045 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TA046 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TA047 { get; set; }

        [StringLength(4)]
        public string TA048 { get; set; }

        [StringLength(1)]
        public string TA049 { get; set; }

        [StringLength(100)]
        public string TA050 { get; set; }

        [StringLength(100)]
        public string TA051 { get; set; }

        [StringLength(100)]
        public string TA052 { get; set; }

        [StringLength(100)]
        public string TA053 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TA054 { get; set; }

        [StringLength(1)]
        public string TA055 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TA056 { get; set; }

        [StringLength(20)]
        public string TA057 { get; set; }

        [StringLength(80)]
        public string TA058 { get; set; }

        [StringLength(1)]
        public string TA059 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TA060 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TA061 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TA062 { get; set; }

        [StringLength(8)]
        public string TA063 { get; set; }

        [StringLength(6)]
        public string TA064 { get; set; }

        [StringLength(1)]
        public string TA065 { get; set; }

        [StringLength(8)]
        public string TA066 { get; set; }

        [StringLength(30)]
        public string TA067 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TA068 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TA069 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TA070 { get; set; }

        [StringLength(6)]
        public string TA071 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TA072 { get; set; }

        [StringLength(15)]
        public string TA073 { get; set; }

        [StringLength(4)]
        public string TA074 { get; set; }

        [StringLength(255)]
        public string UDF01 { get; set; }

        [StringLength(255)]
        public string UDF02 { get; set; }

        [StringLength(255)]
        public string UDF03 { get; set; }

        [StringLength(255)]
        public string UDF04 { get; set; }

        [StringLength(255)]
        public string UDF05 { get; set; }

        [StringLength(255)]
        public string UDF06 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UDF51 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UDF52 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UDF53 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UDF54 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UDF55 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UDF56 { get; set; }
    }
}