using AutoMapper;
using Store.Data.Entities.OrderEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.OrderService.Dtos
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<ShippingAddress, AddressDto>().ReverseMap();
            CreateMap<Order , OrderDetailsDto>()
                .ForMember(dest => dest.DeliveryMethodName , options => options.MapFrom(src => src.DeliveryMethod.ShortName ))
                .ForMember(dest => dest.ShippingPrice , options => options.MapFrom(src => src.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>()
      .ForMember(dest => dest.ProductItemId, options => options.MapFrom(src => src.ItemOrdered.ProductId))
      .ForMember(dest => dest.ProductName, options => options.MapFrom(src => src.ItemOrdered.ProductName))
      .ForMember(dest => dest.PictureUrl, options => options.MapFrom<OrderItemPictureUrlResolver>());
      

            
        }
    }
}
