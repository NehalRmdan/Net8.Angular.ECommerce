using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using core.Interfaces;
using core.Entities;
using core.Specifications;
using API.DTOS;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{

    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepository
        ,IGenericRepository<ProductBrand> productBrandRepository
        ,IGenericRepository<ProductType> productTypeRepository
        ,IMapper mapper
        )
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get(string sort
        , int? brandId, int? typeId)
        {
            ProductsWithTypesAndBrandsSpecification p = new ProductsWithTypesAndBrandsSpecification(sort,brandId, typeId);
            var products= await _productRepository.GetListAsync(p);
            
           var productsToReturn= _mapper.Map<IReadOnlyCollection<Product>,IReadOnlyCollection<ProductToReturn>>(products);
          
            return Ok(productsToReturn);
            // return Ok(  products.Select(product=> new ProductToReturn()
            // {
            //     Name= product.Name,
            //     Description= product.Description,
            //     Price= product.Price,
            //     PictureUrl= product.PictureUrl,
            //     ProductBrandName= product.ProductBrand.Name,
            //     ProductTypeName= product.ProductType.Name
            // }));
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
             ProductsWithTypesAndBrandsSpecification p = new ProductsWithTypesAndBrandsSpecification(id);

             var product= await _productRepository.GetByIDAsync(p);

        //    var r= new ProductToReturn()
        //     {
        //         Name= product.Name,
        //         Description= product.Description,
        //         Price= product.Price,
        //         PictureUrl= product.PictureUrl,
        //         ProductBrandName= product.ProductBrand.Name,
        //         ProductTypeName= product.ProductType.Name
        //     };

           var r= _mapper.Map<Product,ProductToReturn>(product);

            return Ok(r);
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
