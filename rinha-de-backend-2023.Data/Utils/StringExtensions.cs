using System.Text.RegularExpressions;

namespace rinha_de_backend_2023.Data.Utils;

public static class StringExtensions
{
    private static readonly Regex WhiteSpacesRegex = new Regex(@"\s+");
    
    public static string RemoveAllWhiteSpaces(this string str)
    {
        return string.IsNullOrWhiteSpace(str) ?
            string.Empty :
            WhiteSpacesRegex.Replace(str, string.Empty);
    }
}