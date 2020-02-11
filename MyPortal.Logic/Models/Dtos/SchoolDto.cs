﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPortal.Logic.Models.Dtos
{
    public class SchoolDto
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public Guid? LocalAuthorityId { get; set; }

        public int EstablishmentNumber { get; set; }

        [Required]
        [StringLength(128)]
        public string Urn { get; set; }

        [Required]
        [StringLength(128)]
        public string Uprn { get; set; }

        public Guid PhaseId { get; set; }

        public Guid TypeId { get; set; }

        public Guid GovernanceTypeId { get; set; }

        public Guid IntakeTypeId { get; set; }

        public Guid? HeadTeacherId { get; set; }

        [Phone]
        [StringLength(128)]
        public string TelephoneNo { get; set; }

        [Phone]
        [StringLength(128)]
        public string FaxNo { get; set; }

        [EmailAddress]
        [StringLength(128)]
        public string EmailAddress { get; set; }

        [Url]
        [StringLength(128)]
        public string Website { get; set; }

        public bool Local { get; set; }

        public virtual PhaseDto Phase { get; set; }
        public virtual SchoolTypeDto Type { get; set; }
        public virtual GovernanceTypeDto GovernanceType { get; set; }
        public virtual IntakeTypeDto IntakeType { get; set; }
        public virtual PersonDto HeadTeacher { get; set; }
        public virtual LocalAuthorityDto LocalAuthority { get; set; }
    }
}
