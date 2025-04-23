using Microsoft.EntityFrameworkCore;
using SyddjursItemApi.Models;

namespace SyddjursItemApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ItemCategory> ItemCategories { get; set; }

    }
}
