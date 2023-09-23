using FormulaApi.Data;
using FormulaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {

        public DriverRepository(DataContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Driver>> All()
        {
            try
            {
                return await _context.Drivers.Where(d => d.Id < 100).ToListAsync();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public override async Task<Driver?> GetById(int id)
        {
            try
            {
                return await _context.Drivers.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Driver?> GetByDriverNumber(string driverNb)
        {
            try
            {
                return await _context.Drivers.FirstOrDefaultAsync(d => d.DriverNumber == driverNb);
            }
            catch (Exception)
            {

                throw;
            };
        }
    }
}

