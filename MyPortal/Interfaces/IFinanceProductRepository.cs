﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPortal.Models.Database;

namespace MyPortal.Interfaces
{
    public interface IFinanceProductRepository : IRepository<FinanceProduct>
    {
        Task<IEnumerable<FinanceProduct>> GetAvailableProductsByStudent(int studentId);
    }
}
