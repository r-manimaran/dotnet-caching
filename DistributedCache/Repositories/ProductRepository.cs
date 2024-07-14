using DistributedCache.Data;
using DistributedCache.Models;

namespace DistributedCache.Repositories
{
    public class ProductRepository:GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
