using DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataMapper.PostgresDAO
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
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("AuctionDatabase"), b => b.MigrationsAssembly("AuctionApp"));
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}
