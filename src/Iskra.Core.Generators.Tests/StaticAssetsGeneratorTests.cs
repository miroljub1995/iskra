using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using static VerifyTUnit.Verifier;

namespace Iskra.Core.Generators.Tests;

public class StaticAssetsGeneratorTests
{
    private const string SingleAssetManifest = """
        {
          "Version": 1,
          "Source": "MyApp",
          "Assets": [
            {
              "Identity": "/path/to/wwwroot/assets/icon.png",
              "SourceId": "MyApp",
              "SourceType": "Discovered",
              "RelativePath": "assets/icon#[.{fingerprint}]!.png",
              "Fingerprint": "txkr4eokca",
              "ContentRoot": "/path/to/wwwroot/"
            }
          ]
        }
        """;

    private const string MultipleAssetsManifest = """
        {
          "Version": 1,
          "Source": "MyApp",
          "Assets": [
            {
              "Identity": "/path/to/wwwroot/assets/icon.png",
              "SourceId": "MyApp",
              "SourceType": "Discovered",
              "RelativePath": "assets/icon#[.{fingerprint}]!.png",
              "Fingerprint": "txkr4eokca",
              "ContentRoot": "/path/to/wwwroot/"
            },
            {
              "Identity": "/path/to/wwwroot/css/app.css",
              "SourceId": "MyApp",
              "SourceType": "Discovered",
              "RelativePath": "css/app#[.{fingerprint}]!.css",
              "Fingerprint": "abc1234def",
              "ContentRoot": "/path/to/wwwroot/"
            }
          ]
        }
        """;

    private const string MixedSourceTypesManifest = """
        {
          "Version": 1,
          "Source": "MyApp",
          "Assets": [
            {
              "Identity": "/path/to/wwwroot/assets/icon.png",
              "SourceId": "MyApp",
              "SourceType": "Discovered",
              "RelativePath": "assets/icon#[.{fingerprint}]!.png",
              "Fingerprint": "txkr4eokca",
              "ContentRoot": "/path/to/wwwroot/"
            },
            {
              "Identity": "/path/to/package/lib.js",
              "SourceId": "SomePackage",
              "SourceType": "Package",
              "RelativePath": "_content/SomePackage/lib.js",
              "Fingerprint": "xyz9876wvu",
              "ContentRoot": "/path/to/package/"
            },
            {
              "Identity": "/path/to/computed.wasm",
              "SourceId": "MyApp",
              "SourceType": "Computed",
              "RelativePath": "_framework/MyApp#[.{fingerprint}]!.wasm",
              "Fingerprint": "comp123456",
              "ContentRoot": "/path/to/bin/"
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
            "obj/Debug/net10.0/staticwebassets.build.json", manifestJson);

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
    public Task FiltersToDiscoveredAssetsFromSameProject()
    {
        return Verify(CreateDriver(MixedSourceTypesManifest));
    }

    [Test]
    public Task GeneratesNothingWhenNoDiscoveredAssets()
    {
        var manifest = """
            {
              "Version": 1,
              "Source": "MyApp",
              "Assets": [
                {
                  "Identity": "/path/to/package/lib.js",
                  "SourceId": "SomePackage",
                  "SourceType": "Package",
                  "RelativePath": "_content/SomePackage/lib.js",
                  "Fingerprint": "xyz9876wvu",
                  "ContentRoot": "/path/to/package/"
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
              "Version": 1,
              "Source": "MyApp",
              "Assets": [
                {
                  "Identity": "/path/to/wwwroot/favicon.ico",
                  "SourceId": "MyApp",
                  "SourceType": "Discovered",
                  "RelativePath": "favicon.ico",
                  "Fingerprint": "",
                  "ContentRoot": "/path/to/wwwroot/"
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
