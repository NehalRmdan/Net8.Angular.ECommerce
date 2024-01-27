using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using core.Interfaces;
using core.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;

        public ProductsController(IGenericRepository<Product> productRepository
        ,IGenericRepository<ProductBrand> productBrandRepository
        ,IGenericRepository<ProductType> productTypeRepository
        )
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var products= await _productRepository.GetListAsync();
            return Ok(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
             var product= await _productRepository.GetByID(id);
            return Ok(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetBrands()
        {
            var productsBrands= await _productBrandRepository.GetListAsync();
            return Ok(productsBrands);
        }

         [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetTypes()
        {
            var productsTypes= await _productTypeRepository.GetListAsync();
            return Ok(productsTypes);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
