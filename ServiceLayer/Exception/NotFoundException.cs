// <copyright file="NotFoundException.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace ServiceLayer.Exception;

using Microsoft.Extensions.Logging;

/// <summary>
/// NotFoundException.
/// </summary>
/// <typeparam name="T"> class. </typeparam>
/// <seealso cref="System.Exception" />
public class NotFoundException<T> : System.Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException{T}"/> class.
    /// </summary>
    /// <param name="t">The t.</param>
    /// <param name="logger">The logger.</param>
    public NotFoundException(T t, ILogger logger)
        : base($"Not found {typeof(T).Name} {t}")
    {
        logger.LogError($"Not found {typeof(T).Name} {t}");
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException{T}"/> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="logger">The logger.</param>
    public NotFoundException(int id, ILogger logger)
        : base($"Not found {typeof(T).Name} id: {id}")
    {
        logger.LogError($"Not found {typeof(T).Name} id: {id}");
    }
}