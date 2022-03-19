using AutoMapper;
using BuyEmAll.API.Dtos;
using BuyEmAll.API.Dtos.Account;
using BuyEmAll.Core.Entities;
using BuyEmAll.Core.Entities.Identity;
using BuyEmAll.Core.Entities.OrderAggregate;

namespace BuyEmAll.API.Helpers
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppUser, LoggedInUserDto>();
            CreateMap<Product, ProductReadDto>()
                .ForMember(pd => pd.Category, options => options.MapFrom(p => p.Category.Name))
                .ForMember(pd => pd.Brand, options => options.MapFrom(p => p.Brand.Name))
                .ForMember(pd => pd.ImageUrl, options => options.MapFrom<ProductUrlResolver>());
            CreateMap<Dtos.Account.AddressDto, Core.Entities.Identity.Address>().ReverseMap();
            CreateMap<BasketDto, Basket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<Dtos.AddressDto, Core.Entities.OrderAggregate.Address>().ReverseMap();
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(otr => otr.DeliveryMethod, options => options.MapFrom(o => o.DeliveryMethod.ShortName))
                .ForMember(otr => otr.ShippingPrice, options => options.MapFrom(o => o.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(oid => oid.ProductId, options => options.MapFrom(oi => oi.ItemOrdered.ProductItemId))
                .ForMember(oid => oid.ProductName, options => options.MapFrom(oi => oi.ItemOrdered.ProductName))
                // .ForMember(oid => oid.PictureUrl, options => options.MapFrom(oi => oi.ItemOrdered.PictureUrl))
                .ForMember(oid => oid.PictureUrl, options => options.MapFrom<OrderItemUrlResolver>());
        }
    }
}