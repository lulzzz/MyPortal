﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyPortal.Database.Models;

namespace MyPortal.Database.Interfaces
{
    public interface IDocumentRepository : IReadWriteRepository<Document>
    {
        Task<IEnumerable<Document>> GetByDirectory(Guid directoryId);
    }
}
