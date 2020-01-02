﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortal.Data.Models
{
    [Table("DiaryEvent", Schema = "system")]
    public class DiaryEvent
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Subject { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool IsAllDay { get; set; }

        public bool IsBlock { get; set; }

        public bool IsPublic { get; set; }

        public bool IsStudentVisible { get; set; }

        public virtual ICollection<Detention> Detentions { get; set; }
    }
}
