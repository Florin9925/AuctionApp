using ServiceLayer.ServiceImplementation;
using ServiceLayer;

namespace AuctionApp.Extensions
{
    public static class DomainServiceExtensions
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserServiceImpl>();
            services.AddScoped<IProductService, ProductServiceImpl>();
            services.AddScoped<IAuctionService, AuctionServiceImpl>();
            services.AddScoped<ICategoryService, CategoryServiceImpl>();
        }
    }
}
