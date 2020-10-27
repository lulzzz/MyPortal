﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortal.Database.Constants;
using MyPortal.Database.Models.Search;
using MyPortal.Database.Permissions;
using MyPortal.Logic.Constants;
using MyPortal.Logic.Helpers;
using MyPortal.Logic.Interfaces;
using MyPortal.Logic.Models.DataGrid;

namespace MyPortalWeb.Controllers.Api
{
    [Authorize]
    public class StudentController : StudentApiController
    {
        public StudentController(IUserService userService, IAcademicYearService academicYearService, IStudentService studentService) : base(userService, academicYearService, studentService)
        {
            
        }
        
        [HttpGet]
        [Authorize(Policy = Policies.UserType.Staff)]
        [Route("Search")]
        public async Task<IActionResult> SearchStudents([FromQuery] StudentSearchOptions searchModel)
        {
            return await ProcessAsync(async () =>
            {
                IEnumerable<StudentDataGridModel> students;

                using (new ProcessTimer("Fetch students"))
                {
                    students = (await StudentService.Get(searchModel)).Select(x => x.GetDataGridModel());
                }

                return Ok(students);
            }, Permissions.Student.StudentDetails.ViewStudentDetails);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById([FromQuery] Guid studentId)
        {
            return await ProcessAsync(async () =>
            {
                if (await AuthenticateStudent(studentId))
                {
                    var student = await StudentService.GetById(studentId);

                    return Ok(student);
                }

                return Forbid();
            }, Permissions.Student.StudentDetails.ViewStudentDetails);
        }
    }
}