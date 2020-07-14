﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MyPortal.Logic.Attributes;

namespace MyPortal.Logic.Models.Requests.Documents
{
    public class CreateDocumentModel
    {
        [NotEmpty]
        public Guid TypeId { get; set; }

        [NotEmpty]
        public Guid DirectoryId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string FileId { get; set; }

        public bool Public { get; set; }

        public bool Approved { get; set; }
    }
}