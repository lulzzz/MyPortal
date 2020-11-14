﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using MyPortal.Database.BaseTypes;
using MyPortal.Database.Interfaces;

namespace MyPortal.Database.Models
{
    [Table("HomeworkSubmissions")]
    public class HomeworkSubmission : Entity
    {
        [Column(Order = 1)]
        public Guid HomeworkId { get; set; }

        [Column(Order = 2)]
        public Guid StudentId { get; set; }

        [Column(Order = 3)]
        public Guid TaskId { get; set; }

        [Column(Order = 4)] 
        public Guid? DocumentId { get; set; }

        [Column(Order = 5)]
        public int MaxPoints { get; set; }

        [Column(Order = 6)]
        public int PointsAchieved { get; set; }

        [Column(Order = 7)]
        public string Comments { get; set; }

        public virtual HomeworkItem HomeworkItem { get; set; }
        public virtual Student Student { get; set; }
        public virtual Task Task { get; set; }
        public virtual Document SubmittedWork { get; set; }
    }
}
