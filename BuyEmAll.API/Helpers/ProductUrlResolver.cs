using AutoMapper;
using BuyEmAll.API.Dtos;
using BuyEmAll.Core.Configs;
using BuyEmAll.Core.Entities;
using Microsoft.Extensions.Options;

namespace BuyEmAll.API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductReadDto, string>
    {
        private readonly AppSettings _appSettings;
        public ProductUrlResolver(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string Resolve(Product source, ProductReadDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageUrl))
            {
                return $"{_appSettings.APIUrl}{source.ImageUrl}";
            }

            return source.ImageUrl;
        }
    }
}
