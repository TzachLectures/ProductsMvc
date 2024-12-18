using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductsMvc.Models;

namespace ProductsMvc.Infrastructure.Data
{
    public class ProductsMvcDbContext:IdentityDbContext<IdentityUser>
    {
        public DbSet<Product> Products { get; set; }

        public ProductsMvcDbContext(DbContextOptions<ProductsMvcDbContext> options) : base(options) { }
    }
}
