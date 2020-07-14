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
    [Table("TaskType")]
    public class TaskType : LookupItem, ISystemEntity
    {
        public TaskType()
        {
            Tasks = new HashSet<Task>();
        }

        [Column(Order = 3)] 
        public bool Personal { get; set; }

        [Column(Order = 4)]
        [Required]
        public string ColourCode { get; set; }

        [Column(Order = 5)] 
        public bool System { get; set; }

        [Column(Order = 6)] 
        public bool Reserved { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}