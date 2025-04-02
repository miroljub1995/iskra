using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebApi.Attributes;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public static class ConstructorGenerator
{
    public static string? Execute(ConstructorInfo constructorInfo, GeneratorContext.GeneratorContext context)
    {
        if (constructorInfo.IsDefined(typeof(ManualBindingAttribute)))
        {
            return null;
        }

        if (constructorInfo.DeclaringType is null)
        {
            throw new Exception($"Declaring type {constructorInfo.DeclaringType} is not defined.");
        }

        var parameters = constructorInfo.GetParameters();
        if (parameters.Any(x => x.IsDefinedAsParams()))
        {
            throw new Exception(
                $"Error for type {constructorInfo.DeclaringType}. Currently params is not supported in constructors.");
        }

        var declaringType = new MyType(constructorInfo.DeclaringType, false, null, []);
        var typeName = TypeNameGenerator.Execute(declaringType);

        var jsConstructorName = constructorInfo.DeclaringType.IsDefined(typeof(IsPlainJSObjectAttribute))
            ? "Object"
            : typeName;

        var paramsContent = MethodParametersGenerator.Execute(constructorInfo);

        MethodCallParam[] functionCallParams =
        [
            new(new MyType(typeof(string), false, null, []), $"\"{jsConstructorName}\""),
            ..parameters.Select(x => new MethodCallParam(MyType.From(x), $"{x.Name}"))
        ];

        var constructParamNames = string.Join(", ", parameters.Select(x => x.Name));

        var retVar = context.GetNextVariableName();

        var content = $$"""
                        private static JSObject _Construct({{paramsContent}})
                        {
                            JSObject {{retVar}};
                        {{GlobalFunctionCallGenerator.Execute(
                            functionName: "constructGlobalObject",
                            module: "iskra",
                            parameters: functionCallParams,
                            returnParam: new(new MyType(typeof(JSObject), false, null, []), retVar),
                            context
                        ).IndentLines(4)}}
                            return {{retVar}};
                        }

                        public {{typeName}}({{paramsContent}})
                            : this(_Construct({{constructParamNames}}))
                        {
                        }
                        """;

        return content;
    }
}