﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using MyPortal.Database.BaseTypes;
using MyPortal.Database.Interfaces;

namespace MyPortal.Database.Models
{
    [Table("StudentContactRelationships")]
    public class StudentContactRelationship : Entity
    {
        [Column(Order = 1)]
        public Guid RelationshipTypeId { get; set; }

        [Column(Order = 2)]
        public Guid StudentId { get; set; }

        [Column(Order = 3)]
        public Guid ContactId { get; set; }

        [Column(Order = 4)]
        public bool Correspondence { get; set; }

        [Column(Order = 5)]
        public bool ParentalResponsibility { get; set; }

        [Column(Order = 6)]
        public bool PupilReport { get; set; }

        [Column(Order = 7)]
        public bool CourtOrder { get; set; }

        public virtual ContactRelationshipType RelationshipType { get; set; }
        public virtual Student Student { get; set; }
        public virtual Contact Contact { get; set; }
    }
}