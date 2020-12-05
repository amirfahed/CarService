using CarService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<Document> Documents { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base (options)
        {
            Database.EnsureCreated();
        }
    }
}
