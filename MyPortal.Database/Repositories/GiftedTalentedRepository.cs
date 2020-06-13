﻿using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using MyPortal.Database.Helpers;
using MyPortal.Database.Interfaces;
using MyPortal.Database.Models;
using SqlKata;

namespace MyPortal.Database.Repositories
{
    public class GiftedTalentedRepository : BaseReadWriteRepository<GiftedTalented>, IGiftedTalentedRepository
    {
        public GiftedTalentedRepository(IDbConnection connection, ApplicationDbContext context) : base(connection, context)
        {

        }

        protected override Query SelectAllRelated(Query query)
        {
            query.SelectAll(typeof(Student));
            query.SelectAll(typeof(Subject));

            query = JoinRelated(query);

            return query;
        }

        protected override Query JoinRelated(Query query)
        {
            query.LeftJoin("dbo.Student", "Student.Id", "GiftedTalented.StudentId");
            query.LeftJoin("dbo.Subject", "Subject.Id", "GiftedTalented.SubjectId");

            return query;
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
                }, sql.Bindings);
        }
    }
}