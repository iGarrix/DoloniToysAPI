﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.Identity
{
    public class User : BaseUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Fax { get; set; }
        public string? Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
    }
}
