﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyPortal.Interfaces;
using MyPortal.Models.Database;

namespace MyPortal.Repositories
{
    public class CommunicationAddressPersonRepository : Repository<CommunicationAddressPerson>, ICommunicationAddressPersonRepository
    {
        public CommunicationAddressPersonRepository(MyPortalDbContext context) : base(context)
        {

        }
    }
}