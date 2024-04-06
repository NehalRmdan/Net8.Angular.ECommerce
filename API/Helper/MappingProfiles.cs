using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOS;
using AutoMapper;
using core.Entities.Identity;
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

            CreateMap<Address, AddressDto>();

        }
    }
}