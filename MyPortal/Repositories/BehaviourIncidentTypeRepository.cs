﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyPortal.Interfaces;
using MyPortal.Models.Database;

namespace MyPortal.Repositories
{
    public class BehaviourIncidentTypeRepository : ReadOnlyRepository<BehaviourIncidentType>, IBehaviourIncidentTypeRepository
    {
        public BehaviourIncidentTypeRepository(MyPortalDbContext context) : base(context)
        {

        }
    }
}