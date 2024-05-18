using API.DTOS;
using AutoMapper;
using core.Entities;
using core.Entities.Identity;
using core.Entities.OrderAggregates;
using Core.Entities;

namespace API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
              CreateMap<Product, ProductToReturn>()
            .ForMember(dest => dest.ProductTypeName, opt => opt.MapFrom(src => src.ProductType.Name))
            .ForMember(dest => dest.ProductBrandName, opt => opt.MapFrom(src => src.ProductBrand.Name))
            .ForMember(dest => dest.PictureUrl,opt => opt.MapFrom<ProductUrlResolver>());

            CreateMap<core.Entities.Identity.Address, AddressDto>();

            CreateMap<BasketItem, BasketItemDTO>()
                .ReverseMap();
            CreateMap<CustomerBasket, CustomerBasketDTO>()
                .ReverseMap();

            CreateMap<AddressDto, core.Entities.OrderAggregates.Address>();
            
            CreateMap<Order, OrderToReturnDTO>()
            .ForMember(dest => dest.DeliveryMethod, opt => opt.MapFrom( src => src.DeliveryMethod.ShortName))
            .ForMember(dest => dest.ShippingPrice, opt => opt.MapFrom( src => src.DeliveryMethod.Price));

            CreateMap<OrderItem, OrderItemDTO>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom( src => src.ProductOrderItem.ProductName))
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom( src => src.ProductOrderItem.ProductItemId))
            .ForMember(dest => dest.PictureURL,opt => opt.MapFrom<OrderItemUrlResolver>()) ;
        }
    }
}