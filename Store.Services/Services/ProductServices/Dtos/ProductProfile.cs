using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.ProductServices.Dtos
{
    public class ProductProfile : Profile
    {
        private readonly IConfiguration _configuration;

        public ProductProfile()
        {
           //_configuration = configuration;
            CreateMap<Product, ProductDetailsDto>()
                .ForMember(dest => dest.BrandName , options => options.MapFrom(src=>src.Brand.Name))
                .ForMember(dest => dest.TypeName ,options => options.MapFrom(src => src.Type.Name))
                .ForMember(dest => dest.PictureUrl ,options => options.MapFrom<ProductPictureUrlResolver>());

          /*  CreateMap<Product, ProductDetailsDto>()
              .ForMember(dest => dest.BrandName, options => options.MapFrom(src => src.Brand.Name))
              .ForMember(dest => dest.TypeName, options => options.MapFrom(src => src.Type.Name))
              .ForMember(dest => dest.PictureUrl, options => options.MapFrom(src => 
                  string.IsNullOrEmpty(src.PictureUrl) ? null : $"{_configuration["BaseUrl"]}{src.PictureUrl}"
              ));*/
            CreateMap<ProductBrand, BrandTypeDetailsDto>();
            CreateMap<ProductType, BrandTypeDetailsDto>();
            
        }

    }
}
