// <copyright file="TooManyProductsException.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace ServiceLayer.Exception;

using Microsoft.Extensions.Logging;

/// <summary>
/// TooManyProductsException.
/// </summary>
/// <seealso cref="System.Exception" />
public class TooManyProductsException : System.Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TooManyProductsException"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    public TooManyProductsException(ILogger logger)
        : base("Too many products")
    {
        logger.LogError("Too many products");
    }
}