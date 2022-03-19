using System.Collections.Generic;
using System.Threading.Tasks;
using BuyEmAll.Core.Entities;
using BuyEmAll.Core.Interfaces.Repositories;
using BuyEmAll.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BuyEmAll.Infrastructure.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            
            return existingProduct;
        }

        public async Task<IReadOnlyList<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<IReadOnlyList<Brand>> GetBrandsAsync()
        {
            return await _context.Brands.ToListAsync();
        }
    }
}