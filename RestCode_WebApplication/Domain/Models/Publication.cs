﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Models
{
    public class Publication
    {
        public int Id { get; set; }
        public DateTime DatePublished { get; set; }
        public string Description { get; set; }
        public IList<Comment> Comments { get; set; } = new List<Comment>();

        //public int ConsultantId { get; set; }
        //public Consultant Consultant { get; set; }
    }
}
