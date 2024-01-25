using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using core.Interfaces;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _storeContext;
        public ProductRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<IEnumerable<ProductBrand>> GetProductBarnds()
        {
            return await _storeContext.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
             return await _storeContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
             return await _storeContext
             .Products
             .Include(x=> x.ProductBrand)
             .Include(x=> x.ProductType)
             .ToListAsync();
        }

        public async Task<IEnumerable<ProductType>> GetProductTypes()
        {
          return await _storeContext.ProductTypes.ToListAsync();
        }
    }
}