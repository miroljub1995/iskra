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

            var genSettings = await GenSettings.ReadFromFileAsync(genSettingsFullPath, cancellationToken);

            ServiceCollection services = [];

            services.AddSingleton(genSettings);

            services.AddLogging(config =>
            {
                config.ClearProviders();
                config.AddConsole();
                config.SetMinimumLevel(LogLevel.Information);
            });

            services.AddSingleton<GenTypeDescriptors>();

            services
                .AddSingleton<AttributeMemberTypeGenerator>()
                .AddSingleton<EnumTypeGenerator>()
                .AddSingleton<IDLInterfaceMemberTypeGenerator>()
                .AddSingleton<IDLTypeDescriptionToTypeGenerator>()
                .AddSingleton<InterfaceGenerator>()
                .AddSingleton<ModuleGenerator>();

            await using var provider = services.BuildServiceProvider();

            ILogger logger = provider.GetRequiredService<ILogger<GenerateCommand>>();

            if (!File.Exists(genSettings.Input) && !Directory.Exists(genSettings.Input))
            {
                throw new Exception($"Input \"{genSettings.Input}\" is not found.");
            }

            var inputFiles = GetModuleFiles(genSettings.Input);

            if (Directory.Exists(genSettings.Output))
            {
                Directory.Delete(genSettings.Output, true);
            }

            Directory.CreateDirectory(genSettings.Output);

            var genTypeDescriptors = provider.GetRequiredService<GenTypeDescriptors>();

            await AddGenSettingsToDescriptorsAsync(
                genTypeDescriptors,
                genSettingsFullPath,
                cancellationToken
            );

            genTypeDescriptors.ResolveTypedefs();

            var moduleGenerator = provider.GetRequiredService<ModuleGenerator>();
            foreach (var inputFile in inputFiles)
            {
                logger.LogInformation("Processing {inputFile}", inputFile);

                await moduleGenerator.GenerateAsync(inputFile, genSettings.Output, cancellationToken);
            }
        });
    }

    private static async Task AddGenSettingsToDescriptorsAsync(
        GenTypeDescriptors descriptors,
        string gensettingsPath,
        CancellationToken cancellationToken = default
    )
    {
        var settings = await GenSettings.ReadFromFileAsync(gensettingsPath, cancellationToken);

        foreach (var reference in settings.References)
        {
            await AddGenSettingsToDescriptorsAsync(descriptors, reference, cancellationToken);
        }

        var moduleFiles = GetModuleFiles(settings.Input);
        foreach (var moduleFile in moduleFiles)
        {
            var moduleContent = await File.ReadAllTextAsync(moduleFile, cancellationToken);

            if (JsonSerializer.Deserialize(moduleContent, typeof(IDLModule), WebIdlJsonContext.Default) is not IDLModule
                module)
            {
                throw new Exception("Failed to deserialize IDLModule.");
            }

            foreach (var idlRootType in module.IDLParsed.IDLNames.Values)
            {
                if (idlRootType is CallbackType callbackType)
                {
                    descriptors.Add(new GenTypeDescriptor
                    {
                        Namespace = settings.Namespace,
                        Name = callbackType.Name,
                        RootType = idlRootType,
                    });
                }
                else if (idlRootType is CallbackInterfaceType callbackInterfaceType)
                {
                    descriptors.Add(new GenTypeDescriptor
                    {
                        Namespace = settings.Namespace,
                        Name = callbackInterfaceType.Name,
                        RootType = idlRootType,
                    });
                }
                else if (idlRootType is DictionaryType dictionaryType)
                {
                    descriptors.Add(new GenTypeDescriptor
                    {
                        Namespace = settings.Namespace,
                        Name = dictionaryType.Name,
                        RootType = idlRootType,
                    });
                }
                else if (idlRootType is EnumType enumType)
                {
                    descriptors.Add(new GenTypeDescriptor
                    {
                        Namespace = settings.Namespace,
                        Name = enumType.Name,
                        RootType = idlRootType,
                    });
                }
                else if (idlRootType is InterfaceMixinType interfaceMixinType)
                {
                    descriptors.Add(new GenTypeDescriptor
                    {
                        Namespace = settings.Namespace,
                        Name = interfaceMixinType.Name,
                        RootType = idlRootType,
                    });
                }
                else if (idlRootType is InterfaceType interfaceType)
                {
                    descriptors.Add(new GenTypeDescriptor
                    {
                        Namespace = settings.Namespace,
                        Name = interfaceType.Name,
                        RootType = idlRootType,
                    });
                }
                else if (idlRootType is NamespaceType namespaceType)
                {
                    descriptors.Add(new GenTypeDescriptor
                    {
                        Namespace = settings.Namespace,
                        Name = namespaceType.Name,
                        RootType = idlRootType,
                    });
                }
                else if (idlRootType is TypedefType typedefType)
                {
                    descriptors.Add(new GenTypeDescriptor
                    {
                        Namespace = settings.Namespace,
                        Name = typedefType.Name,
                        RootType = idlRootType,
                    });
                }
            }
        }
    }

    private static List<string> GetModuleFiles(string input)
    {
        var isInputFile = File.Exists(input);
        if (isInputFile)
        {
            return [input];
        }

        var files = Directory.GetFiles(input, "*.json", SearchOption.AllDirectories);
        return files.ToList();
    }
}