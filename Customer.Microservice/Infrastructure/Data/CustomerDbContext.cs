using Customer.Microservice.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer.Microservice.Infrastructure.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<CustomerModel> Customers { get; set; }
    }
}
