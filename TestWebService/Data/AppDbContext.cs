using Microsoft.EntityFrameworkCore;
using TestWebService.Models;

namespace TestWebService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
            DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Order> Orders { get; set; }
    }
}
