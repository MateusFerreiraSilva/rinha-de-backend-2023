using System.Text.RegularExpressions;

namespace rinha_de_backend_2023.Data.Utils;

public static class StringExtensions
{
    private static readonly Regex SemicolonRegex = new Regex(@";");
    private static readonly Regex WhiteSpacesRegex = new Regex(@"\s");
    
    public static string RemoveAll(this string str, Regex pattern)
    {
        return string.IsNullOrWhiteSpace(str) ?
            string.Empty :
            pattern.Replace(str, string.Empty);
    }
    
    public static string RemoveAllWhiteSpaces(this string str)
    {
        return RemoveAll(str, WhiteSpacesRegex);
    }
    
    public static string RemoveAllSemicolons(this string str)
    {
        return RemoveAll(str, SemicolonRegex);
    }
}