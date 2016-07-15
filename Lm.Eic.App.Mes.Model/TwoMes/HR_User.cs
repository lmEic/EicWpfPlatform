namespace Lm.Eic.App.Mes.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_User
    {
        [Key]
        [StringLength(30)]
        public string Job_Num { get; set; }

        [StringLength(30)]
        public string Department { get; set; }

        [StringLength(10)]
        public string Workshop { get; set; }

        [StringLength(50)]
        public string Workstation { get; set; }

        [StringLength(30)]
        public string ClassType { get; set; }

        [StringLength(50)]
        public string Job_Title { get; set; }

        [StringLength(10)]
        public string Is_Job { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(30)]
        public string Password { get; set; }

        [StringLength(200)]
        public string PhotoPath { get; set; }

        [StringLength(10)]
        public string Age { get; set; }

        [StringLength(10)]
        public string Sex { get; set; }

        [StringLength(10)]
        public string IsWedding { get; set; }

        [StringLength(20)]
        public string Politics { get; set; }

        [StringLength(50)]
        public string ID_Card { get; set; }

        [StringLength(20)]
        public string Nation { get; set; }

        [StringLength(255)]
        public string Native_Place { get; set; }

        [StringLength(20)]
        public string Degree { get; set; }

        [StringLength(50)]
        public string Major { get; set; }

        [StringLength(50)]
        public string School { get; set; }

        public DateTime? Date_Of_Birth { get; set; }

        public DateTime? Entry_Date { get; set; }

        public DateTime? Termination_Date { get; set; }

        [StringLength(5)]
        public string IsWork { get; set; }

        [StringLength(20)]
        public string QQ { get; set; }

        [StringLength(30)]
        public string Email_Address { get; set; }

        [StringLength(30)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Present_Assress { get; set; }

        [Column(TypeName = "text")]
        public string Emergency_Contact { get; set; }

        [StringLength(50)]
        public string Emergency_Phone { get; set; }

        [Column(TypeName = "text")]
        public string Resume { get; set; }

        [Column(TypeName = "text")]
        public string Remark { get; set; }

        [StringLength(50)]
        public string Permission { get; set; }

        [StringLength(300)]
        public string R1 { get; set; }

        [StringLength(300)]
        public string R2 { get; set; }

        [StringLength(300)]
        public string R3 { get; set; }

        [StringLength(300)]
        public string R4 { get; set; }

        [StringLength(300)]
        public string R5 { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal USI_ID { get; set; }
    }
}
