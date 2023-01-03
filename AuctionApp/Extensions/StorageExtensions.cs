using DataMapper;
using DataMapper.PostgresDAO;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Extensions;

public static class StorageExtensions
{
    public static void AddStorage(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AuctionAppContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("AuctionDatabase") ??
                throw new InvalidOperationException("Connection string 'AuctionDatabase' not found."),
                b => b.MigrationsAssembly("AuctionApp")));

        services.AddScoped<ICategoryDataServices, PostgresCategoryDataServices>();
        services.AddScoped<IOfferDataServices, PostgresOfferDataServices>();
        services.AddScoped<IProductDataServices, PostgresProductDataServices>();
        services.AddScoped<IRoleDataServices, PostgresRoleDataServices>();
        services.AddScoped<IScoreDataServices, PostgresScoreDataServices>();
        services.AddScoped<IUserDataServices, PostgresUserDataServices>();
    }
}