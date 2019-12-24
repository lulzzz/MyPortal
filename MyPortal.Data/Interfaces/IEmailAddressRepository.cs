﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MyPortal.Data.Models;

namespace MyPortal.Data.Interfaces
{
    public interface IEmailAddressRepository : IReadWriteRepository<EmailAddress>
    {
        Task<IEnumerable<EmailAddress>> GetByPerson(int personId);
    }
}