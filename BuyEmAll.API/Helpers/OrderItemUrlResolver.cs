using AutoMapper;
using BuyEmAll.API.Dtos;
using BuyEmAll.Core.Entities.OrderAggregate;
using Microsoft.Extensions.Configuration;

namespace BuyEmAll.API.Helpers
{
  public class OrderItemUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        private readonly IConfiguration _config;
        public OrderItemUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ItemOrdered.PictureUrl))
            {
                return $"{_config["APIUrl"]}{source.ItemOrdered.PictureUrl}";
            }

            return null;
        }
    }
}
