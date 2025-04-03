namespace Iskra.StdWebGenerator.GeneratorContexts;

public class GeneratorContext
{
    private long _varsCount = 0;

    public GlobalFunctionsContext GlobalFunctions { get; } = new();
    public DelegateMappersContext DelegateMappers { get; } = new();

    public string GetNextVariableName()
        => $"__tmp_var{_varsCount++}";
}