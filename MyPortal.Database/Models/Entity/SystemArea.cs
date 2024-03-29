﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortal.Database.Models.Entity
{
    [Table("SystemAreas")]
    public class SystemArea : BaseTypes.Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SystemArea()
        {
            Reports = new HashSet<Report>();
            SubAreas = new HashSet<SystemArea>();
        }

        [Column(Order = 1)]
        [Required]
        [StringLength(128)]
        public string Description { get; set; }

        [Column(Order = 2)]
        public Guid? ParentId { get; set; }

        public virtual SystemArea Parent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Report> Reports { get; set; }

        public virtual ICollection<SystemArea> SubAreas { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}