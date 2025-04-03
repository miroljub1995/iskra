using Iskra.StdWebGenerator.Extensions;
using Iskra.StdWebGenerator.GeneratorContexts;
using Iskra.StdWebGenerator.JSObjectMarkers;
using Iskra.StdWebGenerator.Marshalling;

namespace Iskra.StdWebGenerator;

public class MethodApplyGenerator
{
    public static string Execute(
        string objVar,
        string functionName,
        IReadOnlyList<MethodCallParam> parameters,
        bool lastAsParamsList,
        MethodCallParam? returnParam,
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

        var funcVar = context.GetNextVariableName();
        var getFunctionProp = $$"""
                                JSObject {{funcVar}} = {{objVar}}.GetPropertyAsJSObjectV2("{{functionName}}");

                                """;

        var paramsArrayVar = context.GetNextVariableName();
        var paramsArrayType = new MyType(typeof(JSObjectArray), false, null, []);

        var paramsLengthVar = context.GetNextVariableName();
        var paramsLengthCode = $$"""
                                 int {{paramsLengthVar}} = {{(lastAsParamsList ? $"{parameters.Count - 1} + {parameters[^1].Var}.Count" : $"{parameters.Count}")}};

                                 """;

        var methodApplyInfo = JSObjectGetMethodApplyGenerator.Execute(
            parameters.Select((x, i) => i == parameters.Count - 1 ? x.Type.GenericTypeArguments[0] : x.Type).ToList(),
            returnParam?.Type,
            context
        );

        var paramsArrayConstructor = $$"""
                                       {{TypeNameGenerator.Execute(paramsArrayType)}} {{paramsArrayVar}};
                                       {{GlobalFunctionCallGenerator.Execute(
                                           functionName: "constructGlobalObject",
                                           module: "iskra",
                                           parameters:
                                           [
                                               new(new(typeof(string), false, null, []), "\"Array\""),
                                               new(new(typeof(int), false, null, []), paramsLengthVar),
                                           ],
                                           returnParam: new(paramsArrayType, paramsArrayVar),
                                           context
                                       )}}

                                       """;

        var buildJSParamsArray = lastAsParamsList
            ? BuildParamsArrayWithLastParams(new(paramsArrayType, paramsArrayVar), parameters, context)
            : BuildParamsArray(new(paramsArrayType, paramsArrayVar), parameters, context);

        string applyParameters = string.Join(", ", funcVar, objVar, paramsArrayVar);

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
                 {{getFunctionProp}}
                 {{paramsLengthCode}}
                 {{paramsArrayConstructor}}
                 {{buildJSParamsArray}}
                 {{returnAssignment}}{{methodApplyInfo.Name}}({{applyParameters}});{{marshalledReturn}}
                 """;
    }

    private static string BuildParamsArray(
        MethodCallParam jsArray,
        IReadOnlyList<MethodCallParam> parameters,
        GeneratorContext context
    )
    {
        var setIndexType = new MyType(typeof(int), false, null, []);

        List<string> ret = [];

        for (var i = 0; i < parameters.Count; i++)
        {
            var parameter = parameters[i];
            var jsLevelParamVar = context.GetNextVariableName();
            var jsLevelParamType = MyTypeToJSLevelExtensions.ToJSLevelType(parameter.Type);

            var marshalledToJSLevelParam = Marshallers.Instance
                .GetNext(parameter.Type, jsLevelParamType)
                .Marshall(parameter.Type, parameter.Var, jsLevelParamType, jsLevelParamVar, context);

            ret.Add($$"""
                      {{TypeNameGenerator.Execute(jsLevelParamType)}} {{jsLevelParamVar}};
                      {{marshalledToJSLevelParam}}
                      {{GlobalFunctionCallGenerator.Execute(
                          functionName: "globalThis.Reflect.set",
                          module: null,
                          parameters: [jsArray, new(setIndexType, $"{i}"), new(jsLevelParamType, jsLevelParamVar)],
                          returnParam: null,
                          context: context
                      )}}
                      """);
        }

        return string.Join("\n", ret);
    }

    private static string BuildParamsArrayWithLastParams(
        MethodCallParam jsArray,
        IReadOnlyList<MethodCallParam> parameters,
        GeneratorContext context
    )
    {
        var setIndexType = new MyType(typeof(int), false, null, []);

        List<string> ret = [];

        for (var i = 0; i < parameters.Count - 1; i++)
        {
            var parameter = parameters[i];
            var jsLevelParamVar = context.GetNextVariableName();
            var jsLevelParamType = MyTypeToJSLevelExtensions.ToJSLevelType(parameter.Type);

            var marshalledToJSLevelParam = Marshallers.Instance
                .GetNext(parameter.Type, jsLevelParamType)
                .Marshall(parameter.Type, parameter.Var, jsLevelParamType, jsLevelParamVar, context);

            ret.Add($$"""
                      {{TypeNameGenerator.Execute(jsLevelParamType)}} {{jsLevelParamVar}};
                      {{marshalledToJSLevelParam}}
                      {{GlobalFunctionCallGenerator.Execute(
                          functionName: "globalThis.Reflect.set",
                          module: null,
                          parameters: [jsArray, new(setIndexType, $"{i}"), new(jsLevelParamType, jsLevelParamVar)],
                          returnParam: null,
                          context: context
                      )}}
                      """);
        }

        var lastParams = parameters[^1];
        var lastParamsItemVar = context.GetNextVariableName();
        var lastParamsItemType = lastParams.Type.GenericTypeArguments[0];
        var lastParamsItemJSType = MyTypeToJSLevelExtensions.ToJSLevelType(lastParamsItemType);

        var indexVar = context.GetNextVariableName();
        var jsArrayIndexVar = context.GetNextVariableName();

        var marshalledLastParamsItem = Marshallers.Instance
            .GetNext(lastParamsItemType, lastParamsItemJSType)
            .Marshall(lastParamsItemType, $"{lastParams.Var}[{indexVar}]", lastParamsItemJSType, lastParamsItemVar,
                context);

        ret.Add($$"""
                  for (int {{indexVar}} = 0; {{indexVar}} < {{lastParams.Var}}.Count; {{indexVar}}++)
                  {
                      {{TypeNameGenerator.Execute(lastParamsItemJSType)}} {{lastParamsItemVar}};
                  {{marshalledLastParamsItem.IndentLines(4)}}
                      int {{jsArrayIndexVar}} = {{parameters.Count - 1}} + {{indexVar}};
                  {{GlobalFunctionCallGenerator.Execute(
                      functionName: "globalThis.Reflect.set",
                      module: null,
                      parameters: [jsArray, new(setIndexType, jsArrayIndexVar), new(lastParamsItemJSType, lastParamsItemVar)],
                      returnParam: null,
                      context: context
                  ).IndentLines(4)}}
                  }
                  """);

        return string.Join("\n", ret);
    }
}