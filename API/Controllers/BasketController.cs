using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository,ILogger<BasketController> logger)
        {
            _basketRepository = basketRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketAsync([FromQuery] string id){
          
            var result= await _basketRepository.GetBasketAsync(id);
          
            return  Ok(result?? new CustomerBasket(id));
        }

        [HttpPost]
       public async Task<ActionResult<CustomerBasket>> UpdateBasketAsync(CustomerBasket basket)
        {
            var result= await _basketRepository.UpdateBasketAsync( basket);
            
            return  Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBasketAsync(string id){
 
            var r= await _basketRepository.DeleteBasketAsync(id);
 
            return Ok(r);
        }

    }
}