// <copyright file="StorageExtensions.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace AuctionApp.Extensions;

using DataMapper;
using DataMapper.PostgresDAO;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// StorageExtensions.
/// </summary>
public static class StorageExtensions
{
    /// <summary>
    /// Adds the storage.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
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