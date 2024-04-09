using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOS
{
    public class CustomerBasketDTO
    {
         public string Id { get; set; }

        public List<BasketItemDTO> Items { get; set; }= new List<BasketItemDTO>();
    }
}