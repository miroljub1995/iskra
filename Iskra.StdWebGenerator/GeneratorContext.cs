namespace Iskra.StdWebGenerator;

public class GeneratorContext
{
    private long _varsCount = 0;

    public GeneratorContext()
    {
        ObjectMethods = new ObjectMethodsContext(this);
    }

    public ObjectMethodsContext ObjectMethods { get; }

    public GlobalFunctionsContext GlobalFunctions { get; } = new();

    public string GetNextVariableName()
        => $"__tmp_var{_varsCount++}";
}