namespace Iskra.WebIDLGenerator.Utils;

public class VariableName
{
    private static readonly AsyncLocal<VariableName> CurrentLocal = new();

    private readonly int _level;
    private long _varsCount = 0;

    private VariableName(int level)
    {
        _level = level;
    }

    public static VariableName Current => CurrentLocal.Value ??= new VariableName(0);

    public string GetNext(string prefix) =>
        $"_{new string('_', _level)}_{prefix}_{_varsCount++}";

    public static IDisposable CreateScope()
    {
        var res = new VariableNameScope(Current);
        CurrentLocal.Value = new VariableName(Current._level + 1);
        return res;
    }

    private class VariableNameScope(VariableName oldCurrent) : IDisposable
    {
        private int _disposed;

        public void Dispose()
        {
            if (Interlocked.CompareExchange(ref _disposed, 1, 0) == 0)
            {
                CurrentLocal.Value = oldCurrent;
            }
        }
    }
}