using DistributedCache.Models;
using DistributedCache.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DistributedCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           var customers = await _unitOfWork.Customers.GetAll();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _unitOfWork.Customers.GetById(id);
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            await _unitOfWork.Customers.Add(customer);
            return Ok(customer);

        }
    }
}
