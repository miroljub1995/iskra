using System.Reflection;
using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebGenerator.Extensions;

public static class ICustomAttributeProviderExtensions
{
    public static bool IsDefinedAsParams(this ICustomAttributeProvider? attrs)
    {
        var asParams = attrs?.IsDefined(typeof(AsParamsAttribute), false) ?? false;

        return asParams;
    }
}