using BuyEmAll.Core.Entities;
using System.Threading.Tasks;

namespace BuyEmAll.Core.Interfaces.Repositories
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasketAsync(string basketId);
        Task<Basket> UpdateBasketAsync(Basket basket);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
