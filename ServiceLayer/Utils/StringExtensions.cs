// <copyright file="StringExtensions.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace ServiceLayer.Utils;

/// <summary>
/// StringExtensions.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// It takes a string, converts it to an array of characters, filters out all non-alphanumeric characters, converts the
    /// array back to a string, and returns the result.
    /// </summary>
    /// <param name="s">The string to be modified.</param>
    /// <returns>
    /// A string with only letters and numbers.
    /// </returns>
    public static string RemoveNonAlphaNumeric(this string s)
    {
        return new string(s.Where(char.IsLetterOrDigit).ToArray()).ToLower();
    }
}