﻿using System;
using System.Collections.Generic;
using System.Text;
using MyPortal.Logic.Attributes;

namespace MyPortal.Logic.Models.Dtos
{
    public class AchievementDto
    {
        public int Id { get; set; }

        public int AcademicYearId { get; set; }

        public int AchievementTypeId { get; set; }

        public int StudentId { get; set; }

        public int LocationId { get; set; }

        public int RecordedById { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Comments { get; set; }

        [NotNegative]
        public int Points { get; set; }

        public bool Deleted { get; set; }

        public virtual AchievementTypeDto Type { get; set; }

        public virtual LocationDto Location { get; set; }

        public virtual AcademicYearDto AcademicYear { get; set; }

        public virtual StaffMemberDto RecordedBy { get; set; }

        public virtual StudentDto Student { get; set; }
    }
}