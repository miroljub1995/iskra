using System.Diagnostics.CodeAnalysis;

namespace Iskra.WebIDLGenerator.Extensions;

public static class StringExtensions
{
    public static string? IndentLines([NotNullIfNotNull("s")] this string? s, int level)
    {
        if (string.IsNullOrEmpty(s))
        {
            return s;
        }

        var lines = s.Split("\n");
        var res = string.Join("\n",
            lines.Select(x => new string([..new string(' ', x == string.Empty ? 0 : level), ..x])));

        return res;
    }
}