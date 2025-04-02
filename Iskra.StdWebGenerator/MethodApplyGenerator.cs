using Iskra.StdWebGenerator.Extensions;
using Iskra.StdWebGenerator.GeneratorContexts;
using Iskra.StdWebGenerator.Marshalling;

namespace Iskra.StdWebGenerator;

public record MethodApplyParam(
    MyType Type,
    string Var
);

public class MethodApplyGenerator
{
    public static string Execute(
        string objVar,
        string functionName,
        IReadOnlyList<MethodApplyParam> parameters,
        bool lastAsParamsList,
        MethodApplyParam? returnParam,
        GeneratorContext context
    )
    {
        if (lastAsParamsList)
        {
            var lastParam = parameters.Last();

            if (!lastParam.Type.Type.IsIReadOnlyList())
            {
                throw new NotSupportedException(
                    $"For params collection only IReadOnlyList is supported. Got {lastParam}.");
            }
        }

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

        var methodApplyInfo = JSObjectGetMethodApplyGenerator.Execute(
            parameters.Select((x, i) => i == parameters.Count - 1 ? x.Type.GenericTypeArguments[0] : x.Type).ToList(),
            returnParam?.Type,
            context
        );

        var marshalledParametersVar = parameters
            .Select(_ => context.GetNextVariableName())
            .ToList();

        var marshalledParameters = parameters
            .Select((param, i) =>
            {
                if (lastAsParamsList && i == parameters.Count - 1)
                {
                    var listType = new MyType(
                        Type: typeof(IReadOnlyList<>).MakeGenericType(methodApplyInfo.ParamsElement.Type),
                        IsNullable: false,
                        ElementType: null,
                        GenericTypeArguments: [methodApplyInfo.ParamsElement]
                    );

                    var marshallRes = Marshallers.Instance
                        .GetNext(param.Type, listType)
                        .Marshall(param.Type, param.Var, listType,
                            marshalledParametersVar[i], context);

                    return $$"""
                             {{TypeNameGenerator.Execute(listType)}} {{marshalledParametersVar[i]}};
                             {{marshallRes}}
                             """;
                }
                else
                {
                    var marshallRes = Marshallers.Instance
                        .GetNext(param.Type, methodApplyInfo.ParamsElement)
                        .Marshall(param.Type, param.Var, methodApplyInfo.ParamsElement,
                            marshalledParametersVar[i], context);

                    return $$"""
                             {{TypeNameGenerator.Execute(methodApplyInfo.ParamsElement)}} {{marshalledParametersVar[i]}};
                             {{marshallRes}}
                             """;
                }
            }).ToList();

        var targetMethodApplyParameters = lastAsParamsList
            ? marshalledParametersVar.Count == 1
                ? marshalledParametersVar[0]
                : $"[{string.Join(", ", [..marshalledParametersVar[..^1], $"..{marshalledParametersVar.Last()}"])}]"
            : $"[{string.Join(", ", marshalledParametersVar)}]";

        string applyParameters = string.Join(", ", [$"\"{functionName}\"", targetMethodApplyParameters]);


        var returnVar = context.GetNextVariableName();
        string returnAssignment = methodApplyInfo.ReturnParam is null
            ? ""
            : $$"""
                {{TypeNameGenerator.Execute(methodApplyInfo.ReturnParam)}} {{returnVar}} = 
                """;

        string marshalledReturn = methodApplyInfo.ReturnParam is null || returnParam is null
            ? ""
            : $$"""

                {{Marshallers.Instance
                    .GetNext(methodApplyInfo.ReturnParam, returnParam.Type)
                    .Marshall(methodApplyInfo.ReturnParam, returnVar, returnParam.Type, returnParam.Var, context)}}
                """;

        return functionChecks +
               $$"""
                 {{string.Join("\n\n", marshalledParameters)}}
                 {{returnAssignment}}{{objVar}}.{{methodApplyInfo.Name}}({{applyParameters}});{{marshalledReturn}}
                 """;
    }
}