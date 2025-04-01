namespace Iskra.StdWebGenerator;

public record GlobalFunctionCallInfo(
    string Name,
    string FunctionName,
    IReadOnlyList<MyType> Parameters,
    MyType? ReturnParam
);