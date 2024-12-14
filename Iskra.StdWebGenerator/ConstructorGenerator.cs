using System.Reflection;
using System.Runtime.CompilerServices;
using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebGenerator;

public static class ConstructorGenerator
{
    public static string? Execute(ConstructorInfo constructorInfo)
    {
        if (constructorInfo.IsDefined(typeof(ManualBindingAttribute)))
        {
            return null;
        }

        var content = $$"""
                        public {{constructorInfo.DeclaringType?.Name}}()
                            : this()
                        {
                        }
                        """;

        return content;
    }
}