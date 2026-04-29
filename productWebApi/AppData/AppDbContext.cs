using Microsoft.EntityFrameworkCore;
using productWebApi.Models;
using productWebApi.Models.Products;

namespace productWebApi.AppData
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
