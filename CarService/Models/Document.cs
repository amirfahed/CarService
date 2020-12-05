using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Models
{
    public class Document
    {
        public Guid Id { get; set; }

        public Guid CarId { get; set; }

        public Guid WorkerId { get; set; }

        public Car Car { get; set; }

        public Worker Worker { get; set; }
    }
}
