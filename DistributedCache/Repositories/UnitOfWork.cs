using DistributedCache.Data;
using Microsoft.EntityFrameworkCore;

namespace DistributedCache.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public ICustomerRepository Customers { get; }

        public IProductRepository Products { get; }

        public UnitOfWork(AppDbContext appDbContext, ICustomerRepository customerRepository, 
                          IProductRepository productRepository)
        {
            
            _appDbContext = appDbContext;
            this.Customers = customerRepository;
            this.Products = productRepository;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _appDbContext.Dispose();
            }
        }
        //private Dictionary<Type, object> customRepositoryList = new Dictionary<Type, object>();
        //private readonly DbContext dbContext;
        //public UnitOfWork()
        //{
        //    dbContext = new AppDbContext();
        //}
        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}

        //public IGenericRepository<T> GetRepository<T>() where T : class
        //{
        //    //check if the repository has already created
        //    if (!customRepositoryList.ContainsKey(typeof(T)))
        //    {
        //        IGenericRepository<T> genericRepository = new GenericRepository<T>(dbContext);
        //        customRepositoryList.Add(typeof(T), genericRepository);
        //    }
        //    return customRepositoryList[typeof(T)]as IGenericRepository<T>;
        //}

        public int Save()
        {
            return _appDbContext.SaveChanges();
        }
    }
}
