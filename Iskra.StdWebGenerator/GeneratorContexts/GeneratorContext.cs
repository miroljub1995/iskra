namespace Iskra.StdWebGenerator.GeneratorContexts;

public class GeneratorContext
{
    private long _varsCount = 0;

    public GeneratorContext()
    {
        ObjectMethods = new(this);
        GlobalFunctions = new();
        DelegateMappers = new();
    }

    public ObjectMethodsContext ObjectMethods { get; }
    public GlobalFunctionsContext GlobalFunctions { get; }
    public DelegateMappersContext DelegateMappers { get; }

    public string GetNextVariableName()
        => $"__tmp_var{_varsCount++}";
}