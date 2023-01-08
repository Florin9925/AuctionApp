using ServiceLayer.ServiceImplementation;
using ServiceLayer;

namespace AuctionApp.Extensions;

public static class DomainServiceExtensions
{
    public static void AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryServiceImpl>();
        services.AddScoped<IOfferService, OfferServiceImpl>();
        services.AddScoped<IProductService, ProductServiceImpl>();
        services.AddScoped<IRoleService, RoleServiceImpl>();
        services.AddScoped<IScoreService, ScoreServiceImpl>();
        services.AddScoped<IUserService, UserServiceImpl>();
    }
}