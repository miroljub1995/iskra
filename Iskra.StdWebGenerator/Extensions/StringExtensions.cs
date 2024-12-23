namespace Iskra.StdWebGenerator.Extensions;

public static class StringExtensions
{
    public static string? IndentLines(this string? s, int level)
    {
        if (string.IsNullOrEmpty(s))
        {
            return s;
        }

        var lines = s.Split("\n");
        var res = string.Join("\n", lines.Select(x => new string([..new string(' ', level), ..x])));

        return res;
    }
}