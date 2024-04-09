
using API.DTOS;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository,
        IMapper mapper
        ,ILogger<BasketController> logger)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketAsync([FromQuery] string id){
          
            var result= await _basketRepository.GetBasketAsync(id);
          
            return  Ok(result?? new CustomerBasket(id));
        }

        [HttpPost]
       public async Task<ActionResult<CustomerBasketDTO>> UpdateBasketAsync(CustomerBasketDTO basketDTO)
        {
            var basket=_mapper.Map<CustomerBasket>(basketDTO);

            var result= await _basketRepository.UpdateBasketAsync( basket);
            
            return  Ok(_mapper.Map<CustomerBasketDTO>(result));

        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBasketAsync(string id){
 
            var r= await _basketRepository.DeleteBasketAsync(id);
 
            return Ok(r);
        }

    }
}