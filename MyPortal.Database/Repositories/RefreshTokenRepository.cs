﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MyPortal.Database.Helpers;
using MyPortal.Database.Interfaces.Repositories;
using MyPortal.Database.Models;
using MyPortal.Database.Models.Entity;
using MyPortal.Database.Repositories.Base;
using SqlKata;
using SqlKata.Extensions;
using Task = System.Threading.Tasks.Task;

namespace MyPortal.Database.Repositories
{
    public class RefreshTokenRepository : BaseReadWriteRepository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(ApplicationDbContext context) : base(context, "RefreshToken")
        {

        }

        protected override void SelectAllRelated(Query query)
        {
            query.SelectAllColumns(typeof(User), "User");

            JoinRelated(query);
        }

        protected override void JoinRelated(Query query)
        {
            query.LeftJoin("Users AS User", "User.Id", "RefreshToken.UserId");
        }

        protected override async Task<IEnumerable<RefreshToken>> ExecuteQuery(Query query)
        {
            var sql = Compiler.Compile(query);

            return await Connection.QueryAsync<RefreshToken, User, RefreshToken>(sql.Sql, (token, user) =>
            {
                token.User = user;

                return token;
            }, sql.NamedBindings);
        }

        public async Task<IEnumerable<RefreshToken>> GetByUser(Guid userId)
        {
            var query = GenerateQuery();

            query.Where("RefreshToken.UserId", userId);

            return await ExecuteQuery(query);
        }

        public async Task DeleteExpired(Guid userId)
        {
            var query = GenerateEmptyQuery(typeof(RefreshToken));

            query.Where("UserId", userId);
            query.Where("ExpirationDate", "<", DateTime.Now);

            query.AsDelete();

            await ExecuteNonQuery(query);
        }
    }
}
