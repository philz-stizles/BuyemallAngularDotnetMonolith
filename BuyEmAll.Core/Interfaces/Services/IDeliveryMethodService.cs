using BuyEmAll.Core.Entities.OrderAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuyEmAll.Core.Interfaces.Services
{
    public interface IDeliveryMethodService
    {
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();
    }
}
