using CarService.Models;
using CarService.Repositories;
using CarService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Services.Implementation
{
    public class RepairService : IRepairService
    {
        private IBaseRepository<Document> Documents { get; set; }
        private IBaseRepository<Car> Cars { get; set; }
        private IBaseRepository<Worker> Workers { get; set; }

        public RepairService(
            IBaseRepository<Document> documents,
            IBaseRepository<Car> cars,
            IBaseRepository<Worker> workers
            )
        {
            Documents = documents;
            Cars = cars;
            Workers = workers;
        }

        public void Work()
        {
            var rand = new Random();
            var carId = Guid.NewGuid();
            var workerId = Guid.NewGuid();

            Cars.Create(new Car
            {
                Id = carId,
                Name = string.Format($"Car{rand.Next()}"),
                Number = string.Format($"{rand.Next()}")
            });

            Workers.Create(new Worker
            {
                Id = workerId,
                Name = string.Format($"Worker{rand.Next()}"),
                Position = string.Format($"Position{rand.Next()}"),
                Telephone = string.Format($"8916{rand.Next()}{rand.Next()}{rand.Next()}{rand.Next()}{rand.Next()}{rand.Next()}{rand.Next()}")
            });

            var car = Cars.Get(carId);
            var worker = Workers.Get(workerId);

            Documents.Create(new Document
            {
                CarId = car.Id,
                WorkerId = worker.Id,
                Car = car,
                Worker = worker
            });
        }
    }
}
