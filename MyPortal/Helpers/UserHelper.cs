﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Microsoft.AspNet.Identity;
using MyPortal.Models;

namespace MyPortal.Helpers
{    
    public static class UserHelper
    {
        private static readonly ApplicationDbContext _identity;

        static UserHelper()
        {
            _identity = new ApplicationDbContext();
        }

        public static ApplicationUser GetApplicationUser(this IPrincipal user)
        {
            if (user.Identity.Name == "test")
            {
                return new ApplicationUser
                {
                    Id = "1",
                    SelectedAcademicYearId = 1,
                    PasswordHash = "test",
                    UserName = "test"
                };
            }
            var userId = user.Identity.GetUserId();
            var applicationUser = _identity.Users.SingleOrDefault(x => x.Id == userId);

            return applicationUser;
        }

        public static int? GetSelectedAcademicYearId(this IPrincipal user)
        {
            var userId = user.Identity.GetUserId();
            var applicationUser = _identity.Users.SingleOrDefault(x => x.Id == userId);

            if (applicationUser == null)
            {
                throw new Exception("User not found.");
            }

            return applicationUser.SelectedAcademicYearId;
        }

        public static void ChangeSelectedAcademicYear(this IPrincipal user, int academicYearId)
        {
            var applicationUser = GetApplicationUser(user);

            if (applicationUser == null)
            {
                throw new Exception("User not found");
            }

            applicationUser.SelectedAcademicYearId = academicYearId;

            _identity.SaveChanges();
        }
    }
}