using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebGenerator.GeneratorContexts;
using Iskra.StdWebGenerator.JSObjectMarkers;
using Iskra.StdWebGenerator.Marshalling;

namespace Iskra.StdWebGenerator;

public record MethodCallParam(
    MyType Type,
    string Var
);

public record MethodCallOptions(
    bool SkipFunctionChecks
);

public static class MethodCallGenerator
{
    public static string Execute(
        string objVar,
        string functionName,
        IReadOnlyList<MethodCallParam> parameters,
        MethodCallParam? returnParam,
        MethodCallOptions options,
        GeneratorContext context
    )
    {
        string functionChecks = $$"""
                                  if (!{{objVar}}.HasProperty("{{functionName}}"))
                                  {
                                      throw new Exception($"Method {{functionName}} is not defined.");
                                  }

                                  if ({{objVar}}.GetTypeOfProperty("{{functionName}}") != "function")
                                  {
                                      throw new Exception($"Property {{functionName}} is not a function.");
                                  }


                                  """;

        var methodType = new MyType(typeof(JSObjectFunction), false, null, []);
        var methodVar = context.GetNextVariableName();
        var getFunctionProp = $$"""
                                JSObject {{methodVar}} = {{objVar}}.GetPropertyAsJSObjectV2("{{functionName}}");

                                """;

        var jsLevelParams = parameters.Select(x => x.Type.ToJSLevelType()).ToArray();
        var jsLevelReturnParam = returnParam?.Type.ToJSLevelType();

        var methodCallInfo = context.GlobalFunctions.GetGlobalFunctionCallInfo(
            functionName: "globalThis.Function.prototype.call.call",
            module: null,
            parameters: [methodType, new MyType(typeof(JSObject), false, null, []), ..jsLevelParams],
            returnParam: jsLevelReturnParam
        );

        var marshalledParametersVar = jsLevelParams
            .Select(_ => context.GetNextVariableName())
            .ToList();

        var marshalledParameters = jsLevelParams
            .Select((param, i) =>
            {
                var marshallRes = Marshallers.Instance
                    .GetNext(parameters[i].Type, param)
                    .Marshall(parameters[i].Type, parameters[i].Var, param, marshalledParametersVar[i], context);

                return $$"""
                         {{TypeNameGenerator.Execute(param)}} {{marshalledParametersVar[i]}};
                         {{marshallRes}}
                         """;
            }).ToList();

        string callParameters = string.Join(", ", [methodVar, objVar, ..marshalledParametersVar]);

        var returnVar = context.GetNextVariableName();
        string returnAssignment = methodCallInfo.ReturnParam is null
            ? ""
            : $$"""
                {{TypeNameGenerator.Execute(methodCallInfo.ReturnParam)}} {{returnVar}} = 
                """;

        string marshalledReturn = methodCallInfo.ReturnParam is null || returnParam is null
            ? ""
            : $$"""

                {{Marshallers.Instance
                    .GetNext(methodCallInfo.ReturnParam, returnParam.Type)
                    .Marshall(methodCallInfo.ReturnParam, returnVar, returnParam.Type, returnParam.Var, context)}}
                """;

        return (options.SkipFunctionChecks ? "" : functionChecks) +
               $$"""
                 {{getFunctionProp}}
                 {{string.Join("\n\n", marshalledParameters)}}
                 {{returnAssignment}}{{methodCallInfo.Name}}({{callParameters}});{{marshalledReturn}}
                 """;
    }
}