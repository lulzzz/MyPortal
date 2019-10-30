﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPortal.Models.Database;

namespace MyPortal.Interfaces
{
    public interface IFinanceSaleRepository : IRepository<FinanceSale>
    {
        Task<IEnumerable<FinanceSale>> GetAllAsync(int academicYearId);

        Task<IEnumerable<FinanceSale>> GetSalesByStudent(int studentId, int academicYearId);

        Task<IEnumerable<FinanceSale>> GetPending();

        Task<IEnumerable<FinanceSale>> GetProcessed();
    }
}
