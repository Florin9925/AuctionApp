using DomainModel.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataMapper.PostgresDAO
{
    public class AuctionAppContext : DbContext
    {
        public AuctionAppContext(DbContextOptions<AuctionAppContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
    }
}
