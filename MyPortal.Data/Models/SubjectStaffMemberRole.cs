﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortal.Data.Models
{
    [Table("SubjectStaffMemberRole", Schema = "curriculum")]
    public class SubjectStaffMemberRole
    {
        public SubjectStaffMemberRole()
        {
            StaffMembers = new HashSet<SubjectStaffMember>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubjectStaffMember> StaffMembers { get; set; }
    }
}