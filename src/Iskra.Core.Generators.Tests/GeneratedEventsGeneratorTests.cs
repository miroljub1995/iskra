using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using static VerifyTUnit.Verifier;

namespace Iskra.Core.Generators.Tests;

public class GeneratedEventsGeneratorTests
{
    private static CSharpCompilation CreateCompilation(string source) =>
        CSharpCompilation.Create(
            assemblyName: "TestAssembly",
            syntaxTrees: [CSharpSyntaxTree.ParseText(source)],
            references: [MetadataReference.CreateFromFile(typeof(object).Assembly.Location)],
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

    [Test]
    public Task GeneratesSingleMethodWithParameter()
    {
        var source = """
            using Iskra.Core.Components;
            namespace MyNamespace;
            [GeneratedEvents]
            public partial class MyEvents
            {
                public partial void DoSomething(string value);
            }
            """;

        var driver = CSharpGeneratorDriver
            .Create(new GeneratedEventsGenerator())
            .RunGenerators(CreateCompilation(source));

        return Verify(driver);
    }

    [Test]
    public Task GeneratesNoParameterMethod()
    {
        var source = """
            using Iskra.Core.Components;
            namespace MyNamespace;
            [GeneratedEvents]
            public partial class MyEvents
            {
                public partial void Trigger();
            }
            """;

        var driver = CSharpGeneratorDriver
            .Create(new GeneratedEventsGenerator())
            .RunGenerators(CreateCompilation(source));

        return Verify(driver);
    }

    [Test]
    public Task GeneratesMultipleMethodsAndParameters()
    {
        var source = """
            using Iskra.Core.Components;
            namespace MyNamespace;
            [GeneratedEvents]
            public partial class MyEvents
            {
                public partial void UpdateName(string firstName, string lastName);
                public partial void UpdateAge(int age);
            }
            """;

        var driver = CSharpGeneratorDriver
            .Create(new GeneratedEventsGenerator())
            .RunGenerators(CreateCompilation(source));

        return Verify(driver);
    }

    [Test]
    public Task GeneratesWithoutNamespace()
    {
        var source = """
            using Iskra.Core.Components;
            [GeneratedEvents]
            public partial class GlobalEvents
            {
                public partial void Notify(int code);
            }
            """;

        var driver = CSharpGeneratorDriver
            .Create(new GeneratedEventsGenerator())
            .RunGenerators(CreateCompilation(source));

        return Verify(driver);
    }

    [Test]
    public Task EmitsISKRA001ForNonVoidMethod()
    {
        var source = """
            using Iskra.Core.Components;
            namespace MyNamespace;
            [GeneratedEvents]
            public partial class MyEvents
            {
                public partial string GetValue();
            }
            """;

        var driver = CSharpGeneratorDriver
            .Create(new GeneratedEventsGenerator())
            .RunGenerators(CreateCompilation(source));

        return Verify(driver);
    }

    [Test]
    public Task GeneratesNullableParameters()
    {
        var source = """
            using Iskra.Core.Components;
            namespace MyNamespace;
            [GeneratedEvents]
            public partial class MyEvents
            {
                public partial void UpdateName(string? name);
                public partial void UpdateAge(int? age);
            }
            """;

        var driver = CSharpGeneratorDriver
            .Create(new GeneratedEventsGenerator())
            .RunGenerators(CreateCompilation(source));

        return Verify(driver);
    }
}
