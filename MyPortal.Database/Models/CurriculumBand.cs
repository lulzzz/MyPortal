﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MyPortal.Database.Models
{
    [Table("CurriculumBand")]
    public class CurriculumBand
    {
        public CurriculumBand()
        {
            Enrolments = new HashSet<Enrolment>();
            AssignedBlocks = new HashSet<CurriculumBandBlock>();
        }

        [Column(Order = 0)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column(Order = 1)]
        public Guid AcademicYearId { get; set; }

        [Column(Order = 2)]
        public Guid CurriculumYearGroupId { get; set; }

        [Column(Order = 3)]
        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [Column(Order = 4)]
        [StringLength(256)]
        public string Description { get; set; }

        public virtual CurriculumYearGroup CurriculumYearGroup { get; set; }
        public virtual ICollection<Enrolment> Enrolments { get; set; }
        public virtual ICollection<CurriculumBandBlock> AssignedBlocks { get; set; }
    }
}