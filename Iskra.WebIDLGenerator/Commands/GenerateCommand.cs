using System.CommandLine;
using System.Text.Json;
using Iskra.WebIDLGenerator.Generators;
using Iskra.WebIDLGenerator.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Iskra.WebIDLGenerator.Commands;

public class GenerateCommand : Command
{
    public GenerateCommand() : base("generate", "Generate C# implementation.")
    {
        Argument<string> pathArgument = new("path")
        {
            Description = "A path to the gensettings.json"
        };

        Add(pathArgument);

        SetAction(async (result, cancellationToken) =>
        {
            var genSettingsPath = result.GetRequiredValue(pathArgument);
            var genSettingsFullPath = Path.GetFullPath(genSettingsPath);

            if (!File.Exists(genSettingsFullPath))
            {
                throw new FileNotFoundException($"File \"{genSettingsFullPath}\" does not exist.");
            }

            var genSettingsContent = await File.ReadAllTextAsync(genSettingsFullPath, cancellationToken);
            var genSettings =
                JsonSerializer.Deserialize(genSettingsContent, typeof(GenSettings), WebIdlJsonContext.Default) as
                    GenSettings;

            if (genSettings is null)
            {
                throw new Exception("GenSettings is null.");
            }

            var baseDir = Path.GetDirectoryName(genSettingsFullPath)
                          ?? throw new Exception("Base directory is null.");

            genSettings = genSettings with
            {
                Input = Path.GetFullPath(genSettings.Input, baseDir),
                Output = Path.GetFullPath(genSettings.Output, baseDir),
            };

            ServiceCollection services = [];
            
            services.AddSingleton(genSettings);

            services.AddLogging(config =>
            {
                config.ClearProviders();
                config.AddConsole();
                config.SetMinimumLevel(LogLevel.Information);
            });

            services.AddSingleton<AttributeMemberTypeGenerator>();
            services.AddSingleton<IDLInterfaceMemberTypeGenerator>();
            services.AddSingleton<IDLTypeDescriptionToTypeGenerator>();
            services.AddSingleton<InterfaceGenerator>();
            services.AddSingleton<ModuleGenerator>();

            await using var provider = services.BuildServiceProvider();

            ILogger logger = provider.GetRequiredService<ILogger<GenerateCommand>>();

            if (!File.Exists(genSettings.Input) && !Directory.Exists(genSettings.Input))
            {
                throw new Exception($"Input \"{genSettings.Input}\" is not found.");
            }

            List<string> inputFiles = [];
            var isInputFile = File.Exists(genSettings.Input);
            if (isInputFile)
            {
                inputFiles.Add(genSettings.Input);
            }
            else
            {
                var files = Directory.GetFiles(genSettings.Input, "*.json", SearchOption.AllDirectories);
                inputFiles.AddRange(files);
            }

            if (Directory.Exists(genSettings.Output))
            {
                Directory.Delete(genSettings.Output, true);
            }

            Directory.CreateDirectory(genSettings.Output);

            var moduleGenerator = provider.GetRequiredService<ModuleGenerator>();
            foreach (var inputFile in inputFiles)
            {
                logger.LogInformation("Processing {inputFile}", inputFile);

                await moduleGenerator.GenerateAsync(inputFile, genSettings.Output, cancellationToken);
            }
        });
    }
}