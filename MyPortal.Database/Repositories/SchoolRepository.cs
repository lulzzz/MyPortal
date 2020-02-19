﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MyPortal.Database.Helpers;
using MyPortal.Database.Interfaces;
using MyPortal.Database.Models;
using MyPortal.Database.Models.Identity;
using Task = System.Threading.Tasks.Task;

namespace MyPortal.Database.Repositories
{
    public class SchoolRepository : BaseReadWriteRepository<School>, ISchoolRepository
    {
        public SchoolRepository(IDbConnection connection) : base(connection)
        {
        RelatedColumns = $@"
{EntityHelper.GetAllColumns(typeof(LocalAuthority))},
{EntityHelper.GetAllColumns(typeof(Phase))},
{EntityHelper.GetAllColumns(typeof(SchoolType))},
{EntityHelper.GetAllColumns(typeof(GovernanceType))},
{EntityHelper.GetAllColumns(typeof(IntakeType))},
{EntityHelper.GetAllColumns(typeof(Person))}";

        JoinRelated = $@"
{SqlHelper.Join(JoinType.LeftJoin, "[dbo].[LocalAuthority]", "[LocalAuthority].[Id]", "[School].[LocalAuthorityId]")}
{SqlHelper.Join(JoinType.LeftJoin, "[dbo].[Phase]", "[Phase].[Id]", "[School].[PhaseId]")}
{SqlHelper.Join(JoinType.LeftJoin, "[dbo].[SchoolType]", "[SchoolType].[Id]", "[School].[TypeId]")}
{SqlHelper.Join(JoinType.LeftJoin, "[dbo].[GovernanceType]", "[GovernanceType].[Id]", "[School].[GovernanceTypeId]")}
{SqlHelper.Join(JoinType.LeftJoin, "[dbo].[IntakeType]", "[IntakeType].[Id]", "[School].[IntakeTypeId]")}
{SqlHelper.Join(JoinType.LeftJoin, "[dbo].[Person]", "[Person].[Id]", "[School].[HeadTeacherId]")}";
        }

        public async Task Update(School entity)
        {
            var schoolInDb = await Context.Schools.FindAsync(entity.Id);

            if (schoolInDb == null)
            {
                throw new Exception("School not found.");
            }

            schoolInDb.Name = entity.Name;
            schoolInDb.LocalAuthorityId = entity.LocalAuthorityId;
            schoolInDb.EstablishmentNumber = entity.EstablishmentNumber;
            schoolInDb.Urn = entity.Urn;
            schoolInDb.Uprn = entity.Uprn;
            schoolInDb.PhaseId = entity.PhaseId;
            schoolInDb.TypeId = entity.TypeId;
            schoolInDb.GovernanceTypeId = entity.GovernanceTypeId;
            schoolInDb.IntakeTypeId = entity.IntakeTypeId;
            schoolInDb.HeadTeacherId = entity.HeadTeacherId;
            schoolInDb.TelephoneNo = entity.TelephoneNo;
            schoolInDb.FaxNo = entity.FaxNo;
            schoolInDb.EmailAddress = entity.EmailAddress;
            schoolInDb.Website = entity.Website;
        }

        public async Task<string> GetLocalSchoolName()
        {
            var sql = $"SELECT [School].[Name] FROM {TblName}";
            
            SqlHelper.Where(ref sql, "[School].[Local] = 1");

            return await ExecuteStringQuery(sql);
        }

        public async Task<School> GetLocal()
        {
            var sql = SelectAllColumns();
            
            SqlHelper.Where(ref sql, "[School].[Local] = 1");

            return (await ExecuteQuery(sql)).First();
        }

        protected override async Task<IEnumerable<School>> ExecuteQuery(string sql, object param = null)
        {
            return await Connection.QueryAsync<School, LocalAuthority, Phase, SchoolType, GovernanceType, IntakeType, Person, School>(sql,
                (school, lea, phase, type, gov, intake, head) =>
                {
                    school.LocalAuthority = lea;
                    school.Phase = phase;
                    school.Type = type;
                    school.GovernanceType = gov;
                    school.IntakeType = intake;
                    school.HeadTeacher = head;

                    return school;
                }, param);
        }
    }
}
