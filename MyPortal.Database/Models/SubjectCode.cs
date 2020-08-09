﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MyPortal.Database.BaseTypes;
using MyPortal.Database.Interfaces;

namespace MyPortal.Database.Models
{
    [Table("SubjectCodes")]
    public class SubjectCode : LookupItem
    {
        // TODO: Populate Data

        public SubjectCode()
        {
            Elements = new HashSet<ExamBaseElement>();
        }

        [Column(Order = 3)]
        public string Code { get; set; }

        public virtual ICollection<ExamBaseElement> Elements { get; set; }
    }
}
