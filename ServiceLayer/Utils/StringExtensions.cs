namespace ServiceLayer.Utils;

public static class StringExtensions
{
    public static string RemoveNonAlphaNumeric(this string s)
    {
        return new string(s.Where(char.IsLetterOrDigit).ToArray()).ToLower();
    }
}