using FormulaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        // Foundations that each repository needs. First which DBContext is it going to be connecting to.
        // Which database is going to execute the information. Lastly, Logger is there to catch anything that might go wrong
        // or have more information available.
        protected DataContext _context;
        internal DbSet<T> _dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(DataContext context, ILogger logger)
        {
            // Initiating DataContext and logger through dependency injection. this _dbSet is going to connect to the 
            // context that we already have.
            _context = context;
            _logger = logger;
            this._dbSet = context.Set<T>();
        }

        public virtual async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }
        // AsNoTracking means entity framework will not track the object and will just get the results.
        public virtual async Task<IEnumerable<T>> All()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<bool> Delete(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Update(T entity)
        {
            _dbSet.Update(entity);
            return true;
        }
    }
}
