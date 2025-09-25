﻿using Clinic.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Domain.Entities
{
    public class Patient : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
