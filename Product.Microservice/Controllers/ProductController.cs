using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Microservice.Core.Domain;
using Product.Microservice.Dtos;
using Product.Microservice.Infrastructure.Data;

namespace Product.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _productDbContext;

        public ProductController(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductDto createProductDto)
        {
            var product = new ProductModel {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
            };


            await _productDbContext.Products.AddAsync(product);

            await _productDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productDbContext.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            var product= await _productDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(product);
        }
    }
}
