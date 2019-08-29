﻿using System.Web.Mvc;
using MyPortal.Models;
using MyPortal.Models.Database;

namespace MyPortal.Controllers
{
    [AllowAnonymous]
    public class HomeController : MyPortalController
    {
        [Authorize]
        [Route("User/Home")]
        public ActionResult Home()
        {
            if (User.IsInRole("SeniorStaff") || User.IsInRole("Staff")) return RedirectToAction("Index", "Staff");

            if (User.IsInRole("Student")) return RedirectToAction("Index", "Students");

            return RedirectToAction("RestrictedAccess", "Account");
        }

        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.User != null &&
                System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                return RedirectToAction("Home", "Home");
            return View();
        }
    }
}