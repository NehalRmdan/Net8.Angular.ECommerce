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
        public async Task<ActionResult<Pagination<ProductToReturn>>> Get([FromQuery] ProductSpecParams productParams)
        {
            ProductsWithTypesAndBrandsSpecification p = new ProductsWithTypesAndBrandsSpecification(productParams);
            
             ProductsWithFiltersForCountSpecification pForCount = new ProductsWithFiltersForCountSpecification(productParams);

            var products= await _productRepository.GetListAsync(p);
            var productsTotalCount= await _productRepository.GetCountAsync(pForCount);
           var productsToReturnData= _mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturn>>(products);
          
           var r= new Pagination<ProductToReturn>(productParams.PageIndex,productParams.PageSize,productsTotalCount, productsToReturnData);
            return Ok(r);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturn>> Get(int id)
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
