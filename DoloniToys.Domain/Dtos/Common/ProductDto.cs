﻿using DoloniToys.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.Dtos.Common
{
    public class ProductDto : BaseDtoModel
    {
        public string Title { get; set; }
        public string Images { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string Article { get; set; }
    }
}