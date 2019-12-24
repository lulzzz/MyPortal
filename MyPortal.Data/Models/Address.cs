﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortal.Data.Models
{
    [Table("Address", Schema = "communication")]
    public class Address
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address()
        {
            People = new HashSet<AddressPerson>();
        }

        public int Id { get; set; }

        public string HouseNumber { get; set; }

        public string HouseName { get; set; }

        public string Apartment { get; set; }

        [Required]
        [StringLength(256)]
        public string Street { get; set; }

        [StringLength(256)]
        public string District { get; set; }

        [Required]
        [StringLength(256)]
        public string Town { get; set; }

        [Required]
        [StringLength(256)]
        public string County { get; set; }

        [Required]
        [StringLength(128)]
        public string Postcode { get; set; }

        [Required]
        [StringLength(128)]
        public string Country { get; set; }

        public bool Validated { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddressPerson> People { get; set; }
    }
}