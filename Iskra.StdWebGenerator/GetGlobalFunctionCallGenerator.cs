using Iskra.StdWebGenerator.GeneratorContexts;

namespace Iskra.StdWebGenerator;

public class GetGlobalFunctionCallGenerator
{
    public static GlobalFunctionCallInfo Execute(
        string functionName,
        string? module,
        IReadOnlyList<MyType> parameters,
        MyType? returnParam,
        GeneratorContext context
    )
    {
        var jsLevelParams = parameters.Select(x => MyTypeToJSLevelExtensions.ToJSLevelType(x)).ToList();
        var jsLevelReturnParam = returnParam is null ? null : MyTypeToJSLevelExtensions.ToJSLevelType(returnParam);

        return context.GlobalFunctions.GetGlobalFunctionCallInfo(
            functionName,
            module,
            jsLevelParams,
            jsLevelReturnParam
        );
    }
}