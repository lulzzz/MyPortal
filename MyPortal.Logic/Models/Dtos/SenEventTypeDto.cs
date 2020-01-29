﻿using System.ComponentModel.DataAnnotations;

namespace MyPortal.Logic.Models.Dtos
{
    public class SenEventTypeDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Description { get; set; }
    }
}
