// <copyright file="StringDistanceTest.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace TestServiceLayer;

using ServiceLayer.Utils;

/// <summary>
/// StringDistanceTest.
/// </summary>
[TestClass]
public class StringDistanceTest
{
    private string description = "This is a test of the string distance algorithm";

    private string descriptionSimilar = "This is a test of the string distance algorithm 2";

    private string descriptionDifferent = "This is't a description of a sequence of characters";

    /// <summary>
    /// Tests the string distance similar.
    /// </summary>
    [TestMethod]
    public void TestStringDistanceSimilar()
    {
        var distance = StringDistance.LevenshteinDistance(this.description, this.descriptionSimilar);
        Assert.IsTrue(distance < 10);
    }

    /// <summary>
    /// Tests the string distance different.
    /// </summary>
    [TestMethod]
    public void TestStringDistanceDifferent()
    {
        var distance = StringDistance.LevenshteinDistance(this.description, this.descriptionDifferent);
        Assert.IsTrue(distance > 10);
    }
}