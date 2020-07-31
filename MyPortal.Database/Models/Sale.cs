using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using MyPortal.Database.BaseTypes;
using MyPortal.Database.Interfaces;

namespace MyPortal.Database.Models
{
    [Table("Sales")]
    public class Sale : Entity
    {
        [Column(Order = 1)]
        public Guid StudentId { get; set; }

        [Column(Order = 2)]
        public Guid ProductId { get; set; }

        [Column(Order = 3)]
        public Guid AcademicYearId { get; set; }

        [Column(Order = 4)]
        public DateTime Date { get; set; }

        [Column(Order = 5, TypeName = "decimal(10,2)")]
        public decimal AmountPaid { get; set; }
        
        [Column(Order = 6)]
        public bool Processed { get; set; }

        [Column(Order = 7)]
        public bool Refunded { get; set; }

        [Column(Order = 8)]
        public bool Deleted { get; set; }

        public virtual Student Student { get; set; }

        public virtual AcademicYear AcademicYear { get; set; }

        public virtual Product Product { get; set; }
    }
}
