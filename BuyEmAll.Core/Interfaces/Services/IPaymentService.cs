using BuyEmAll.Core.Entities;
using BuyEmAll.Core.Entities.OrderAggregate;
using System.Threading.Tasks;

namespace BuyEmAll.Core.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<Basket> CreateOrUpdatePaymentIntent(string basketId);
        Task<Order> UpdateOrderPaymentSucceeded(string paymentIntentId);
        Task<Order> UpdateOrderPaymentFailed(string paymentIntentId);
    }
}
