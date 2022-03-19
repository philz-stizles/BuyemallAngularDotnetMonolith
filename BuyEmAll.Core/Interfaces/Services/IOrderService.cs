using BuyEmAll.Core.Entities.OrderAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuyEmAll.Core.Interfaces.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(string ownerEmail, int deliveryMethodId, string basketId, Address shippingAddress);
        Task<IReadOnlyList<Order>> GetUserOrdersAsync(string ownerEmail);
        Task<Order> GetUserOrderByIdAsync(int orderId, string ownerEmail);
    }
}
