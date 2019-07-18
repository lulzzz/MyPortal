﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MyPortal.Dtos;
using MyPortal.Dtos.LiteDtos;
using MyPortal.Dtos.ViewDtos;
using MyPortal.Models.Database;
using MyPortal.Models.Exceptions;
using MyPortal.Models.Misc;

namespace MyPortal.Processes
{
    public static class AttendanceProcesses
    {
        public static ProcessResponse<bool> VerifyAttendanceCodes(this MyPortalDbContext context, ListContainer<AttendanceRegisterMark> register)
        {
            var codesVerified = true;
            var codes = context.AttendanceCodes.ToList();

            foreach (var mark in register.Objects)
            {
                if (!codesVerified)
                {
                    break;
                }

                if (codes.All(x => x.Code != mark.Mark))
                {
                    codesVerified = false;
                }
            }

            return new ProcessResponse<bool>(ResponseType.Ok, null, codesVerified);
        }

        public static ProcessResponse<AttendanceRegisterMark> GetAttendanceMark(MyPortalDbContext context, AttendanceWeek attendanceWeek, AttendancePeriod period, Student student)
        {
            var mark = context.AttendanceMarks.SingleOrDefault(x =>
                x.PeriodId == period.Id && x.WeekId == attendanceWeek.Id && x.StudentId == student.Id);

            if (mark == null)
            {                
                if (student == null || period == null || attendanceWeek == null)
                {
                    return null;
                }

                mark = new AttendanceRegisterMark
                {
                    Student = student,
                    Mark = "-",
                    WeekId = attendanceWeek.Id,
                    AttendanceWeek = attendanceWeek,
                    PeriodId = period.Id,
                    StudentId = student.Id,
                    AttendancePeriod = period
                };
            }

            return new ProcessResponse<AttendanceRegisterMark>(ResponseType.Ok, null, mark);
        }

        public static IEnumerable<AttendanceRegisterMarkLite> PrepareLiteMarkList(MyPortalDbContext context, List<AttendanceRegisterMark> marks, bool retrieveMeanings)
        {
            var liteMarks = marks.OrderBy(x => x.AttendancePeriod.StartTime)
                .Select(Mapper.Map<AttendanceRegisterMark, AttendanceRegisterMarkLite>).ToList();

            foreach (var mark in liteMarks)
            {
                var meaning = GetMeaning(context, mark.Mark);

                if (meaning == null)
                {
                    continue;
                }

                if (retrieveMeanings)
                {
                    mark.MeaningCode = meaning.Code;
                }                
            }

            return liteMarks;
        }

        public static AttendanceRegisterCodeMeaning GetMeaning(MyPortalDbContext context, string mark)
        {
            var codeInDb = context.AttendanceCodes.SingleOrDefault(x => x.Code == mark);

            return codeInDb?.AttendanceRegisterCodeMeaning;
        }

        public static ProcessResponse<AttendanceSummary> GetSummary(int studentId, int academicYearId, MyPortalDbContext context, bool asPercentage = false)
        {
            var marksForStudent = context.AttendanceMarks.Where(x =>
                x.AttendanceWeek.AcademicYearId == academicYearId && x.StudentId == studentId);

            if (!marksForStudent.Any())
            {
                throw new ProcessException("No attendance data.", ExceptionType.BadRequest);
            }

            var summary = new AttendanceSummary();

            foreach (var mark in marksForStudent)
            {
                var meaning = GetMeaning(context, mark.Mark);

                if (meaning == null)
                {
                    continue;
                }

                switch (meaning.Code)
                {
                    case "P":
                        summary.Present++;
                        break;
                    case "AA":
                        summary.AuthorisedAbsence++;
                        break;
                    case "AEA":
                        summary.ApprovedEdActivity++;
                        break;
                    case "UA":
                        summary.UnauthorisedAbsence++;
                        break;
                    case "ANR":
                        summary.NotRequired++;
                        break;
                    case "L":
                        summary.Late++;
                        break;
                }
            }

            if (asPercentage)
            {
                summary.ConvertToPercentage();
            }

            return new ProcessResponse<AttendanceSummary>(ResponseType.Ok, null, summary);
        }

        public static ProcessResponse<IEnumerable<StudentRegisterMarksDto>> GetMarksForRegister(int academicYearId, int weekId,
            int classPeriodId, MyPortalDbContext context)
        {
            var attendanceWeek =
                context.AttendanceWeeks.SingleOrDefault(x => x.Id == weekId && x.AcademicYearId == academicYearId);

            if (attendanceWeek == null)
            {
                return new ProcessResponse<IEnumerable<StudentRegisterMarksDto>>(ResponseType.NotFound, "Attendance week not found", null);
            }

            var currentPeriod = context.CurriculumSessions.SingleOrDefault(x => x.Id == classPeriodId);

            if (currentPeriod == null)
            {
                return new ProcessResponse<IEnumerable<StudentRegisterMarksDto>>(ResponseType.NotFound, "Period not found", null);
            }

            var periodsInDay = context.AttendancePeriods.Where(x => x.Weekday == currentPeriod.AttendancePeriod.Weekday).ToList();

            var markList = new List<StudentRegisterMarksDto>();

            foreach (var enrolment in currentPeriod.CurriculumClass.Enrolments)
            {
                var markObject = new StudentRegisterMarksDto();
                var student = enrolment.Student;
                markObject.Student = Mapper.Map<Student, StudentDto>(student);
                var marks = new List<AttendanceRegisterMark>();

                foreach (var period in periodsInDay)
                {
                    var mark = GetAttendanceMark(context, attendanceWeek, period, student).ResponseObject;

                    marks.Add(mark);
                }

                var liteMarks = PrepareLiteMarkList(context, marks, true);

                markObject.Marks = liteMarks;
                markList.Add(markObject);
            }

            return new ProcessResponse<IEnumerable<StudentRegisterMarksDto>>(ResponseType.Ok, null,
                markList.ToList().OrderBy(x => x.Student.Person.LastName));
        }

        public static ProcessResponse<IEnumerable<AttendancePeriodDto>> GetAllPeriods(MyPortalDbContext context)
        {
            var dayIndex = new List<string> {"Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"};
            return new ProcessResponse<IEnumerable<AttendancePeriodDto>>(ResponseType.Ok, null,
                context.AttendancePeriods.ToList().OrderBy(x => dayIndex.IndexOf(x.Weekday))
                    .ThenBy(x => x.StartTime).Select(Mapper.Map<AttendancePeriod, AttendancePeriodDto>));
        }

        public static ProcessResponse<AttendancePeriodDto> GetPeriod(int periodId, MyPortalDbContext context)
        {
            var period = context.AttendancePeriods.SingleOrDefault(x => x.Id == periodId);

            if (period == null)
            {
                return new ProcessResponse<AttendancePeriodDto>(ResponseType.NotFound, "Period not found", null);
            }

            return new ProcessResponse<AttendancePeriodDto>(ResponseType.Ok, null,
                Mapper.Map<AttendancePeriod, AttendancePeriodDto>(period));
        }

        public static ProcessResponse<object> CreateAttendanceWeeksForYear(int academicYearId,
            MyPortalDbContext context)
        {
            var academicYear = context.CurriculumAcademicYears.SingleOrDefault(x => x.Id == academicYearId);

            if (academicYear == null)
            {
                return new ProcessResponse<object>(ResponseType.NotFound, "Academic year not found", null);
            }

            var pointer = academicYear.FirstDate;
            while (pointer < academicYear.LastDate)
            {
                var weekBeginning = pointer.StartOfWeek();

                if (context.AttendanceWeeks.Any(x => x.Beginning == weekBeginning))
                {
                    continue;
                }

                var attendanceWeek = new AttendanceWeek()
                {
                    AcademicYearId = academicYear.Id,
                    Beginning = weekBeginning
                };

                context.AttendanceWeeks.Add(attendanceWeek);
                
                pointer = weekBeginning.AddDays(7);
            }

            context.SaveChanges();

            return new ProcessResponse<object>(ResponseType.Ok, "Attendance weeks added for academic year", null);
        }

        public static ProcessResponse<AttendanceWeekDto> GetWeekByDate(int academicYearId, DateTime date, MyPortalDbContext context)
        {
            var weekBeginning = date.StartOfWeek();

            var selectedWeek = context.AttendanceWeeks.SingleOrDefault(x => x.Beginning == weekBeginning && x.AcademicYearId == academicYearId);

            if (selectedWeek == null)
            {
                return new ProcessResponse<AttendanceWeekDto>(ResponseType.NotFound, "Attendance week not found", null);
            }

            return new ProcessResponse<AttendanceWeekDto>(ResponseType.Ok, null,
                Mapper.Map<AttendanceWeek, AttendanceWeekDto>(selectedWeek));
        }
    }
}