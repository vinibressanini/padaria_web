using Microsoft.EntityFrameworkCore;
using PadariaWebAPI.Models;

namespace PadariaWebAPI.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<LoyalCustomer> Customer { get; set; }

    }
}
