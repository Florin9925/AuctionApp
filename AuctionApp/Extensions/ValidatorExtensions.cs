using DomainModel.DTO;
using DomainModel.Entity;

namespace AuctionApp.Extensions;

public static class ValidatorExtensions
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddScoped<UserValidator>();
        services.AddScoped<UserDtoValidator>();
        services.AddScoped<ProductValidator>();
    }
}