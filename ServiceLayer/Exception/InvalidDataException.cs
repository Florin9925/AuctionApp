// <copyright file="InvalidDataException.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace ServiceLayer.Exception;

using Microsoft.Extensions.Logging;

/// <summary>
/// InvalidDataException.
/// </summary>
/// <typeparam name="T"> generic. </typeparam>
/// <seealso cref="System.Exception" />
public class InvalidDataException<T> : System.Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidDataException{T}"/> class.
    /// </summary>
    /// <param name="t"> class. </param>
    /// <param name="logger"> logger. </param>
    public InvalidDataException(T t, ILogger logger)
        : base($"Invalid {typeof(T).Name} {t}")
    {
        logger.LogError($"Invalid {typeof(T).Name} {t}");
    }
}