using System.CommandLine;
using System.Text.Json;
using Iskra.WebIDLGenerator.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Iskra.WebIDLGenerator.Commands;

public class GenerateCommand : Command
{
    public GenerateCommand() : base("generate", "Generate C# implementation.")
    {
        Option<string> inputOption = new("--input")
        {
            Description = "File or Directory to idlparsed json."
        };

        Option<string> outputOption = new("--output")
        {
            Description = "Directory where C# types should be generated."
        };

        Option<string> namespaceOption = new("--namespace")
        {
            Description = "Namespace of generated C# types."
        };

        Add(inputOption);
        Add(outputOption);
        Add(namespaceOption);

        SetAction(async (result, cancellationToken) =>
        {
            ServiceCollection services = [];
            services.AddLogging(config =>
            {
                config.ClearProviders();
                config.AddConsole();
                config.SetMinimumLevel(LogLevel.Information);
            });

            var provider = services.BuildServiceProvider();

            ILogger logger = provider.GetRequiredService<ILogger<GenerateCommand>>();

            var inputOptionValue = result.GetRequiredValue(inputOption);
            var outputOptionValue = result.GetRequiredValue(outputOption);
            var namespaceOptionValue = result.GetRequiredValue(namespaceOption);

            var inputFullPath = Path.GetFullPath(inputOptionValue);
            var outputFullPath = Path.GetFullPath(outputOptionValue);

            if (!File.Exists(inputFullPath) && !Directory.Exists(inputFullPath))
            {
                throw new Exception($"Input \"{inputFullPath}\" is not found.");
            }

            List<string> inputFiles = [];
            var isInputFile = File.Exists(inputFullPath);
            if (isInputFile)
            {
                inputFiles.Add(inputFullPath);
            }
            else
            {
                var files = Directory.GetFiles(inputFullPath, "*.json", SearchOption.AllDirectories);
                inputFiles.AddRange(files);
            }

            foreach (var inputFile in inputFiles)
            {
                logger.LogInformation("Processing {inputFile}", inputFile);

                var htmlModuleContent = await File.ReadAllTextAsync(inputFile);
                var htmlModule =
                    JsonSerializer.Deserialize(htmlModuleContent, typeof(IDLModule),
                        WebIdlJsonContext.Default) as IDLModule;
            }


            // var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            //
            //
            // var webrefParsedRootDir =
            //     Path.GetFullPath(Path.Combine(baseDir, "../../../../submodules/webref/curated/ed/idlparsed"));
            // var htmlModulePath = Path.Combine(webrefParsedRootDir, "html.json");
            // var htmlModuleContent = await File.ReadAllTextAsync(htmlModulePath);
            //
            // var htmlModule =
            //     JsonSerializer.Deserialize(htmlModuleContent, typeof(IDLModule),
            //         WebIdlJsonContext.Default) as IDLModule;
        });
    }
}