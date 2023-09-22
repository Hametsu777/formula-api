namespace FormulaApi.Repositories
{
    // Unit of work allows a way to abstract all logic of databases. Allows a way to map interfaces and implementations.
    public interface IUnitOfWork
    {
        IDriverRepository Drivers { get; }
        Task CompleteAsync();
    }
}
