﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyPortal.Database.Models;

namespace MyPortal.Database.Interfaces
{
    public interface ISchoolRepository : IReadWriteRepository<School>
    {
        Task<string> GetLocalSchoolName();
        Task<School> GetLocal();
    }
}
