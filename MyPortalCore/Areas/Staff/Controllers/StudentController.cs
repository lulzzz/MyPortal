﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGeneration.DotNet;
using MyPortal.Database.Constants;
using MyPortal.Database.Models.Filters;
using MyPortal.Database.Search;
using MyPortal.Logic.Constants;
using MyPortal.Logic.Helpers;
using MyPortal.Logic.Interfaces;
using MyPortalCore.Areas.Staff.ViewModels.Student;
using TaskStatus = MyPortal.Database.Search.TaskStatus;

namespace MyPortalCore.Areas.Staff.Controllers
{
    public class StudentController : StaffPortalController
    {
        private IStudentService _studentService;
        private IPersonService _personService;
        private ILogNoteService _logNoteService;
        private IDocumentService _documentService;
        private IAchievementService _achievementService;
        private IIncidentService _incidentService;
        private IAttendanceMarkService _attendanceMarkService;
        private ITaskService _taskService;

        public StudentController(IStudentService studentService, IPersonService personService, ILogNoteService logNoteService, IApplicationUserService userService, IDocumentService documentService, IAchievementService achievementService, IIncidentService incidentService, IAttendanceMarkService attendanceMarkService, ITaskService taskService) : base(userService)
        {
            _studentService = studentService;
            _personService = personService;
            _logNoteService = logNoteService;
            _documentService = documentService;
            _achievementService = achievementService;
            _incidentService = incidentService;
            _attendanceMarkService = attendanceMarkService;
            _taskService = taskService;
        }

        
        public async Task<IActionResult> Index()
        {
            return await ProcessAsync(async () =>
            {
                var viewModel = new StudentSearchViewModel();
                viewModel.SearchTypes = _studentService.GetStudentStatusOptions();
                viewModel.GenderOptions = _personService.GetGenderOptions();

                return View("BrowseStudents", viewModel);
            });
        }

        #region Student Profile

        [Route("{studentId}")]
        public async Task<IActionResult> StudentProfileOverview(Guid studentId)
        {
            var user = await _userService.GetUserByPrincipal(User);

            if (user.SelectedAcademicYearId == null)
            {
                return BadRequest("No academic year has been selected.");
            }

            var academicYearId = (Guid)user.SelectedAcademicYearId;

            var viewModel = new StudentOverviewViewModel();

            viewModel.Student = await _studentService.GetById(studentId);
            viewModel.LogNotes =
                (await _logNoteService.GetByStudent(studentId, academicYearId)).OrderByDescending(x => x.CreatedDate).Select(x =>
                    x.ToListModel());
            viewModel.Tasks =
                (await _taskService.GetByPerson(viewModel.Student.PersonId)).OrderBy(x => x.DueDate).Select(x =>
                    x.ToListModel(false));
            viewModel.LogNoteTypes = (await _logNoteService.GetTypes()).ToSelectList();
            viewModel.TaskTypes = (await _taskService.GetTypes(false)).ToSelectList("Select Task Type");
            viewModel.AchievementPoints = await _achievementService.GetPointsByStudent(studentId, academicYearId);

            var attendanceSummary = await _attendanceMarkService.GetSummaryByStudent(studentId, academicYearId, true);

            if (attendanceSummary.Valid)
            {
                viewModel.Attendance = attendanceSummary.GetPresentAndApproved();
            }

            return View("StudentProfile/StudentOverview", viewModel);
        }

        [Route("{studentId}/Documents")]
        public async Task<IActionResult> StudentProfileDocuments(Guid studentId)
        {
            var viewModel = new StudentDocumentsViewModel();

            var docTypeFilter = new DocumentTypeFilter();

            docTypeFilter.Active = true;
            docTypeFilter.Student = true;

            viewModel.Student = await _studentService.GetById(studentId);
            viewModel.DocumentTypes =
                (await _documentService.GetTypes(docTypeFilter)).ToSelectList();

            return View("StudentProfile/Documents", viewModel);
        }

        [Route("{studentId}/Behaviour")]
        public async Task<IActionResult> StudentBehaviour(Guid studentId)
        {
            var viewModel = new StudentBehaviourManagementViewModel();

            viewModel.Student = await _studentService.GetById(studentId);
            viewModel.AchievementTypes = (await _achievementService.GetTypes()).ToSelectList();
            viewModel.AchievementOutcomes = (await _achievementService.GetOutcomes()).ToSelectList();
            viewModel.IncidentOutcomes = (await _incidentService.GetOutcomes()).ToSelectList();
            viewModel.IncidentTypes = (await _incidentService.GetTypes()).ToSelectList();
            viewModel.IncidentStatus = (await _incidentService.GetStatus()).ToSelectList();

            return View("StudentProfile/BehaviourManagement", viewModel);
        }

        #endregion
    }
}