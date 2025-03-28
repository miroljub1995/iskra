using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public static class JSTypeGenerator
{
    public static string Execute(Type type, GeneratorContext context)
    {
        var body = MembersGenerator.Execute(type, context);

        var isStatic = type.IsStatic();
        var baseType = type.BaseType;

        var baseTypeName = baseType is null || baseType == typeof(object)
            ? "JSObjectWrapper"
            : TypeNameGenerator.Execute(baseType, null);

        var staticKeyword = isStatic ? " static" : "";
        var defaultConstructor = isStatic ? null : "(JSObject obj)";
        var extends = isStatic ? "" : $" : {baseTypeName}(obj)";

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