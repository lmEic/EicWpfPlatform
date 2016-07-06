namespace Lm.Eic.App.Mes.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Serializable]
    [Table("Bpm_Daily")]
    public class Bpm_Daily
    {
        [StringLength(50)]
        public string OrderID { get; set; }

        [StringLength(50)]
        public string ClientName { get; set; }

        [StringLength(150)]
        public string ProductID { get; set; }

        [StringLength(150)]
        public string ProductName { get; set; }

        [StringLength(150)]
        public string Spec { get; set; }

        public int? OrderCount { get; set; }

        [StringLength(150)]
        public string State { get; set; }

        [StringLength(8)]
        public string ActualEndDate { get; set; }

        [StringLength(50)]
        public string DailyNum { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        [StringLength(50)]
        public string WorkShop { get; set; }

        [StringLength(50)]
        public string Workstation { get; set; }

        [StringLength(50)]
        public string ClassType { get; set; }

        [StringLength(50)]
        public string JobNum { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Month { get; set; }

        public DateTime? Date { get; set; }

        public DateTime? DateTime { get; set; }

        public int? ProcessNum { get; set; }

        [StringLength(50)]
        public string ProcessID { get; set; }

        [StringLength(200)]
        public string ProcessName { get; set; }

        [StringLength(100)]
        public string ProcessSign { get; set; }

        public double? StandardHours { get; set; }

        public double? WorkHours { get; set; }

        public double? TotalWorkHoursNotRelax { get; set; }

        public double? TotalWorkHoursStandard { get; set; }

        public double? TotalWorkHoursPmc { get; set; }

        public double? NotWorkHours { get; set; }

        [StringLength(100)]
        public string NotWorkCause { get; set; }

        public int? Qty { get; set; }

        public int? QtyOK { get; set; }

        public int? QtyNG { get; set; }

        public double? Efficiency { get; set; }

        public double? Fpy { get; set; }

        [StringLength(20)]
        public string MasterJobNum { get; set; }

        [StringLength(20)]
        public string MasterName { get; set; }

        [StringLength(50)]
        public string EquipmentID { get; set; }

        [StringLength(20)]
        public string AssetNum { get; set; }

        [StringLength(100)]
        public string AssetName { get; set; }

        [StringLength(20)]
        public string MouldNum { get; set; }

        [StringLength(50)]
        public string MouldName { get; set; }

        public int? MouldCavityCount { get; set; }

        public int? MouldChangeCount { get; set; }

        public double? SetHours { get; set; }

        public double? InputHours { get; set; }

        public double? AttendanceHours { get; set; }

        public double? InputStorageCount { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID_Key { get; set; }
    }
}