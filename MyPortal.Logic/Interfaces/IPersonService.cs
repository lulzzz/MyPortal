﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyPortal.Logic.Models.Details;
using MyPortal.Logic.Models.Lite;
using MyPortal.Logic.Models.Person;

namespace MyPortal.Logic.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDetails>> Get(PersonSearchParams searchParams);
        Dictionary<string, string> GetGenderOptions();
    }
}
