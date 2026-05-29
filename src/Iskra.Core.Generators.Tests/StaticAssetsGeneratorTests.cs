using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using static VerifyTUnit.Verifier;

namespace Iskra.Core.Generators.Tests;

public class StaticAssetsGeneratorTests
{
    private const string SingleAssetManifest = """
        {
          "Assets": [
            {
              "SourceId": "MyApp",
              "SourceType": "Discovered",
              "RelativePath": "assets/icon#[.{fingerprint}]!.png",
              "Fingerprint": "txkr4eokca"
            }
          ]
        }
        """;

    private const string MultipleAssetsManifest = """
        {
          "Assets": [
            {
              "SourceId": "MyApp",
              "SourceType": "Discovered",
              "RelativePath": "assets/icon#[.{fingerprint}]!.png",
              "Fingerprint": "txkr4eokca"
            },
            {
              "SourceId": "MyApp",
              "SourceType": "Discovered",
              "RelativePath": "css/app#[.{fingerprint}]!.css",
              "Fingerprint": "abc1234def"
            }
          ]
        }
        """;

    private const string MixedSourceTypesManifest = """
        {
          "Assets": [
            {
              "SourceId": "MyApp",
              "SourceType": "Discovered",
              "RelativePath": "assets/icon#[.{fingerprint}]!.png",
              "Fingerprint": "txkr4eokca"
            },
            {
              "SourceId": "SomePackage",
              "SourceType": "Package",
              "RelativePath": "_content/SomePackage/lib.js",
              "Fingerprint": "xyz9876wvu"
            },
            {
              "SourceId": "MyApp",
              "SourceType": "Computed",
              "RelativePath": "_framework/dotnet#[.{fingerprint}]?.js",
              "Fingerprint": "0limxgt2lp"
            },
            {
              "SourceId": "MyApp",
              "SourceType": "Computed",
              "RelativePath": "_framework/Iskra.Core#[.{fingerprint}]!.wasm",
              "Fingerprint": "hypohbr2ef"
            }
          ]
        }
        """;

    private const string UserClass = """
        using Iskra.Core;
        namespace MyApp;

        [GeneratedStaticAssetPaths]
        public static partial class WwwRoot { }
        """;

    private static GeneratorDriver CreateDriver(string manifestJson, string source = UserClass, string assemblyName = "MyApp")
    {
        var compilation = CSharpCompilation.Create(
            assemblyName: assemblyName,
            syntaxTrees: [CSharpSyntaxTree.ParseText(source)],
            references: [MetadataReference.CreateFromFile(typeof(object).Assembly.Location)],
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        var additionalText = new InMemoryAdditionalText(
            "obj/Debug/net10.0/iskraassets.json", manifestJson);

        return CSharpGeneratorDriver
            .Create(new StaticAssetsGenerator())
            .AddAdditionalTexts([additionalText])
            .RunGenerators(compilation);
    }

    [Test]
    public Task GeneratesSingleAsset()
    {
        return Verify(CreateDriver(SingleAssetManifest));
    }

    [Test]
    public Task GeneratesMultipleAssets()
    {
        return Verify(CreateDriver(MultipleAssetsManifest));
    }

    [Test]
    public Task FiltersToAssetsFromSameProject()
    {
        return Verify(CreateDriver(MixedSourceTypesManifest));
    }

    [Test]
    public Task GeneratesNothingWhenNoDiscoveredAssets()
    {
        var manifest = """
            {
              "Assets": [
                {
                  "SourceId": "SomePackage",
                  "SourceType": "Package",
                  "RelativePath": "_content/SomePackage/lib.js",
                  "Fingerprint": "xyz9876wvu"
                }
              ]
            }
            """;

        return Verify(CreateDriver(manifest));
    }

    [Test]
    public Task GeneratesWithoutFingerprint()
    {
        var manifest = """
            {
              "Assets": [
                {
                  "SourceId": "MyApp",
                  "SourceType": "Discovered",
                  "RelativePath": "favicon.ico",
                  "Fingerprint": ""
                }
              ]
            }
            """;

        return Verify(CreateDriver(manifest));
    }

    [Test]
    public Task GeneratesWithCustomClassName()
    {
        var source = """
            using Iskra.Core;
            namespace MyApp;

            [GeneratedStaticAssetPaths]
            public static partial class Assets { }
            """;

        return Verify(CreateDriver(SingleAssetManifest, source));
    }

    [Test]
    public Task GeneratesNothingWithoutAttribute()
    {
        var source = """
            namespace MyApp;
            public static partial class WwwRoot { }
            """;

        return Verify(CreateDriver(SingleAssetManifest, source));
    }

    private sealed class InMemoryAdditionalText : AdditionalText
    {
        private readonly SourceText _text;

        public override string Path { get; }

        public InMemoryAdditionalText(string path, string content)
        {
            Path = path;
            _text = SourceText.From(content);
        }

        public override SourceText? GetText(System.Threading.CancellationToken cancellationToken = default)
            => _text;
    }
}
