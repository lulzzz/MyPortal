﻿using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyPortal.Models;
using MyPortal.Models.Database;
using MyPortal.ViewModels;

namespace MyPortal.Controllers
{
    //MyPortal Admin Portal Controller --> Controller methods for Admin Portal
    [Authorize(Roles = "Admin")]
    [RoutePrefix("Staff")]
    public class AdminController : Controller
    {
        private readonly MyPortalDbContext _context;
        private readonly IdentityContext _identity;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController()
        {
            _context = new MyPortalDbContext();
            _identity = new IdentityContext();
            var store = new UserStore<ApplicationUser>(_identity);
            _userManager = new UserManager<ApplicationUser>(store);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
                _identity.Dispose();
                _userManager.Dispose();
            }

            base.Dispose(disposing);
        }

        // Admin | Users | New User --> New User Form
        [Route("Admin/Users/New")]
        public ActionResult NewUser()
        {
            return View();
        }

        // Admin | Users | X --> User Details (for User X)
        [Route("Admin/Users/{id}")]
        public ActionResult UserDetails(string id)
        {
            var user = _identity.Users
                .SingleOrDefault(x => x.Id == id);

            if (user == null)
                return HttpNotFound();

            var userRoles = _userManager.GetRolesAsync(id).Result;

            var roles = _identity.Roles.OrderBy(x => x.Name).ToList();

            var attachedProfile = "";

            var studentProfile = _context.Students.SingleOrDefault(x => x.Person.UserId == user.Id);
            var staffProfile = _context.StaffMembers.SingleOrDefault(x => x.Person.UserId == user.Id);

            if (studentProfile != null)
                attachedProfile = studentProfile.Person.LastName + ", " + studentProfile.Person.FirstName + " (Student)";

            else if (staffProfile != null)
                attachedProfile = staffProfile.Person.LastName + ", " + staffProfile.Person.FirstName + " (Staff)";

            var viewModel = new UserDetailsViewModel
            {
                User = user,
                UserRoles = userRoles,
                Roles = roles,
                AttachedProfileName = attachedProfile
            };

            return View(viewModel);
        }

        // Admin | Users --> Users List (All)
        [Route("Admin/Users")]
        public ActionResult Users()
        {
            return View();
        }
    }
}