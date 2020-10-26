﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Resources
{
    public class SavePublicationResource
    {
        [Required]
        public DateTime DatePublished { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
