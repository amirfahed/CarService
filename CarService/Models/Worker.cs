﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Models
{
    public class Worker : BaseModel
    {
        public string Name { get; set; }

        public string Position { get; set; }

        public string Telephone { get; set; }
    }
}
