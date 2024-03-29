﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MyPortal.Database.Helpers;
using MyPortal.Database.Interfaces;
using MyPortal.Database.Interfaces.Repositories;
using MyPortal.Database.Models;
using MyPortal.Database.Models.Entity;
using MyPortal.Database.Repositories.Base;
using SqlKata;

namespace MyPortal.Database.Repositories
{
    public class CommentRepository : BaseReadWriteRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context) : base(context, "Comment")
        {

        }

        protected override void SelectAllRelated(Query query)
        {
            query.SelectAllColumns(typeof(CommentBank), "CommentBank");
            
            JoinRelated(query);
        }

        protected override void JoinRelated(Query query)
        {
            query.LeftJoin("CommentBanks as CommentBank", "CommentBank.Id", "Comment.CommentBankId");
        }

        protected override async Task<IEnumerable<Comment>> ExecuteQuery(Query query)
        {
            var sql = Compiler.Compile(query);

            return await Connection.QueryAsync<Comment, CommentBank, Comment>(sql.Sql, (comment, bank) =>
                {
                    comment.CommentBank = bank;

                    return comment;
                }, sql.NamedBindings);
        }
    }
}