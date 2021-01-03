using BuyEmAll.Core.Entities;

namespace BuyEmAll.Core.Specifications
{
    public class ProductsWithCategoryAndBrandSpec : BaseSpecification<Product>
    {
        public ProductsWithCategoryAndBrandSpec(ProductSpecParams productSpecParams) 
            : base(p => (!productSpecParams.CategoryId.HasValue || p.CategoryId == productSpecParams.CategoryId)
                && (!productSpecParams.BrandId.HasValue || p.BrandId == productSpecParams.BrandId))
        {
            AddInclude(e => e.Category);
            AddInclude(e => e.Brand);
            AddOrderBy(e => e.Name);
            AddPaging((productSpecParams.PageIndex - 1) * productSpecParams.PageSize, productSpecParams.PageSize);

            if (!string.IsNullOrEmpty(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(e => e.Price);
                        break;

                    case "priceDesc":
                        AddOrderByDescending(e => e.Price);
                        break;

                    default:
                        AddOrderBy(e => e.Name);
                        break;
                }
            }
        }

        public ProductsWithCategoryAndBrandSpec(int id) : base(p => p.Id == id)
        {
            AddInclude(e => e.Category);
            AddInclude(e => e.Brand);
        }
    }
}
