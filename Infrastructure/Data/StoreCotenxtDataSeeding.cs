using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using core.Entities;
using Core.Entities;
using Infrastructure.Data;

namespace IInfrastructure.Data
{
    public static class StoreCotenxtDataSeeding
    {
        public static void SeedData(StoreContext sc)
        {
             var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
             
            if(!sc.ProductBrands.Any())
            {
            var brandsStr= File.OpenRead(path+@"\Data\SeedData\brands.json");
            var brands=JsonSerializer.Deserialize<List<ProductBrand>>(brandsStr);
            foreach(var b in brands)
            {
                sc.ProductBrands.Add(b);
            }
            sc.SaveChanges();
            }

            if(!sc.ProductTypes.Any())
            {
            var typesStr= File.OpenRead(path+@"\Data\SeedData\types.json");
            var types=JsonSerializer.Deserialize<List<ProductType>>(typesStr);
            foreach(var t in types)
            {
                sc.ProductTypes.Add(t);
            }
            sc.SaveChanges();
            }

             if(!sc.Products.Any())
            {
            var productsStr= File.OpenRead(path+@"\Data\SeedData\products.json");
            var products=JsonSerializer.Deserialize<List<Product>>(productsStr);
            foreach(var t in products)
            {
                sc.Products.Add(t);
            }
            sc.SaveChanges();
            }
        }
    }
}