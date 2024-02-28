using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOS
{
    public class ProductToReturn
    {
         public string Id { get; set; }

         public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public string ProductBrandName { get; set; }

        public string ProductTypeName { get; set; }
        
    }
}