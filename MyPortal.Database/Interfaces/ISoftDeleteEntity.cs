﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyPortal.Database.Interfaces
{
    public interface ISoftDeleteEntity : IEntity
    {
        bool Deleted { get; set; }
    }
}
