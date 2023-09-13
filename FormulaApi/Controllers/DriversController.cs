using FormulaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormulaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private static List<Driver> _drivers = new List<Driver>()
        {
            new Driver()
            {
                Id = 1,
                Name = "Mario",
                Team = "Mushroom Kingdom",
                DriverNumber = "1"
            },
            new Driver()
            {
                Id = 2,
                Name = "Luigi",
                Team = "Mushroom Kingdom",
                DriverNumber = "3"
            },
            new Driver()
            {
                Id = 3,
                Name = "Wario",
                Team = "Rotten Kingdom",
                DriverNumber = "5"
            }
        };

        [HttpGet("/GetAll")]
        public IActionResult Get()
        {
            return Ok(_drivers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_drivers.FirstOrDefault(d => d.Id == id));
        }

        [HttpPost("/Add")]
        public IActionResult AddDriver(Driver driver)
        {
            _drivers.Add(driver);
            return Ok(_drivers);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDriver(int id)
        {
            var driver = _drivers.FirstOrDefault(d => d.Id == id);
            if (driver == null)
            {
                return NotFound("Driver not found.");
            }
            _drivers.Remove(driver);
            return NoContent();
        }

        [HttpPut("/Update")]
        public IActionResult UpdateDriver(Driver driver)
        {
            var existingDriver = _drivers.FirstOrDefault(d => d.Id == driver.Id);
            if (existingDriver == null)
            {
                return NotFound("Sorry, driver not found.");
            }

            existingDriver.Name = driver.Name;
            existingDriver.Team = driver.Team;
            existingDriver.DriverNumber = driver.DriverNumber;

            return Ok(existingDriver);
        }
    }
}
