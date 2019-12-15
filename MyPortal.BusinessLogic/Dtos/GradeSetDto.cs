﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortal.BusinessLogic.Dtos
{
    public class GradeSetDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public bool Active { get; set; }

        public bool System { get; set; }
    }
}
