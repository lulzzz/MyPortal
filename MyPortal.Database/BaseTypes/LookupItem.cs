﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using MyPortal.Database.Interfaces;

namespace MyPortal.Database.BaseTypes
{
    public abstract class LookupItem : Entity
    {
        public LookupItem()
        {
            Active = true;
        }
        
        [Required]
        [Column(Order = 1)]
        [StringLength(256)]
        public string Description { get; set; }

        [Column(Order = 2)]
        public bool Active { get; set; }
    }
}
