// <copyright file="ValidatorExtensions.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace AuctionApp.Extensions;

using DomainModel.Dto.Validator;
using DomainModel.Entity.Validator;

/// <summary>
/// ValidatorExtensions.
/// </summary>
public static class ValidatorExtensions
{
    /// <summary>
    /// Adds the validators.
    /// </summary>
    /// <param name="services">The services.</param>
    public static void AddValidators(this IServiceCollection services)
    {
        // services.AddScoped<IValidator<Category>, CategoryValidator>();
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