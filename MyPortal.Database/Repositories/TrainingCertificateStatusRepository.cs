﻿using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using MyPortal.Database.Interfaces;
using MyPortal.Database.Interfaces.Repositories;
using MyPortal.Database.Models;

namespace MyPortal.Database.Repositories
{
    public class TrainingCertificateStatusRepository : BaseReadWriteRepository<TrainingCertificateStatus>, ITrainingCertificateStatusRepository
    {
        public TrainingCertificateStatusRepository(IDbConnection connection, ApplicationDbContext context, string tblAlias = null) : base(connection, context, tblAlias)
        {
        }
    }
}