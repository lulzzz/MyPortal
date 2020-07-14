﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MyPortal.Database.Interfaces;

namespace MyPortal.Database.Models.Identity
{
    [Table("AspNetRolePermissions")]
    public class ApplicationRolePermission : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }

        public virtual ApplicationRole Role { get; set; }
        public virtual ApplicationPermission Permission { get; set; }
    }
}