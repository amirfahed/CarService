using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.Models;
using CarService.Repositories;
using CarService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private IRepairService RepairService { get; set; }
        private IBaseRepository<Document> Documents { get; set; }

        private readonly ILogger<MainController> _logger;

        public MainController(
            ILogger<MainController> logger, 
            IRepairService repairService, 
            IBaseRepository<Document> document)
        {
            _logger = logger;
            RepairService = repairService;
            Documents = document;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Documents.GetAll());
        }

        [HttpPost]
        public IActionResult Post()
        {
            RepairService.Work();
            return Ok("Work was successfully done");
        }

        [HttpPut]
        public IActionResult Put(Document doc)
        {
            bool success = true;
            var document = Documents.Get(doc.Id);
            try
            {
                if (document != null)
                {
                    Documents.Update(doc);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success
                ? (IActionResult) Ok($"Update successful {document.Id}")
                : BadRequest("Update was not successful");
        }
    }
}
