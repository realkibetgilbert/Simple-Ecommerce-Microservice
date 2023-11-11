using Microsoft.EntityFrameworkCore;
using Product.Microservice.Core.Domain;

namespace Product.Microservice.Infrastructure.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ProductModel> Products { get; set; }
    }
}
