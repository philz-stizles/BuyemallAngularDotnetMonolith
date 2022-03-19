using System.Collections.Generic;
using System.Threading.Tasks;
using BuyEmAll.Core.Entities;

namespace BuyEmAll.Core.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);

        Task<IReadOnlyList<Category>> GetCategoriesAsync();
        Task<IReadOnlyList<Brand>> GetBrandsAsync();
    }
}