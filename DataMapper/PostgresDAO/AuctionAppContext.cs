using DomainModel.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataMapper.PostgresDAO;

public class AuctionAppContext : DbContext
{
    public AuctionAppContext(DbContextOptions<AuctionAppContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Score>()
            .HasOne(s => s.Reviewer)
            .WithMany(u => u.GivenScores)
            .HasForeignKey(s => s.ReviewerId);

        modelBuilder
            .Entity<Score>()
            .HasOne(s => s.Receiver)
            .WithMany(u => u.GetScores)
            .HasForeignKey(s => s.ReceiverId);
    }

    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<Role> Roles { get; set; } = default!;
    public DbSet<Score> Scores { get; set; } = default!;
    public DbSet<Offer> Offers { get; set; } = default!;
}