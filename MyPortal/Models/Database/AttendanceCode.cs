namespace MyPortal.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// [SYSTEM] Codes available to use when taking the register.
    /// </summary>
    [Table("Attendance_Codes")]
    public partial class AttendanceCode
    {
        //THIS IS A SYSTEM CLASS AND SHOULD NOT HAVE FEATURES TO ADD, MODIFY OR DELETE DATABASE OBJECTS
        public int Id { get; set; }

        [Required]
        [StringLength(1)]
        public string Code { get; set; }

        [Required]
        public string Description { get; set; }

        public int MeaningId { get; set; }

        public bool System { get; set; }

        public bool DoNotUse { get; set; }

        public virtual AttendanceMeaning AttendanceMeaning { get; set; }
    }
}
