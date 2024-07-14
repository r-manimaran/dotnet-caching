using DistributedCache.Data;
using DistributedCache.Models;

namespace DistributedCache.Repositories
{
    public class CustomerRepository:GenericRepository<Customer>,ICustomerRepository
    {
        public CustomerRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
