﻿using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using MyPortal.BusinessLogic.Models.Data;
using MyPortal.Models.Identity;

namespace MyPortal.Areas.Staff.ViewModels
{
    public class UserDetailsViewModel
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<ApplicationRole> UserRoles { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
        public ChangePasswordModel ChangePassword { get; set; }
        public UserRoleModel ChangeRole { get; set; }
        public string AttachedProfileName { get; set; }
    }
}