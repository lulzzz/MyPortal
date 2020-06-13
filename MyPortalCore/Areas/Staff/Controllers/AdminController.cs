﻿using System;
using Microsoft.AspNetCore.Mvc;
using MyPortal.Database.Constants;
using MyPortal.Logic.Authorisation.Attributes;
using MyPortal.Logic.Constants;
using MyPortal.Logic.Interfaces;
using MyPortalCore.Areas.Staff.ViewModels.Admin;

namespace MyPortalCore.Areas.Staff.Controllers
{
    public class AdminController : BaseController
    {
        private IApplicationRoleService _applicationRoleService;

        public AdminController(IApplicationRoleService applicationRoleService, IApplicationUserService userService) : base(userService)
        {
            _applicationRoleService = applicationRoleService;
        }

        [Route("Roles")]
        [RequiresPermission(Permissions.System.Roles.Edit)]
        public IActionResult Roles()
        {
            var viewModel = new RolesViewModel();
            return View(viewModel);
        }
    }
}