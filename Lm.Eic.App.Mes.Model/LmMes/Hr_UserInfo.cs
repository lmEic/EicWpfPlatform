namespace Lm.Eic.App.Mes.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [Serializable]
    public class Hr_UserInfo
    {
        [Key]
        [StringLength(10)]
        public string JobNum { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        [StringLength(20)]
        public string Sex { get; set; }

        public int? Age { get; set; }

        [StringLength(20)]
        public string Department { get; set; }

        [StringLength(20)]
        public string WorkShop { get; set; }

        [StringLength(20)]
        public string Workstation { get; set; }

        [StringLength(20)]
        public string ClassType { get; set; }

        [StringLength(20)]
        public string JobTitle { get; set; }

        [StringLength(20)]
        public string IsJob { get; set; }
    }
}