using FormulaApi.Repositories;

namespace FormulaApi.Data
{
    // IDisposable is better for garbage collection.
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;
        //private readonly ILoggerFactory loggerFactory;
        public IDriverRepository Drivers { get; private set; }

        public UnitOfWork(DataContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var _logger = loggerFactory.CreateLogger("logs");

            Drivers = new DriverRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

