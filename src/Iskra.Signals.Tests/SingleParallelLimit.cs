using TUnit.Core.Interfaces;

namespace Iskra.Signals.Tests;

public class SingleParallelLimit : IParallelLimit
{
    public int Limit => 1;
}