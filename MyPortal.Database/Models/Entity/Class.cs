using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortal.Database.Models.Entity
{
    [Table("Classes")]
    public class Class : BaseTypes.Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Class()
        {
            Sessions = new HashSet<Session>();
        }

        [Column(Order = 1)]
        public Guid CourseId { get; set; }

        [Column (Order = 2)]
        public Guid GroupId { get; set; }

        [Column (Order = 3)]
        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        public virtual Course Course { get; set; }
        public virtual CurriculumGroup Group { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
