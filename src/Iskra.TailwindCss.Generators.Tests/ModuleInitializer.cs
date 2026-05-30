using System.Runtime.CompilerServices;

namespace Iskra.TailwindCss.Generators.Tests;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize() => VerifySourceGenerators.Initialize();
}
