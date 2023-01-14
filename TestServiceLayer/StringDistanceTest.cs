using ServiceLayer.Utils;

namespace TestServiceLayer;

[TestClass]
public class StringDistanceTest
{
    private string description = "This is a test of the string distance algorithm";

    private string descriptionSimilar = "This is a test of the string distance algorithm 2";

    private string descriptionDifferent = "This is't a description of a sequence of characters";
    
    [TestMethod]
    public void TestStringDistanceSimilar()
    {
        var distance = StringDistance.LevenshteinDistance(description, descriptionSimilar);
        Assert.IsTrue(distance < 10);
    }
    
    [TestMethod]
    public void TestStringDistanceDifferent()
    {
        var distance = StringDistance.LevenshteinDistance(description, descriptionDifferent);
        Assert.IsTrue(distance > 10);
    }
}