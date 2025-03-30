using System.Reflection.Metadata;
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

        var methodCallInfo = JSObjectGetCallGenerator.Execute(
            parameters.Select(x => x.Type).ToList(),
            returnParam?.Type,
            context
        );

        var marshalledParametersVar = methodCallInfo.Parameters
            .Select(_ => context.GetNextVariableName())
            .ToList();

        var marshalledParameters = methodCallInfo.Parameters
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

        string callParameters = string.Join(", ", [$"\"{functionName}\"", ..marshalledParametersVar]);

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
                 {{string.Join("\n\n", marshalledParameters)}}
                 {{returnAssignment}}{{objVar}}.{{methodCallInfo.Name}}({{callParameters}});{{marshalledReturn}}
                 """;
    }
}