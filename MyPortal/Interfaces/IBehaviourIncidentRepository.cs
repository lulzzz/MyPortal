﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPortal.Models.Database;

namespace MyPortal.Interfaces
{
    public interface IBehaviourIncidentRepository : IRepository<BehaviourIncident>
    {
        Task<int> GetBehaviourIncidentCountByStudent(int studentId, int academicYearId);
        Task<int> GetBehaviourIncidentPointsCountByStudent(int studentId, int academicYearId);
        Task<IEnumerable<BehaviourIncident>> GetBehaviourIncidentsByStudent(int studentId, int academicYearId);
        Task<int> GetBehaviourIncidentPointsToday();
    }
}
