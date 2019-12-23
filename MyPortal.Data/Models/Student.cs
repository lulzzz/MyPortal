using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortal.Data.Models
{
    /// <summary>
    /// A student in the system.
    /// </summary>
    [Table("Student", Schema = "person")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Results = new HashSet<Result>();
            AttendanceMarks = new HashSet<AttendanceMark>();
            Achievements = new HashSet<Achievement>();
            Incidents = new HashSet<Incident>();
            Enrolments = new HashSet<Enrolment>();
            FinanceBasketItems = new HashSet<BasketItem>();
            Sales = new HashSet<Sale>();
            MedicalEvents = new HashSet<MedicalEvent>();
            SenEvents = new HashSet<SenEvent>();
            SenProvisions = new HashSet<SenProvision>();
            ProfileLogs = new HashSet<ProfileLogNote>();
            GiftedTalentedSubjects = new HashSet<GiftedTalented>();
            StudentContacts = new HashSet<StudentContact>();
        }

        public int Id { get; set; }

        public int PersonId { get; set; }

        public int RegGroupId { get; set; }

        public int YearGroupId { get; set; }

        public int? HouseId { get; set; }

        [StringLength(128)]
        public string CandidateNumber { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdmissionNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateStarting { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateLeaving { get; set; }

        public decimal AccountBalance { get; set; }

        public bool FreeSchoolMeals { get; set; }

        public bool GiftedAndTalented { get; set; }

        public int? SenStatusId { get; set; }

        public bool PupilPremium { get; set; }

        [StringLength(256)]
        public string MisId { get; set; }

        [StringLength(13)]
        public string Upn { get; set; }

        public string Uci { get; set; }

        public bool Deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Results { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttendanceMark> AttendanceMarks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Achievement> Achievements { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Incident> Incidents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Enrolment> Enrolments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BasketItem> FinanceBasketItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sales { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicalEvent> MedicalEvents { get; set; }

        public virtual RegGroup RegGroup { get; set; }

        public virtual YearGroup YearGroup { get; set; }

        public virtual Person Person { get; set; }

        public virtual SenStatus SenStatus { get; set; }

        public virtual House House { get; set; }    

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SenEvent> SenEvents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SenProvision> SenProvisions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentContact> StudentContacts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProfileLogNote> ProfileLogs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiftedTalented> GiftedTalentedSubjects { get; set; }
    }
}
