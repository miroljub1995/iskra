using System.Reflection;
using System.Runtime.CompilerServices;
using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebGenerator.Extensions;

public static class CustomAttributeProviderExtensions
{
    public static bool IsDefinedAsParams(this ICustomAttributeProvider? attrs)
    {
        return attrs?.IsDefined(typeof(ParamCollectionAttribute), false) ?? false;
    }
}