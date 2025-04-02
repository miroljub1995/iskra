using System.Reflection;
using Iskra.StdWebApi.Attributes;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public static class MethodGenerator
{
    public static string Execute(MethodInfo methodInfo, GeneratorContext.GeneratorContext context)
    {
        var parameterInfos = methodInfo.GetParameters();

        var isManualBinding = methodInfo.IsDefined(typeof(ManualBindingAttribute));
        var parameterTypes = parameterInfos.Select(MyType.From).ToArray();
        var isLastAsParams = parameterInfos.LastOrDefault()?.IsDefinedAsParams() == true;
        var returnType = MyType.From(methodInfo.ReturnParameter);
        var returnTypeName = TypeNameGenerator.Execute(returnType);
        var staticKeyword = methodInfo.IsStatic ? " static" : "";
        var name = methodInfo.Name;
        var genericDef = MethodGenericDefinitionGenerator.Execute(methodInfo);
        var parametersDeclaration = MethodParametersGenerator.Execute(methodInfo);

        if (isManualBinding)
        {
            var res = $$"""
                        public{{staticKeyword}} partial {{returnTypeName}} {{name}}{{genericDef}}({{parametersDeclaration}});
                        """;

            return res;
        }
        else
        {
            var methodName = JSPropertyNameGenerator.Execute(methodInfo);

            var returnVar = context.GetNextVariableName();

            if (isLastAsParams)
            {
                var returnApplyParam = methodInfo.ReturnType == typeof(void)
                    ? null
                    : new MethodApplyParam(
                        Type: returnType,
                        returnVar
                    );

                var methodApplyParameters = parameterTypes
                    .Select((x, i) =>
                        new MethodApplyParam(x, parameterInfos[i].Name ?? throw new("Parameter name is null.")))
                    .ToArray();

                return $$"""
                         public{{staticKeyword}} {{returnTypeName}} {{name}}{{genericDef}}({{parametersDeclaration}})
                         {{{(returnApplyParam is null ? "" : $"\n    {TypeNameGenerator.Execute(returnType)} {returnVar};\n")}}
                         {{MethodApplyGenerator.Execute(
                             objVar: "JSObject",
                             functionName: methodName,
                             parameters: methodApplyParameters,
                             lastAsParamsList: true,
                             returnParam: returnApplyParam,
                             context: context
                         ).IndentLines(4)}}{{(returnApplyParam is null ? "" : $"\n    return {returnVar};\n")}}
                         }
                         """;
            }

            var returnCallParam = methodInfo.ReturnType == typeof(void)
                ? null
                : new MethodCallParam(
                    Type: returnType,
                    returnVar
                );

            var methodCallParameters = parameterTypes
                .Select((x, i) =>
                    new MethodCallParam(x, parameterInfos[i].Name ?? throw new("Parameter name is null.")))
                .ToArray();

            return $$"""
                     public{{staticKeyword}} {{returnTypeName}} {{name}}{{genericDef}}({{parametersDeclaration}})
                     {{{(returnCallParam is null ? "" : $"\n    {TypeNameGenerator.Execute(returnType)} {returnVar};\n")}}
                     {{MethodCallGenerator.Execute(
                         objVar: "JSObject",
                         functionName: methodName,
                         parameters: methodCallParameters,
                         returnParam: returnCallParam,
                         options: new(SkipFunctionChecks: false),
                         context: context
                     ).IndentLines(4)}}{{(returnCallParam is null ? "" : $"\n    return {returnVar};\n")}}
                     }
                     """;
        }
    }
}