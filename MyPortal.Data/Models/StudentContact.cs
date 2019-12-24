﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortal.Data.Models
{
    [Table("StudentContact", Schema = "person")]
    public class StudentContact
    {
        public int Id { get; set; }
        public int ContactTypeId { get; set; }
        public int StudentId { get; set; }
        public int ContactId { get; set; }

        public bool Correspondence { get; set; }
        public bool ParentalResponsibility { get; set; }
        public bool PupilReport { get; set; }
        public bool CourtOrder { get; set; }

        public virtual Student Student { get; set; }
        public virtual Contact Contact { get; set; }
    }
}