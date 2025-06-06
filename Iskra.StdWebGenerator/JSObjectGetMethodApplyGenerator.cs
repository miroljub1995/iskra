using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebGenerator.Extensions;
using Iskra.StdWebGenerator.GeneratorContexts;
using Iskra.StdWebGenerator.JSObjectMarkers;

namespace Iskra.StdWebGenerator;

public class JSObjectGetMethodApplyGenerator
{
    public static JSObjectMethodApplyInfo Execute(
        IReadOnlyList<MyType> parameters,
        MyType? returnParam,
        GeneratorContext context
    )
    {
        if (parameters.Count == 0)
        {
            throw new NotSupportedException("Use method call instead.");
        }

        if (parameters.All(AsIs) && parameters.Distinct().Count() == 1)
        {
            var element = MyTypeToJSLevelExtensions.ToJSLevelType(parameters[0]);
            var returnParamType = returnParam is null ? null : MyTypeToJSLevelExtensions.ToJSLevelType(returnParam);

            var info = context.GlobalFunctions.GetGlobalFunctionCallInfo(
                functionName: "globalThis.Reflect.apply",
                module: null,
                parameters:
                [
                    new MyType(
                        Type: typeof(JSObject),
                        IsNullable: false,
                        ElementType: null,
                        GenericTypeArguments: []
                    ),
                    new MyType(
                        Type: typeof(JSObject),
                        IsNullable: false,
                        ElementType: null,
                        GenericTypeArguments: []
                    ),
                    new MyType(
                        Type: typeof(JSObjectArray),
                        IsNullable: false,
                        ElementType: null,
                        GenericTypeArguments: []
                    )
                ],
                returnParam: returnParamType
            );

            return new(
                Name: info.Name,
                ParamsElement: element,
                ReturnParam: returnParamType
            );
        }

        throw new($"Parameters {string.Join(", ", parameters)} are not supported.");
    }

    private static bool AsIs(MyType parameter)
    {
        return parameter.Type == typeof(bool)
               || parameter.Type == typeof(int)
               || parameter.Type == typeof(long)
               || parameter.Type == typeof(double)
               || parameter.Type == typeof(string)
               || parameter.Type == typeof(JSObject)
               || parameter.Type == typeof(object)
               || parameter.Type.IsOneOf();
    }
}