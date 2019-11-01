﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVS358
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string StreetAddress { get; set; }

        public int UserId { get; set; }

        [Required]
        public virtual City City { get; set; }

    }
}
