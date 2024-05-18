using API.DTOS;
using API.Errors;
using API.Extensions;
using AutoMapper;
using core.Entities.OrderAggregates;
using core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDTO orderDto)
        {
           var buyerEmail= User.RetrieveEmailFromPrincipal();
                       
            var shippingAddress= _mapper.Map<AddressDto, Address>(orderDto.ShipToAddress);

            var order= await _orderService.CreateOrderAsync(buyerEmail,orderDto.DeliveryMethodId,orderDto.BasketId,shippingAddress);

            if(order == null) return BadRequest(new APIResponse(400, "Problem creating order"));
            
            return Ok(order);
        }
        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderToReturnDTO>>> GetOrders()
        {
           var buyerEmail= User.RetrieveEmailFromPrincipal();

            var orders= await _orderService.GetOrdersForUserAsync(buyerEmail);
            
            var mappedOrders=_mapper.Map<IReadOnlyList<OrderToReturnDTO>>(orders);
            
            return Ok(mappedOrders);
        }

         [HttpGet("{id}")]
        public async Task<ActionResult<OrderToReturnDTO>> GetOrder(int id)
        {
            var buyerEmail= User.RetrieveEmailFromPrincipal();
            
            var order = await _orderService.GetOrderByIdAsync(id, buyerEmail);

            if( order == null) return NotFound( new APIResponse(404));
           
           return _mapper.Map<OrderToReturnDTO>(order);
        }


        [HttpGet("delivery-methods")]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
        {
            
            var deliveryMethods= await _orderService.GetDeliveryMethodsAsync();
                        
            return Ok(deliveryMethods);
        }
    

    }
}