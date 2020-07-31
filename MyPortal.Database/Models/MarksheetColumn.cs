﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using MyPortal.Database.BaseTypes;
using MyPortal.Database.Interfaces;

namespace MyPortal.Database.Models
{
    [Table("MarksheetColumns")]
    public class MarksheetColumn : Entity
    {
        [Column(Order = 1)]
        public Guid TemplateId { get; set; }

        [Column(Order = 2)]
        public Guid AspectId { get; set; }

        [Column(Order = 3)]
        public Guid ResultSetId { get; set; }

        [Column(Order = 4)]
        public int DisplayOrder { get; set; }

        [Column(Order = 5)]
        public bool ReadOnly { get; set; }

        public virtual MarksheetTemplate Template { get; set; }
        public virtual Aspect Aspect { get; set; }
        public virtual ResultSet ResultSet { get; set; }
    }
}