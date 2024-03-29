﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyPortal.Database.Attributes;

namespace MyPortal.Database.Models.Entity
{
    public static class Gender
    {
        public const string Male = "M";
        public const string Female = "F";
        public const string Other = "X";
        public const string Unknown = "U";
    }

    [Table("People")]
    public class Person : BaseTypes.Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            PhoneNumbers = new HashSet<PhoneNumber>();
            MedicalConditions = new HashSet<PersonCondition>();
            DietaryRequirements = new HashSet<PersonDietaryRequirement>();
            HeadteacherOf = new HashSet<School>();
            EmailAddresses = new HashSet<EmailAddress>();
            Addresses = new HashSet<AddressPerson>();
            DiaryEventInvitations = new HashSet<DiaryEventAttendee>();
            AssignedTo = new HashSet<Task>();
        }

        [Column(Order = 1)]
        public Guid DirectoryId { get; set; }

        [Column(Order = 2)]
        [StringLength(128)]
        public string Title { get; set; }

        [Column(Order = 3)]
        [Required]
        [StringLength(256)]
        public string FirstName { get; set; }

        [Column(Order = 4)]
        [StringLength(256)] 
        public string MiddleName { get; set; }

        [Column(Order = 5)]
        [Required]
        [StringLength(256)]
        public string LastName { get; set; }

        [Column(Order = 6)]
        [StringLength(256)]
        public string ChosenFirstName { get; set; }

        [Column(Order = 8)]
        public Guid? PhotoId { get; set; }

        [Column(Order = 9)]
        [StringLength(10)]
        public string NhsNumber { get; set; }

        [Column(Order = 10)]
        public DateTime UpdatedDate { get; set; }

        [Column(Order = 11)]
        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        [Column(Order = 12, TypeName = "date")]
        public DateTime? Dob { get; set; }

        [Column(Order = 13, TypeName = "date")] 
        public DateTime? Deceased { get; set; }

        [Column(Order = 14)]
        public Guid? EthnicityId { get; set; }

        [Column(Order = 15)]
        public bool Deleted { get; set; }

        [EntityOnly]
        public virtual Contact ContactDetails { get; set; }

        public virtual Directory Directory { get; set; }

        [EntityOnly]
        public virtual StaffMember StaffMemberDetails { get; set; }

        [EntityOnly]
        public virtual Student StudentDetails { get; set; }

        [EntityOnly]
        public virtual Agent AgentDetails { get; set; }

        [EntityOnly]
        public virtual User User { get; set; }

        public virtual Photo Photo { get; set; }

        public virtual Ethnicity Ethnicity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonCondition> MedicalConditions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonDietaryRequirement> DietaryRequirements { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<School> HeadteacherOf { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmailAddress> EmailAddresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddressPerson> Addresses { get; set; }

        public virtual ICollection<DiaryEventAttendee> DiaryEventInvitations { get; set; }

        public virtual ICollection<Task> AssignedTo { get; set; }
    }
}