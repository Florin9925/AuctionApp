// <copyright file="DomainServiceExtensions.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace AuctionApp.Extensions;

using ServiceLayer;
using ServiceLayer.ServiceImplementation;

/// <summary>
/// DomainServiceExtensions.
/// </summary>
public static class DomainServiceExtensions
{
    /// <summary>
    /// Adds the domain services.
    /// </summary>
    /// <param name="services">The services.</param>
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