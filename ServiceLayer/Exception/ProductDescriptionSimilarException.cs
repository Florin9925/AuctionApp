// <copyright file="ProductDescriptionSimilarException.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace ServiceLayer.Exception;

using Microsoft.Extensions.Logging;

/// <summary>
/// ProductDescriptionSimilarException.
/// </summary>
/// <seealso cref="System.Exception" />
public class ProductDescriptionSimilarException : System.Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductDescriptionSimilarException"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    public ProductDescriptionSimilarException(ILogger logger)
        : base("Product description is similar to another product")
    {
        logger.LogError("Product description is similar to another product");
    }
}