﻿using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using MyPortal.Database.Helpers;
using MyPortal.Database.Interfaces;
using MyPortal.Database.Interfaces.Repositories;
using MyPortal.Database.Models;
using SqlKata;

namespace MyPortal.Database.Repositories
{
    public class GiftedTalentedRepository : BaseReadWriteRepository<GiftedTalented>, IGiftedTalentedRepository
    {
        public GiftedTalentedRepository(IDbConnection connection, ApplicationDbContext context) : base(connection, context)
        {

        }

        protected override void SelectAllRelated(Query query)
        {
            query.SelectAll(typeof(Student));
            query.SelectAll(typeof(Subject));

            JoinRelated(query);
        }

        protected override void JoinRelated(Query query)
        {
            query.LeftJoin("Student", "Student.Id", "GiftedTalented.StudentId");
            query.LeftJoin("Subject", "Subject.Id", "GiftedTalented.SubjectId");
        }

        protected override async Task<IEnumerable<GiftedTalented>> ExecuteQuery(Query query)
        {
            var sql = Compiler.Compile(query);

            return await Connection.QueryAsync<GiftedTalented, Student, Subject, GiftedTalented>(sql.Sql,
                (gt, student, subject) =>
                {
                    gt.Student = student;
                    gt.Subject = subject;

                    return gt;
                }, sql.NamedBindings);
        }
    }
}