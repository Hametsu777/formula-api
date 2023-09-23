using FormulaApi.Data;
using FormulaApi.Models;
using FormulaApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DriversController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
            return Ok(await _unitOfWork.Drivers.All());
            //return Ok(_drivers);
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var driver = await _unitOfWork.Drivers.GetById(id);
            if (driver == null)
            {
                return NotFound("Driver not Found");
            }
            return Ok(driver);
        }

        [HttpPost("/Add")]
        public async Task<IActionResult> AddDriver(Driver driver)
        {
            await _unitOfWork.Drivers.Add(driver);

            await _unitOfWork.CompleteAsync();
            return Ok();
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var driver = await _unitOfWork.Drivers.GetById(id);
            if (driver == null)
            {
                return NotFound("Driver not found.");
            }
            await _unitOfWork.Drivers.Delete(driver);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpPut("/Update")]
        public async Task<IActionResult> UpdateDriver(Driver driver)
        {
            var existingDriver = await _unitOfWork.Drivers.GetById(driver.Id);
            if (existingDriver == null)
            {
                return NotFound("Sorry, driver not found.");
            }

            await _unitOfWork.Drivers.Update(driver);
            await _unitOfWork.CompleteAsync();

            return Ok(existingDriver);
        }
    }
}
