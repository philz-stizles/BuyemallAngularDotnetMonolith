using BuyEmAll.Core.Entities;
using System.Threading.Tasks;

namespace BuyEmAll.Core.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<Basket> CreateOrUpdatePaymentIntent(string basketId);
    }
}
