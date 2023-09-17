using FormulaApi.Data;
using FormulaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly DataContext _context;

        public DriversController(DataContext context)
        {
            _context = context;
        }
        //private static List<Driver> _drivers = new List<Driver>()
        //{
        //    new Driver()
        //    {
        //        Id = 1,
        //        Name = "Mario",
        //        Team = "Mushroom Kingdom",
        //        DriverNumber = "1"
        //    },
        //    new Driver()
        //    {
        //        Id = 2,
        //        Name = "Luigi",
        //        Team = "Mushroom Kingdom",
        //        DriverNumber = "3"
        //    },
        //    new Driver()
        //    {
        //        Id = 3,
        //        Name = "Wario",
        //        Team = "Rotten Kingdom",
        //        DriverNumber = "5"
        //    }
        //};

        [HttpGet("/GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Drivers.ToListAsync());
            //return Ok(_drivers);
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var driver = await _context.Drivers.FirstOrDefaultAsync(d => d.Id == id);
            if (driver == null)
            {
                return NotFound("Driver not Found");
            }
            return Ok(driver);
        }

        [HttpPost("/Add")]
        public async Task<IActionResult> AddDriver(Driver driver)
        {
            _context.Drivers.Add(driver);

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var driver = await _context.Drivers.FirstOrDefaultAsync(d => d.Id == id);
            if (driver == null)
            {
                return NotFound("Driver not found.");
            }
            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("/Update")]
        public async Task<IActionResult> UpdateDriver(Driver driver)
        {
            var existingDriver = await _context.Drivers.FirstOrDefaultAsync(d => d.Id == driver.Id);
            if (existingDriver == null)
            {
                return NotFound("Sorry, driver not found.");
            }

            existingDriver.Name = driver.Name;
            existingDriver.Team = driver.Team;
            existingDriver.DriverNumber = driver.DriverNumber;

            await _context.SaveChangesAsync();

            return Ok(existingDriver);
        }
    }
}
