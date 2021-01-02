using BuyEmAll.Core.Entities;

namespace BuyEmAll.Core.Specifications
{
    public class ProductsWithCategoryAndBrandSpec : BaseSpecification<Product>
    {
        public ProductsWithCategoryAndBrandSpec()
        {
            AddInclude(e => e.Category);
            AddInclude(e => e.Brand);
        }

        public ProductsWithCategoryAndBrandSpec(int id) : base(p => p.Id == id)
        {
            AddInclude(e => e.Category);
            AddInclude(e => e.Brand);
        }
    }
}
