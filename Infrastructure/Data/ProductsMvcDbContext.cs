using Microsoft.EntityFrameworkCore;
using ProductsMvc.Models;

namespace ProductsMvc.Infrastructure.Data
{
    public class ProductsMvcDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductsMvcDbContext(DbContextOptions<ProductsMvcDbContext> options) : base(options) { }
    }
}
