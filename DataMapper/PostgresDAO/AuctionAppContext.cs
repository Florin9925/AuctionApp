using Microsoft.EntityFrameworkCore;

namespace DataMapper.PostgresDAO
{
    public class AuctionAppContext : DbContext
    {
        public AuctionAppContext(DbContextOptions<AuctionAppContext> options)
            : base(options)
        {
        }

        public DbSet<DomainModel.User> Users { get; set; } = default!;
        public DbSet<DomainModel.Product> Products { get; set; } = default!;
        public DbSet<DomainModel.Category> Categories { get; set; } = default!;
    }
}
