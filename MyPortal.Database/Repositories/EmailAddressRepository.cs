﻿using System.Collections.Generic;
using System.Data;
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
    public class EmailAddressRepository : BaseReadWriteRepository<EmailAddress>, IEmailAddressRepository
    {
        public EmailAddressRepository(ApplicationDbContext context) : base(context, "EmailAddress")
        {
            
        }

        protected override void SelectAllRelated(Query query)
        {
            query.SelectAllColumns(typeof(EmailAddressType), "EmailAddressType");
            query.SelectAllColumns(typeof(Person), "Person");

            JoinRelated(query);
        }

        protected override void JoinRelated(Query query)
        {
            query.LeftJoin("EmailAddressTypes as EmailAddressType", "EmailAddressType.Id", "EmailAddress.TypeId");
            query.LeftJoin("People as Person", "Person.Id", "EmailAddress.PersonId");
        }

        protected override async Task<IEnumerable<EmailAddress>> ExecuteQuery(Query query)
        {
            var sql = Compiler.Compile(query);

            return await Connection.QueryAsync<EmailAddress, EmailAddressType, Person, EmailAddress>(sql.Sql,
                (address, type, person) =>
                {
                    address.Type = type;
                    address.Person = person;

                    return address;
                }, sql.NamedBindings);
        }
    }
}