using System.Diagnostics.CodeAnalysis;

namespace Iskra.Core.Features.Routing;

/// <summary>
/// Lightweight route template matcher that supports ASP.NET-style route patterns:
/// <list type="bullet">
///   <item>Literal segments: <c>/users/list</c></item>
///   <item>Parameter segments: <c>/users/{id}</c></item>
///   <item>Catch-all parameters: <c>/docs/{**path}</c></item>
/// </list>
/// </summary>
internal sealed class RouteTemplateMatcher
{
    private readonly RouteTemplateSegment[] _segments;
    private readonly string _pattern;

    private RouteTemplateMatcher(string pattern, RouteTemplateSegment[] segments)
    {
        _pattern = pattern;
        _segments = segments;
    }

    /// <summary>
    /// Parses a route template string into a <see cref="RouteTemplateMatcher"/>.
    /// </summary>
    public static RouteTemplateMatcher Parse(string pattern)
    {
        var trimmed = pattern.Trim('/');

        if (string.IsNullOrEmpty(trimmed))
        {
            return new RouteTemplateMatcher(pattern, []);
        }

        var parts = trimmed.Split('/');
        var segments = new RouteTemplateSegment[parts.Length];

        for (int i = 0; i < parts.Length; i++)
        {
            var part = parts[i];

            if (part.StartsWith('{') && part.EndsWith('}'))
            {
                var paramName = part[1..^1];

                if (paramName.StartsWith("**"))
                {
                    // Catch-all parameter: {**path}
                    if (i != parts.Length - 1)
                    {
                        throw new ArgumentException(
                            $"Catch-all parameter '{{{paramName}}}' must be the last segment in pattern '{pattern}'.");
                    }
                    segments[i] = new RouteTemplateSegment(RouteTemplateSegmentKind.CatchAll, paramName[2..]);
                }
                else if (paramName.StartsWith('*'))
                {
                    // Catch-all parameter: {*path}
                    if (i != parts.Length - 1)
                    {
                        throw new ArgumentException(
                            $"Catch-all parameter '{{{paramName}}}' must be the last segment in pattern '{pattern}'.");
                    }
                    segments[i] = new RouteTemplateSegment(RouteTemplateSegmentKind.CatchAll, paramName[1..]);
                }
                else
                {
                    segments[i] = new RouteTemplateSegment(RouteTemplateSegmentKind.Parameter, paramName);
                }
            }
            else
            {
                segments[i] = new RouteTemplateSegment(RouteTemplateSegmentKind.Literal, part);
            }
        }

        return new RouteTemplateMatcher(pattern, segments);
    }

    /// <summary>
    /// Whether the last segment is a catch-all (<c>{*path}</c> or <c>{**path}</c>).
    /// </summary>
    public bool HasCatchAll => _segments.Length > 0
        && _segments[^1].Kind == RouteTemplateSegmentKind.CatchAll;

    /// <summary>
    /// Returns the number of literal/parameter segments (excluding catch-all).
    /// Used by nested routing to strip consumed segments from the path.
    /// </summary>
    public int SegmentCount
    {
        get
        {
            int count = 0;
            foreach (var seg in _segments)
            {
                if (seg.Kind == RouteTemplateSegmentKind.CatchAll)
                    break;
                count++;
            }
            return count;
        }
    }

    /// <summary>
    /// Attempts to match pre-parsed <paramref name="pathSegments"/> against this
    /// template as a prefix. Returns <c>true</c> if the path starts with segments
    /// matching this template, even if additional segments follow.
    /// </summary>
    public bool TryMatchPrefix(
        ReadOnlySpan<string> pathSegments, [NotNullWhen(true)] out Dictionary<string, string>? values)
    {
        values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        // Empty template always matches as prefix.
        if (_segments.Length == 0)
        {
            return true;
        }

        var hasCatchAll = _segments[^1].Kind == RouteTemplateSegmentKind.CatchAll;
        var requiredSegments = hasCatchAll ? _segments.Length - 1 : _segments.Length;

        if (pathSegments.Length < requiredSegments)
        {
            return false;
        }

        for (int i = 0; i < _segments.Length; i++)
        {
            var segment = _segments[i];

            switch (segment.Kind)
            {
                case RouteTemplateSegmentKind.Literal:
                    if (i >= pathSegments.Length
                        || !string.Equals(segment.Value, pathSegments[i], StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                    break;

                case RouteTemplateSegmentKind.Parameter:
                    if (i >= pathSegments.Length)
                    {
                        return false;
                    }
                    values[segment.Value] = pathSegments[i];
                    break;

                case RouteTemplateSegmentKind.CatchAll:
                    var remaining = i < pathSegments.Length
                        ? string.Join('/', pathSegments[i..].ToArray())
                        : string.Empty;
                    values[segment.Value] = remaining;
                    return true;
            }
        }

        return true;
    }

}
