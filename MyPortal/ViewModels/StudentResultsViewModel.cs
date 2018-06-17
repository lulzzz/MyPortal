﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyPortal.Models;

namespace MyPortal.ViewModels
{
    public class StudentResultsViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<ResultSet> ResultSets { get; set; }
        public int CurrentResultSetId { get; set; }
        public Result Result { get; set; }
        public IEnumerable<Subject> Subjects { get; set; } 
    }
}