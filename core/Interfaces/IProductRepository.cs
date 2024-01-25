using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using Core.Entities;

namespace core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);

        Task<IEnumerable<Product>> GetProducts();

        Task<IEnumerable<ProductBrand>> GetProductBarnds();

        Task<IEnumerable<ProductType>> GetProductTypes();
    }
}