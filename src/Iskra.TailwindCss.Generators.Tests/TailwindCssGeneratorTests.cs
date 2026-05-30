using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using static VerifyTUnit.Verifier;

namespace Iskra.TailwindCss.Generators.Tests;

public class TailwindCssGeneratorTests
{
    private static string MakeSource(string body) => $$""""
        using Iskra.TailwindCss;
        namespace MyApp;
        public partial class Styles
        {
            public const string Theme = "@theme default { --spacing: 0.25rem; --spacing-4: 1rem; }";
            public const string Css = """
                @import "tailwindcss/theme" layer(theme);
                @import "tailwindcss/utilities" layer(utilities);
                """;

        {{body}}
        }
        """";

    private static CSharpCompilation CreateCompilation(string source) =>
        CSharpCompilation.Create(
            assemblyName: "TestAssembly",
            syntaxTrees: [CSharpSyntaxTree.ParseText(source)],
            references: [MetadataReference.CreateFromFile(typeof(object).Assembly.Location)],
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

    [Test]
    public Task EmitsAttribute()
    {
        var source = """
            namespace MyApp;
            public partial class Styles { }
            """;

        var driver = CSharpGeneratorDriver
            .Create(new TailwindCssGenerator())
            .RunGenerators(CreateCompilation(source));

        return Verify(driver);
    }

    [Test]
    public Task GeneratesStaticMethod()
    {
        var source = MakeSource("""
                [GeneratedTailwindCss(Css,
                    "tailwindcss/theme", Theme,
                    "tailwindcss/utilities", "@tailwind utilities;")]
                public static partial string GetCss();

                void Use() { var x = "flex items-center p-4"; }
            """);

        var driver = CSharpGeneratorDriver
            .Create(new TailwindCssGenerator())
            .RunGenerators(CreateCompilation(source));

        return Verify(driver);
    }

    [Test]
    public Task GeneratesInstanceMethod()
    {
        var source = MakeSource("""
                [GeneratedTailwindCss(Css,
                    "tailwindcss/theme", Theme,
                    "tailwindcss/utilities", "@tailwind utilities;")]
                public partial string GetCss();

                void Use() { var x = "flex items-center p-4"; }
            """);

        var driver = CSharpGeneratorDriver
            .Create(new TailwindCssGenerator())
            .RunGenerators(CreateCompilation(source));

        return Verify(driver);
    }

    [Test]
    public Task GeneratesWithoutNamespace()
    {
        var source = """"
            using Iskra.TailwindCss;
            public partial class GlobalStyles
            {
                public const string Theme = "@theme default { --spacing: 0.25rem; --spacing-4: 1rem; }";
                public const string Css = """
                    @import "tailwindcss/theme" layer(theme);
                    @import "tailwindcss/utilities" layer(utilities);
                    """;

                [GeneratedTailwindCss(Css,
                    "tailwindcss/theme", Theme,
                    "tailwindcss/utilities", "@tailwind utilities;")]
                public static partial string GetCss();

                void Use() { var x = "flex"; }
            }
            """";

        var driver = CSharpGeneratorDriver
            .Create(new TailwindCssGenerator())
            .RunGenerators(CreateCompilation(source));

        return Verify(driver);
    }

    [Test]
    public Task GeneratesNothingWithoutAttribute()
    {
        var source = """
            namespace MyApp;
            public partial class Styles
            {
                void Use() { var x = "flex items-center p-4"; }
            }
            """;

        var driver = CSharpGeneratorDriver
            .Create(new TailwindCssGenerator())
            .RunGenerators(CreateCompilation(source));

        return Verify(driver);
    }

    [Test]
    public Task ReportsDiagnosticOnCompilationError()
    {
        var source = """"
            using Iskra.TailwindCss;
            namespace MyApp;
            public partial class Styles
            {
                public const string Css = """
                    @import "nonexistent/module";
                    """;

                [GeneratedTailwindCss(Css, "no-such-id", "/* content */")]
                public static partial string GetCss();

                void Use() { var x = "flex"; }
            }
            """";

        var driver = CSharpGeneratorDriver
            .Create(new TailwindCssGenerator())
            .RunGenerators(CreateCompilation(source));

        return Verify(driver);
    }

    [Test]
    public Task ImportTailwindCssTheme()
    {
        var source = """"
            using Iskra.TailwindCss;
            namespace MyApp;
            public partial class Styles
            {
                public const string Theme = "@theme default { --spacing: 0.25rem; --spacing-4: 1rem; --color-red-500: red; }";
                public const string Css = """
                    @import "tailwindcss/theme" layer(theme);
                    @import "tailwindcss/utilities" layer(utilities);
                    """;

                [GeneratedTailwindCss(Css,
                    "tailwindcss/theme", Theme,
                    "tailwindcss/utilities", "@tailwind utilities;")]
                public static partial string GetCss();

                void Use() { var x = "p-4 bg-red-500"; }
            }
            """";

        var driver = CSharpGeneratorDriver
            .Create(new TailwindCssGenerator())
            .RunGenerators(CreateCompilation(source));

        return Verify(driver);
    }

    [Test]
    public Task ImportTailwindCssPreflight()
    {
        var source = """"
            using Iskra.TailwindCss;
            namespace MyApp;
            public partial class Styles
            {
                public const string Preflight = "*, ::before, ::after { box-sizing: border-box; }";
                public const string Css = """
                    @import "tailwindcss/preflight" layer(base);
                    @import "tailwindcss/utilities" layer(utilities);
                    """;

                [GeneratedTailwindCss(Css,
                    "tailwindcss/preflight", Preflight,
                    "tailwindcss/utilities", "@tailwind utilities;")]
                public static partial string GetCss();

                void Use() { var x = "flex"; }
            }
            """";

        var driver = CSharpGeneratorDriver
            .Create(new TailwindCssGenerator())
            .RunGenerators(CreateCompilation(source));

        return Verify(driver);
    }

    [Test]
    public Task ImportTailwindCssUtilities()
    {
        var source = """"
            using Iskra.TailwindCss;
            namespace MyApp;
            public partial class Styles
            {
                public const string Css = """
                    @import "tailwindcss/utilities" layer(utilities);
                    """;

                [GeneratedTailwindCss(Css,
                    "tailwindcss/utilities", "@tailwind utilities;")]
                public static partial string GetCss();

                void Use() { var x = "flex hidden block"; }
            }
            """";

        var driver = CSharpGeneratorDriver
            .Create(new TailwindCssGenerator())
            .RunGenerators(CreateCompilation(source));

        return Verify(driver);
    }

    [Test]
    public Task ImportTailwindCssIndex()
    {
        var source = """"
            using Iskra.TailwindCss;
            namespace MyApp;
            public partial class Styles
            {
                public const string Index = "@layer theme, base, components, utilities;\n@layer theme { @theme default { --spacing: 0.25rem; --spacing-4: 1rem; } }\n@layer base { *, ::before, ::after { box-sizing: border-box; } }\n@tailwind utilities;";
                public const string Css = """
                    @import "tailwindcss";
                    """;

                [GeneratedTailwindCss(Css,
                    "tailwindcss", Index)]
                public static partial string GetCss();

                void Use() { var x = "flex p-4"; }
            }
            """";

        var driver = CSharpGeneratorDriver
            .Create(new TailwindCssGenerator())
            .RunGenerators(CreateCompilation(source));

        return Verify(driver);
    }
}
