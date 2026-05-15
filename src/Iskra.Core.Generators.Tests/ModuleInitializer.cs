using System.Runtime.CompilerServices;

namespace Iskra.Core.Generators.Tests;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize() => VerifySourceGenerators.Initialize();
}
