namespace Iskra.StdWebGenerator.GeneratorContexts;

public class GeneratorContext
{
    private long _nextTmpVarId;

    // public GlobalFunctionsContext GlobalFunctions { get; } = new();
    // public DelegateMappersContext DelegateMappers { get; } = new();

    public string GetNextVariableName(string name = "tmp_var")
        => $"__{name}_{_nextTmpVarId++}";
}