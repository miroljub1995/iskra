using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebGenerator.Extensions;
using Iskra.StdWebGenerator.JSObjectMarkers;
using Iskra.StdWebGenerator.Marshalling;

namespace Iskra.StdWebGenerator.GeneratorContexts;

public class DelegateMappersContext
{
    private class Function
    {
        public required DelegateMapperInfo Info { get; init; }

        public string Code { get; set; } = string.Empty;
    }

    private readonly List<Function> _functions = [];
    private readonly List<Function> _functionProxies = [];

    public string ClassCode
    {
        get
        {
            var functionsCode = string.Join("\n\n", _functions.Select(x => x.Code));
            var functionProxiesCode = string.Join("\n\n", _functionProxies.Select(x => x.Code));

            return $$"""
                     // <auto-generated/>

                     using System.Runtime.InteropServices.JavaScript;
                     using Iskra.StdWeb.Utils;

                     namespace Iskra.StdWeb;

                     #nullable enable

                     internal static partial class {{ClassName}}
                     {
                     {{functionsCode.IndentLines(4)}}
                     {{functionProxiesCode.IndentLines(4)}}
                     }
                     """;
        }
    }

    public string ClassName => "DelegateMappers";

    public DelegateMapperInfo GetDelegateMapper(
        MyType delegateType,
        GeneratorContext context
    )
    {
        DelegateMapperInfo? info = _functions
            .Select(x => x.Info)
            .SingleOrDefault(x =>
                x.DelegateType == delegateType
            );

        if (info is null)
        {
            info = new(
                Name: $"Map_{_functions.Count}",
                DelegateType: delegateType
            );

            var func = new Function
            {
                Info = info,
            };

            _functions.Add(func);

            PopulateHeightLevelCode(func, context);
        }

        return info with { Name = $"{ClassName}.{info.Name}" };
    }

    public DelegateMapperInfo GetDelegateProxy(
        MyType delegateType,
        GeneratorContext context
    )
    {
        DelegateMapperInfo? info = _functions
            .Select(x => x.Info)
            .SingleOrDefault(x =>
                x.DelegateType == delegateType
            );

        if (info is null)
        {
            info = new(
                Name: $"Proxy_{_functions.Count}",
                DelegateType: delegateType
            );

            var func = new Function
            {
                Info = info,
            };

            _functions.Add(func);

            PopulateProxyCode(func, context);
        }

        return info with { Name = $"{ClassName}.{info.Name}" };
    }

    private static void PopulateHeightLevelCode(Function func, GeneratorContext context)
    {
        var delegateTypeName = TypeNameGenerator.Execute(func.Info.DelegateType);
        var argVar = context.GetNextVariableName();
        var retVar = context.GetNextVariableName();

        var jsLevelDelegate = ToJSLevelDelegate(func.Info.DelegateType);

        var marshalledDelegate = Marshallers.Instance
            .GetNext(func.Info.DelegateType, jsLevelDelegate)
            .Marshall(func.Info.DelegateType, argVar, jsLevelDelegate, retVar, context);

        var delegateProxy = context.GlobalFunctions.GetGlobalFunctionCallInfo(
            functionName: "arrowFunctionProxy",
            module: "iskra",
            parameters: [jsLevelDelegate],
            returnParam: new MyType(typeof(JSObject), false, null, [])
        );

        // var delegateProxy = context.DelegateMappers.GetDelegateProxy(jsLevelDelegate, context);

        var code =
            $$"""
              public static JSObject {{func.Info.Name}}({{delegateTypeName}} {{argVar}})
              {
                  return JSObjectsCache.GetOrAdd({{argVar}}, () =>
                  {
                      {{TypeNameGenerator.Execute(jsLevelDelegate)}} {{retVar}};
              {{marshalledDelegate.IndentLines(8)}}
                      return {{delegateProxy.Name}}({{retVar}});
                  });
              }
              """;

        func.Code = code;
    }

    private static MyType ToJSLevelDelegate(MyType type)
    {
        var methodInfo = type.Type.GetDelegateMethodInfo();

        var parameterTypes = methodInfo.GetParameters().Select(MyType.From).ToArray();
        var jsLevelParameterTypes = parameterTypes.Select(x => JSObjectGetCallGenerator.ToJSLevelType(x)).ToArray();
        var jsLevelParameterDotnetTypes = jsLevelParameterTypes.Select(x => x.Type).ToArray();

        var returnType = methodInfo.IsVoid() ? null : MyType.From(methodInfo.ReturnParameter);

        if (returnType is null)
        {
            return 0 switch
            {
                _ when jsLevelParameterTypes.Length == 1 => new MyType(
                    Type: typeof(Action<>).MakeGenericType(jsLevelParameterDotnetTypes),
                    IsNullable: type.IsNullable,
                    ElementType: null,
                    GenericTypeArguments: jsLevelParameterTypes
                ),
                _ when jsLevelParameterTypes.Length == 2 => new MyType(
                    Type: typeof(Action<,>).MakeGenericType(jsLevelParameterDotnetTypes),
                    IsNullable: type.IsNullable,
                    ElementType: null,
                    GenericTypeArguments: jsLevelParameterTypes
                ),
                _ => throw new NotSupportedException($"Unsupported argument length {jsLevelParameterTypes.Length}."),
            };
        }
        else
        {
            throw new NotImplementedException($"Currently Func is not implemented. Type {type}.");
        }
    }

    private static void PopulateProxyCode(Function func, GeneratorContext context)
    {
        var methodInfo = func.Info.DelegateType.Type.GetDelegateMethodInfo();

        var parameterTypes = methodInfo.GetParameters().Select(MyType.From).ToArray();

        var delegateProxy = context.GlobalFunctions.GetGlobalFunctionCallInfo(
            functionName: "arrowFunctionProxy",
            module: "iskra",
            parameters: [],
            returnParam: new MyType(typeof(JSObject), false, null, [])
        );

        func.Code = $$"""
                      [JSImport("arrowFunctionProxy", "iskra")]
                      public static partial JSObject {{func.Info.Name}}();
                      """;
    }
}