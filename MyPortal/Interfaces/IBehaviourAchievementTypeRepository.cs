﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPortal.Models.Database;

namespace MyPortal.Interfaces
{
    public interface IBehaviourAchievementTypeRepository : IReadOnlyRepository<BehaviourAchievementType>
    {
        Task<IEnumerable<BehaviourAchievementType>> GetRecorded(int academicYearId);
    }
}