﻿using MyPortal.Models.Database;

namespace MyPortal.Models.Misc
{
    public class StudentDocumentUpload
    {
        public DocsDocument Document { get; set; }
        public int Student { get; set; }
    }
}