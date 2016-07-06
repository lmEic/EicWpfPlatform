namespace Lm.Eic.App.Mes.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class OQC_Pack3D
    {
        [Required]
        [StringLength(25)]
        public string SN { get; set; }

        [StringLength(35)]
        public string Name { get; set; }

        [StringLength(35)]
        public string Type { get; set; }

        [StringLength(8)]
        public string Result { get; set; }

        [StringLength(6)]
        public string Curvature { get; set; }

        [StringLength(15)]
        public string Curvature_Result { get; set; }

        [StringLength(6)]
        public string Spherical { get; set; }

        [StringLength(15)]
        public string Spherical_Result { get; set; }

        [StringLength(6)]
        public string Planar { get; set; }

        [StringLength(15)]
        public string Planar_Result { get; set; }

        [StringLength(6)]
        public string Apex_Offset { get; set; }

        [StringLength(15)]
        public string Apex_Offset_Result { get; set; }

        [StringLength(6)]
        public string Bearing { get; set; }

        [StringLength(15)]
        public string Bearing_Result { get; set; }

        [StringLength(6)]
        public string Apex_Angle { get; set; }

        [StringLength(15)]
        public string Apex_Angle_Result { get; set; }

        [StringLength(6)]
        public string Tilt_Offset { get; set; }

        [StringLength(15)]
        public string Tilt_Offset_Result { get; set; }

        [StringLength(6)]
        public string Tilt_Angle { get; set; }

        [StringLength(15)]
        public string Tilt_Angle_Result { get; set; }

        [StringLength(6)]
        public string KeyError { get; set; }

        [StringLength(15)]
        public string KeyError_Result { get; set; }

        [StringLength(6)]
        public string FiberRq { get; set; }

        [StringLength(15)]
        public string FiberRq_Result { get; set; }

        [StringLength(6)]
        public string FiberRa { get; set; }

        [StringLength(15)]
        public string FiberRa_Result { get; set; }

        [StringLength(6)]
        public string FerruleRq { get; set; }

        [StringLength(15)]
        public string FerruleRq_Result { get; set; }

        [StringLength(6)]
        public string FerruleRa { get; set; }

        [StringLength(15)]
        public string FerruleRa_Result { get; set; }

        [StringLength(6)]
        public string Diameter { get; set; }

        [StringLength(15)]
        public string Diameter_Result { get; set; }

        [StringLength(35)]
        public string Test_Date { get; set; }

        [StringLength(35)]
        public string Test_Time { get; set; }

        [StringLength(15)]
        public string D { get; set; }

        [StringLength(15)]
        public string E { get; set; }

        [StringLength(15)]
        public string F { get; set; }

        [StringLength(15)]
        public string A { get; set; }

        [StringLength(20)]
        public string PackLot { get; set; }

        [StringLength(35)]
        public string PackDate { get; set; }

        [StringLength(35)]
        public string CustomerName { get; set; }

        [StringLength(25)]
        public string ClientSN { get; set; }

        [StringLength(25)]
        public string OrderID { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID_Key { get; set; }
    }
}