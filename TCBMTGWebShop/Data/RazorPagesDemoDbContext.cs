using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using TCBMTGWebShop.Models.Domain;

namespace TCBMTGWebShop.Data
{
    public class RazorPagesDemoDbContext : DbContext
    {
        public RazorPagesDemoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products{ get; set; }
        public DbSet<productType> Types { get; set; }
        public DbSet<ProductGame> Games { get; set; }

    }
}
