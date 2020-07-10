﻿using System;
using System.Threading.Tasks;
using MyPortal.Database.Models;

namespace MyPortal.Database.Interfaces.Repositories
{
    public interface ICurriculumBandRepository : IReadWriteRepository<CurriculumBand>
    {
        Task<bool> CheckUniqueCode(Guid academicYearId, string code);
    }
}