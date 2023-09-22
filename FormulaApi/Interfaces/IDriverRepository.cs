using FormulaApi.Models;

namespace FormulaApi.Repositories
{
    // Repository makes it so that the interface (IGenericRepository) is generic and be used with mulitple objects.
    // In this case it is a Driver object. So 
    public interface IDriverRepository : IGenericRepository<Driver>
    {
    }
}
