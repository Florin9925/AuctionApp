using DomainModel.DTO;
using DomainModel.Entity;

namespace AuctionApp.Extensions;

public static class ValidatorExtensions
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddScoped<CategoryValidator>();
        services.AddScoped<CategoryDtoValidator>();

        services.AddScoped<OfferValidator>();
        services.AddScoped<OfferDtoValidator>();

        services.AddScoped<ProductValidator>();
        services.AddScoped<ProductDtoValidator>();

        services.AddScoped<RoleValidator>();
        services.AddScoped<RoleDtoValidator>();

        services.AddScoped<ScoreValidator>();
        services.AddScoped<ScoreDtoValidator>();

        services.AddScoped<UserValidator>();
        services.AddScoped<UserDtoValidator>();
    }
}