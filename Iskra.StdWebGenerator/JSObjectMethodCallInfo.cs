namespace Iskra.StdWebGenerator;

public record JSObjectMethodCallInfo(
    string Name,
    IReadOnlyList<MyType> Parameters,
    MyType? ReturnParam
);