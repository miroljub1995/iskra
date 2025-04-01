namespace Iskra.StdWebGenerator;

public class GeneratorContext
{
    private long _varsCount = 0;

    public ObjectMethodsContext ObjectMethods { get; } = new();

    public GlobalFunctionsContext GlobalFunctions { get; } = new();

    public string GetNextVariableName()
        => $"__tmp_var{_varsCount++}";
}