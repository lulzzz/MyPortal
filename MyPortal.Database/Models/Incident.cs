﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyPortal.Database.Models.Identity;

namespace MyPortal.Database.Models
{
    [Table("Incident")]
    public class Incident
    {
        public Incident()
        {
            Detentions = new HashSet<IncidentDetention>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid AcademicYearId { get; set; }

        public Guid BehaviourTypeId { get; set; }

        public Guid StudentId { get; set; }

        public Guid LocationId { get; set; }

        public Guid RecordedById { get; set; }

        public Guid? OutcomeId { get; set; }

        public Guid StatusId { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        public string Comments { get; set; }

        public int Points { get; set; }

        public bool Deleted { get; set; }

        public virtual IncidentType Type { get; set; }

        public virtual Location Location{ get; set; }

        public virtual AcademicYear AcademicYear { get; set; }

        public virtual ApplicationUser RecordedBy { get; set; } 

        public virtual Student Student { get; set; }

        public virtual BehaviourOutcome Outcome { get; set; }

        public virtual BehaviourStatus Status { get; set; }

        public virtual ICollection<IncidentDetention> Detentions { get; set; }
    }
}