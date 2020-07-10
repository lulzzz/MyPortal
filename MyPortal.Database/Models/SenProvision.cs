﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using MyPortal.Database.Interfaces;

namespace MyPortal.Database.Models
{
    [Table("SenProvision")]
    public class SenProvision : IEntity
    {
        [Column(Order = 0)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column(Order = 1)]
        public Guid StudentId { get; set; }

        [Column(Order = 2)]
        public Guid ProvisionTypeId { get; set; }

        [Column(Order = 3, TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(Order = 4, TypeName = "date")]
        public DateTime EndDate { get; set; }

        [Column(Order = 5)]
        [Required]
        public string Note { get; set; }

        public virtual Student Student { get; set; }

        public virtual SenProvisionType Type { get; set; }
    }
}