using Customer.Microservice.Core.Domain.Models;
using Customer.Microservice.Dtos;
using Customer.Microservice.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Customer.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDbContext _context;

        public CustomerController(CustomerDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerDto createCustomerDto)
        {
            var customer = new CustomerModel
            {
                Name = createCustomerDto.Name,
                Email = createCustomerDto.Email,
                PhoneNumber = createCustomerDto.PhoneNumber,
                Address = createCustomerDto.Address,
                City = createCustomerDto.City,
                Region = createCustomerDto.Region,
            };
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return Ok();

        }
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var customers = await _context.Customers.ToListAsync();

            return Ok(customers);
        }


    }
}
