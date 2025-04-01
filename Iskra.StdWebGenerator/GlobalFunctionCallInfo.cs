namespace Iskra.StdWebGenerator;

public record GlobalFunctionCallInfo(
    string Name,
    string FunctionName,
    string? Module,
    IReadOnlyList<MyType> Parameters,
    MyType? ReturnParam
);