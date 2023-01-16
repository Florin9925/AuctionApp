// <copyright file="ConfigurationExtensions.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace AuctionApp.Extensions;

/// <summary>
/// ConfigurationExtensions.
/// </summary>
public static class ConfigurationExtensions
{
    /// <summary>
    /// Adds the configuration.
    /// </summary>
    /// <param name="services">The services.</param>
    public static void AddConfiguration(this IServiceCollection services)
    {
        services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}