﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using MyPortal.Database.Helpers;
using MyPortal.Database.Interfaces;
using MyPortal.Database.Interfaces.Repositories;
using MyPortal.Database.Models;
using MyPortal.Database.Models.Entity;
using MyPortal.Database.Repositories.Base;
using SqlKata;
using Task = System.Threading.Tasks.Task;

namespace MyPortal.Database.Repositories
{
    public class AttendanceMarkRepository : BaseReadWriteRepository<AttendanceMark>, IAttendanceMarkRepository
    {
        public AttendanceMarkRepository(ApplicationDbContext context) : base(context, "AttendanceMark")
        {
       
        }

        protected override void SelectAllRelated(Query query)
        {
            query.SelectAllColumns(typeof(Student), "Student");
            query.SelectAllColumns(typeof(Person), "StudentPerson");
            query.SelectAllColumns(typeof(AttendanceWeek), "AttendanceWeek");
            query.SelectAllColumns(typeof(AttendanceWeekPattern), "AttendanceWeekPattern");
            query.SelectAllColumns(typeof(AttendancePeriod), "Period");

            JoinRelated(query);
        }

        protected override void JoinRelated(Query query)
        {
            query.LeftJoin("Students as Student", "Student.Id", "AttendanceMark.StudentId");
            query.LeftJoin("People as StudentPerson", "StudentPerson.Id", "Student.PersonId");
            query.LeftJoin("AttendanceWeeks as AttendanceWeek", "AttendanceWeek.Id", "AttendanceMark.WeekId");
            query.LeftJoin("AttendanceWeekPatterns as AttendanceWeekPattern", "AttendanceWeekPattern.Id", "AttendanceWeek.WeekPatternId");
            query.LeftJoin("AttendancePeriods AS Period", "Period.Id", "AttendanceMark.PeriodId");
        }

        protected override async Task<IEnumerable<AttendanceMark>> ExecuteQuery(Query query)
        {
            var sql = Compiler.Compile(query);

            return await Connection.QueryAsync<AttendanceMark, Student, Person, AttendanceWeek, AttendanceWeekPattern, AttendancePeriod, AttendanceMark>(
                sql.Sql,
                (mark, student, person, week, pattern, period) =>
                {
                    mark.Student = student;
                    mark.Student.Person = person;
                    mark.Week = week;
                    mark.Week.WeekPattern = pattern;
                    mark.AttendancePeriod = period;

                    return mark;
                }, sql.NamedBindings);
        }

        public async Task<IEnumerable<AttendanceMark>> GetByStudent(Guid studentId, Guid academicYearId)
        {
            var query = GenerateQuery();

            query.Where("Student.Id", "=", studentId);
            query.Where("AttendanceWeekPattern.AcademicYearId", "=", academicYearId);

            return await ExecuteQuery(query);
        }

        public async Task<AttendanceMark> Get(Guid studentId, Guid attendanceWeekId, Guid periodId)
        {
            var query = GenerateQuery();

            query.Where("Student.Id", "=", studentId);

            query.Where("AttendanceWeek.Id", "=", attendanceWeekId);

            query.Where("Period.Id", "=", periodId);

            return (await ExecuteQuery(query)).SingleOrDefault();
        }

        public async Task Update(AttendanceMark mark)
        {
            var columns = new List<string> {"Mark", "MinutesLate", "Comments"};

            var values = new List<object> {mark.Mark, mark.MinutesLate, mark.Comments};

            var query = new Query(TblName).Where("AttendanceMark.Id", "=", mark.Id).AsUpdate(columns, values);

            await ExecuteNonQuery(query);
        }
    }
}