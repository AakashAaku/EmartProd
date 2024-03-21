using System.Linq.Expressions;
using EmartProd.Domain.Entities;

namespace EmartProd.Application.Specifications
{
    public class ProductWithBrandAndTypes : BaseSpecification<Products>
    {
        public ProductWithBrandAndTypes()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

        public ProductWithBrandAndTypes(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}