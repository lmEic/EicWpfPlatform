namespace Lm.Eic.App.Mes.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [Serializable]
    public class Bpm_Product
    {
        [Key]
        [StringLength(30)]
        public string ProductID { get; set; }

        [StringLength(50)]
        public string Alias { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Spec { get; set; }

        [StringLength(50)]
        public string Units { get; set; }

        public int? ConnectorQty { get; set; }

        [StringLength(50)]
        public string DrawID { get; set; }

        [StringLength(50)]
        public string PtID { get; set; }

        [StringLength(200)]
        public string Pic { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        [StringLength(50)]
        public string WorkShop { get; set; }
    }
}