﻿using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Mvc;
using MyPortal.Areas.Staff.ViewModels;
using MyPortal.Areas.Students.ViewModels;
using MyPortal.Attributes.MvcAuthorise;
using MyPortal.BusinessLogic.Dtos;
using MyPortal.BusinessLogic.Models.Identity;
using MyPortal.BusinessLogic.Services;
using MyPortal.BusinessLogic.Services.Identity;
using MyPortal.Controllers;

namespace MyPortal.Areas.Staff.Controllers
{
    [UserType(UserType.Staff)]
    [RouteArea("Staff")]
    [RoutePrefix("Students")]
    public class StudentsController : MyPortalController
    {
        [RequiresPermission("ViewStudents")]
        [Route("")]
        public ActionResult Students()
        {
            return View();
        }

        [RequiresPermission("EditStudents")]
        [Route("NewStudent")]
        public ActionResult NewStudent()
        {
            var viewModel = new NewStudentViewModel
                {
                    
                };

                return View(viewModel);
        }

        [HttpPost]
        [RequiresPermission("EditStudents")]
        public async Task<ActionResult> SaveStudent(StudentDto student)
        {
            using (var studentService = new StudentService())
            {
                await studentService.UpdateStudent(student);

                return RedirectToAction("StudentOverview", new { id = student.Id });
            }
        }

        
        [RequiresPermission("ViewStudents")]
        [Route("{studentId:int}")]
        public async Task<ActionResult> StudentOverview(int studentId)
        {
            using (var behaviourService = new BehaviourService())
            using (var attendanceService = new AttendanceService())
            using (var profilesService = new ProfilesService())
            using (var studentService = new StudentService())
            {
                var student = await studentService.GetStudentById(studentId);

                var logTypes = await profilesService.GetAllLogTypesLookup();

                var commentBanks = await profilesService.GetAllCommentBanksLookup();

                var academicYearId = await User.GetSelectedOrCurrentAcademicYearId();

                double? attendance = null;

                var attendanceData = await attendanceService.GetSummary(student.Id, academicYearId, true);

                if (attendanceData != null)
                {
                    attendance = attendanceData.Present + attendanceData.ApprovedEdActivity;
                }

                int? achievementCount = await behaviourService.GetAchievementPointsCountByStudent(student.Id, academicYearId);

                int? behaviourCount = await behaviourService.GetBehaviourPointsCountByStudent(student.Id, academicYearId);

                var viewModel = new StudentOverviewViewModel
                {

                    Student = student,
                    LogTypes = logTypes,
                    BehaviourCount = behaviourCount,
                    AchievementCount = achievementCount,
                    HasAttendanceData = attendance != null,
                    CommentBanks = commentBanks,
                    Attendance = attendance,
                };

                return View(viewModel);
            }
        }

        [RequiresPermission("EditStudents")]
        [Route("{studentId:int}/Details", Name = "PeopleStudentExtendedDetails")]
        public async Task<ActionResult> StudentDetails(int studentId)
        {
            using (var communicationService =  new CommunicationService())
            using (var pastoralService = new PastoralService())
            using (var peopleService = new PeopleService())
            using (var studentService = new StudentService())
            {
                var student = await studentService.GetStudentById(studentId);

                var yearGroups = await pastoralService.GetAllYearGroupsLookup();

                var regGroups = await pastoralService.GetAllRegGroupsLookup();

                var houses = await pastoralService.GetAllHousesLookup();

                var phoneNumberTypes = await communicationService.GetPhoneNumberTypesLookup();

                var genders = peopleService.GetGendersLookup();

                var viewModel = new StudentDetailsViewModel
                {
                    Student = student,
                    YearGroups = yearGroups,
                    RegGroups = regGroups,
                    Houses = houses,
                    PhoneNumberTypes = phoneNumberTypes,
                    Genders = genders
                };

                return View(viewModel);
            }
        }

        [RequiresPermission("ViewStudents")]
        [Route("{studentId:int}/Results", Name = "PeopleStudentAssessmentResults")]
        public async Task<ActionResult> StudentResults(int studentId)
        {
            using (var curriculumService = new CurriculumService())
            using (var assessmentService = new AssessmentService())
            using (var studentService = new StudentService())
            {
                var student = await studentService.GetStudentById(studentId);

                var resultSets = await assessmentService.GetResultSetsByStudent(studentId);

                var subjects = await curriculumService.GetAllSubjects();

                var viewModel = new StudentResultsViewModel
                {
                    Student = student,
                    ResultSets = resultSets,
                    Subjects = subjects
                };

                return View(viewModel);
            }
        }

        [RequiresPermission("ViewBehaviour")]
        [Route("{studentId:int}/Behaviour")]
        public async Task<ActionResult> BehaviourManagement(int studentId)
        {
            using (var systemService = new SystemService())
            using (var behaviourService = new BehaviourService())
            using (var studentService = new StudentService())
            {
                var student = await studentService.GetStudentById(studentId);

                var achievementTypes = await behaviourService.GetAchievementTypes();

                var behaviourTypes = await behaviourService.GetBehaviourIncidentTypes();

                var locations = await systemService.GetLocations();

                var viewModel = new StudentBehaviourManagementViewModel
                {
                    AchievementTypes = achievementTypes,
                    BehaviourTypes = behaviourTypes,
                    Locations = locations,
                    Student = student
                };

                return View(viewModel);
            }
        }
    }
}