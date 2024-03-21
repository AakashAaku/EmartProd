using EmartProd.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmartProd.Infrastructure.EmartContext
{
    public class EmartProdContext : DbContext
    {
        public EmartProdContext(DbContextOptions options) : base(options)
        {
        
        }

        public DbSet<ProductBrands> ProductBrands { get; set; }
        public DbSet<ProductTypes> ProductTypes { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}