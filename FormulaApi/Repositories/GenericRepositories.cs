using FormulaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Repositories
{
    public class GenericRepositories<T> : IGenericRepository<T> where T : class
    {
        // Foundations that each repository needs. First which DBContext is it going to be connecting to.
        // Which database is going to execute the information. Lastly, Logger is there to catch anything that might go wrong
        // or have more information available.
        protected DataContext _context;
        internal DbSet<T> _dbSet;
        protected readonly ILogger _logger;

        public GenericRepositories(DataContext context, ILogger logger)
        {
            // Initiating DataContext and logger through dependency injection. this _dbSet is going to connect to the 
            // context that we already have.
            _context = context;
            _logger = logger;
            this._dbSet = context.Set<T>();
        }

        public Task<bool> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> All()
        {
            return await _dbSet.ToListAsync();
        }

        public Task<bool> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
