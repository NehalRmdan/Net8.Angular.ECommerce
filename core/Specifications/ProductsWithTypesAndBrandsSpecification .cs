using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(string sort, int? brandId, int? typeId)
        : base(x=> (!brandId.HasValue || x.ProductBrandId == brandId)
         && (!typeId.HasValue || x.ProductTypeId == typeId))
        {
            AddInclude(x=> x.ProductType);
            AddInclude(y=> y.ProductBrand);
            AddOrderBy(z=> z.Name);
            if(! string.IsNullOrEmpty(sort))
            {
                switch(sort)
                {
                    case "PriceAsc" :
                     AddOrderBy(z=> z.Price);
                     break;
                    case "PriceDsc" :
                     AddOrderByDescending(z=> z.Price);
                     break;
                    default:
                     AddOrderBy(z=> z.Name);
                     break;
                }
            }
        }

          public ProductsWithTypesAndBrandsSpecification(int id) : base(x=> x.Id == id)
        {
            AddInclude(x=> x.ProductType);
            AddInclude(y=> y.ProductBrand);
        }
    }
}