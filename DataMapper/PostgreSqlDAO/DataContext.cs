using DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace DataMapper.PostgreSqlDAO
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration Configuration;
        public DataContext(IConfiguration configuration, DbContextOptions<DataContext> options) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("AuctionDatabase"));
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}
