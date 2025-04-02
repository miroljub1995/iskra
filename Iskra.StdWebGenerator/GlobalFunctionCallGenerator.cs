using Iskra.StdWebGenerator.Marshalling;

namespace Iskra.StdWebGenerator;

public class GlobalFunctionCallGenerator
{
    public static string Execute(
        string functionName,
        string? module,
        IReadOnlyList<MethodCallParam> parameters,
        MethodCallParam? returnParam,
        GeneratorContext.GeneratorContext context
    )
    {
        var methodCallInfo = GetGlobalFunctionCallGenerator.Execute(
            functionName,
            module,
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

        string callParameters = string.Join(", ", marshalledParametersVar);

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

        return $$"""
                 {{string.Join("\n\n", marshalledParameters)}}
                 {{returnAssignment}}{{methodCallInfo.Name}}({{callParameters}});{{marshalledReturn}}
                 """;
    }
}