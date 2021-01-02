using AutoMapper;
using BuyEmAll.API.Dtos;
using BuyEmAll.API.Dtos.Account;
using BuyEmAll.Core.Entities;

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
        }
    }
}