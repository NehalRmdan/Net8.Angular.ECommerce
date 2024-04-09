using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOS
{
    public class BasketItemDTO
    {        
        public int Id { get; set; }

        [Range(1,int.MaxValue)]
        public int Quantity { get; set; }

        [Required]

        public string ProductName { get; set; }

       
        [Range(0.10,double.MaxValue)]
        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public string Brand { get; set; }

        public string Type { get; set; }

    }
}