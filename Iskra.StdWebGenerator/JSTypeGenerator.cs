using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public static class JSTypeGenerator
{
    public static string Execute(Type type)
    {
        var body = MembersGenerator.Execute(type);

        var isStatic = type is { IsAbstract: true, IsSealed: true };
        var baseType = type.BaseType;
        var isBaseTypeObject = baseType is null || baseType == typeof(object);
        var baseTypeName = isBaseTypeObject ? "JSObjectWrapper" : TypeNameGenerator.Execute(baseType, baseType);

        var staticKeyword = isStatic ? " static" : "";
        var defaultConstructor = isStatic ? null : "(JSObject obj)";
        var extends = isStatic ? null : $" : {baseTypeName}(obj)";

        var content = $$"""
                        // <auto-generated/>

                        using System.Runtime.InteropServices.JavaScript;
                        using Iskra.StdWeb.Utils;

                        namespace Iskra.StdWeb;

                        #nullable enable

                        public{{staticKeyword}} partial class {{type.Name}}{{defaultConstructor}}{{extends}}
                        {
                        {{body.IndentLines(4)}}
                        }
                        """;
        return content;
    }
}