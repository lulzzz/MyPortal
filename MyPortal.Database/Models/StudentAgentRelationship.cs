﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MyPortal.Database.BaseTypes;
using MyPortal.Database.Interfaces;

namespace MyPortal.Database.Models
{
    [Table("StudentAgentRelationships")]
    public class StudentAgentRelationship : Entity
    {
        [Column(Order = 2)]
        public Guid StudentId { get; set; }

        [Column(Order = 3)]
        public Guid AgentId { get; set; }

        [Column(Order = 4)]
        public Guid RelationshipTypeId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Agent Agent { get; set; }
        public virtual AgentRelationshipType RelationshipType { get; set; }
    }
}
