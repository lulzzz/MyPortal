namespace MyPortal.Models.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Core_Documents")]
    public partial class CoreDocument
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CoreDocument()
        {
            CoreStaffDocuments = new HashSet<CoreStaffDocument>();
            CoreStudentDocuments = new HashSet<CoreStudentDocument>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string Url { get; set; }

        public int UploaderId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public bool IsGeneral { get; set; }

        public bool Approved { get; set; }

        public virtual CoreStaffMember Uploader { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CoreStaffDocument> CoreStaffDocuments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CoreStudentDocument> CoreStudentDocuments { get; set; }
    }
}
