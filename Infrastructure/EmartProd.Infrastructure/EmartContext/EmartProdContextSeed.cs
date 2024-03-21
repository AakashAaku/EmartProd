using System.Text.Json;
using EmartProd.Domain.Entities;

namespace EmartProd.Infrastructure.EmartContext
{
    public static class EmartProdContextSeed
    {
        public static async Task SeedData(EmartProdContext prodContext)
        {
            if (!prodContext.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../../Infrastructure/EmartProd.Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrands>>(brandsData);
                prodContext.ProductBrands.AddRange(brands);
            }
            if (!prodContext.ProductTypes.Any())
            {
                var typesData = File.ReadAllText("../../Infrastructure/EmartProd.Infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductTypes>>(typesData);
                prodContext.ProductTypes.AddRange(types);
            }
            if (!prodContext.Products.Any())
            {
                var productsData = File.ReadAllText("../../Infrastructure/EmartProd.Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Products>>(productsData);
                prodContext.Products.AddRange(products);
            }

            if(prodContext.ChangeTracker.HasChanges()) await prodContext.SaveChangesAsync();
        }
    }
}