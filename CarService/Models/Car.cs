﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Models
{
    public class Car : BaseModel
    {
        public string Name { get; set; }

        public string Number { get; set; }
    }
}
