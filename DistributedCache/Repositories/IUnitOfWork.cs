namespace DistributedCache.Repositories
{
    public interface IUnitOfWork:IDisposable
    {
        ICustomerRepository Customers { get; }
        IProductRepository Products { get; }
        int Save();
    }
}
