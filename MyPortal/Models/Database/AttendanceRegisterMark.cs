namespace MyPortal.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Attendance_RegisterMarks")]
    public partial class AttendanceRegisterMark
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int WeekId { get; set; }

        public int PeriodId { get; set; }

        [Required]
        [StringLength(1)]
        public string Mark { get; set; }

        public virtual AttendancePeriod AttendancePeriod { get; set; }

        public virtual Student Student { get; set; }

        public virtual AttendanceWeek AttendanceWeek { get; set; }
    }
}
