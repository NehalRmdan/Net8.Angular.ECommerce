using API.DTOS;
using AutoMapper;
using core.Entities.OrderAggregates;

namespace API.Helper
{
    public class OrderItemUrlResolver : IValueResolver<OrderItem, OrderItemDTO, string>
    {
        private readonly IConfiguration _configuration;
        public OrderItemUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(OrderItem source, OrderItemDTO destination, string destMember, ResolutionContext context)
        {
              if (!string.IsNullOrEmpty(source.ProductOrderItem.ProductPictureURL)) 
            {
                return _configuration["ApiUrl"] + source.ProductOrderItem.ProductPictureURL;
            }
            return null;
        }
    }
}