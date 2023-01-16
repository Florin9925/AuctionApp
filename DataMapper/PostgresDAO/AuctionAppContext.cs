// <copyright file="AuctionAppContext.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace DataMapper.PostgresDAO;

using DomainModel.Entity;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// AuctionAppContext.
/// </summary>
/// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
public class AuctionAppContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuctionAppContext"/> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public AuctionAppContext(DbContextOptions<AuctionAppContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the users.
    /// </summary>
    /// <value>
    /// The users.
    /// </value>
    public DbSet<User> Users { get; set; } = default!;

    /// <summary>
    /// Gets or sets the products.
    /// </summary>
    /// <value>
    /// The products.
    /// </value>
    public DbSet<Product> Products { get; set; } = default!;

    /// <summary>
    /// Gets or sets the categories.
    /// </summary>
    /// <value>
    /// The categories.
    /// </value>
    public DbSet<Category> Categories { get; set; } = default!;

    /// <summary>
    /// Gets or sets the roles.
    /// </summary>
    /// <value>
    /// The roles.
    /// </value>
    public DbSet<Role> Roles { get; set; } = default!;

    /// <summary>
    /// Gets or sets the scores.
    /// </summary>
    /// <value>
    /// The scores.
    /// </value>
    public DbSet<Score> Scores { get; set; } = default!;

    /// <summary>
    /// Gets or sets the offers.
    /// </summary>
    /// <value>
    /// The offers.
    /// </value>
    public DbSet<Offer> Offers { get; set; } = default!;

    /// <summary>
    /// Override this method to further configure the model that was discovered by convention from the entity types
    /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
    /// and re-used for subsequent instances of your derived context.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
    /// define extension methods on this object that allow you to configure aspects of the model that are specific
    /// to a given database.</param>
    /// <remarks>
    /// <para>
    /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
    /// then this method will not be run. However, it will still run when creating a compiled model.
    /// </para>
    /// <para>
    /// See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more information and
    /// examples.
    /// </para>
    /// </remarks>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Score>()
            .HasOne(s => s.Reviewer)
            .WithMany(u => u.GivenScores)
            .HasForeignKey(s => s.ReviewerId);

        modelBuilder
            .Entity<Score>()
            .HasOne(s => s.Receiver)
            .WithMany(u => u.GetScores)
            .HasForeignKey(s => s.ReceiverId);
    }
}