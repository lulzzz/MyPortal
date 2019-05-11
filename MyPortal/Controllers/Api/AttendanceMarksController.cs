﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Http;
using AutoMapper;
using MyPortal.Dtos;
using MyPortal.Dtos.LiteDtos;
using MyPortal.Dtos.ViewDtos;
using MyPortal.Helpers;
using MyPortal.Models.Database;
using MyPortal.Models.Misc;

namespace MyPortal.Controllers.Api
{    
    public class AttendanceMarksController : ApiController
    {
        private readonly MyPortalDbContext _context;

        public AttendanceMarksController()
        {
            _context = new MyPortalDbContext();
        }

        public AttendanceMarksController(MyPortalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/attendance/marks/loadRegister/{weekId}/{periodId}")]
        public IEnumerable<StudentRegisterMarksDto> LoadRegister(int weekId, int periodId)
        {
            var academicYearId = SystemHelper.GetCurrentOrSelectedAcademicYearId(User);

            var attendanceWeek =
                _context.AttendanceWeeks.SingleOrDefault(x => x.Id == weekId && x.AcademicYearId == academicYearId);

            if (attendanceWeek == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var currentPeriod = _context.CurriculumClassPeriods.SingleOrDefault(x => x.Id == periodId);

            if (currentPeriod == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var periodsInDay = _context.AttendancePeriods.Where(x => x.Weekday == currentPeriod.AttendancePeriod.Weekday).ToList();

            var registerClass =
                _context.CurriculumClasses.SingleOrDefault(x => x.AcademicYearId == academicYearId && x.Id == currentPeriod.ClassId);

            if (registerClass == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }            

            var markList = new List<StudentRegisterMarksDto>();

            foreach (var enrolment in registerClass.Enrolments)
            {
                var markObject = new StudentRegisterMarksDto();
                var student = enrolment.Student;
                markObject.Student = Mapper.Map<Student, StudentDto>(student);
                var marks = new List<AttendanceRegisterMark>();

                foreach (var period in periodsInDay)
                {
                    var mark = _context.AttendanceMarks.SingleOrDefault(x =>
                        x.PeriodId == period.Id && x.WeekId == attendanceWeek.Id && x.StudentId == student.Id);

                    if (mark == null)
                    {
                        mark = new AttendanceRegisterMark
                        {
                            Student = student,
                            Mark = "-",
                            WeekId = weekId,
                            AttendanceWeek = attendanceWeek,
                            PeriodId = period.Id,
                            StudentId = student.Id,
                            AttendancePeriod = period
                        };
                    }                               

                    marks.Add(mark);
                }

                
                var liteMarks = marks.OrderBy(x => x.AttendancePeriod.StartTime)
                    .Select(Mapper.Map<AttendanceRegisterMark, AttendanceRegisterMarkLite>);

                markObject.Marks = liteMarks;
                markList.Add(markObject);
            }

            return markList.ToList().OrderBy(x => x.Student.LastName);
        }
    }
}