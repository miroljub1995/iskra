using System.Text.Json;
using Iskra.WebIDLGenerator.Models;
using Microsoft.Extensions.Logging;

namespace Iskra.WebIDLGenerator.Generators;

public class ModuleGenerator(
    ILogger<ModuleGenerator> logger,
    CallbackTypeGenerator callbackTypeGenerator,
    EnumTypeGenerator enumTypeGenerator,
    InterfaceTypeGenerator interfaceTypeGenerator,
    GenTypeDescriptors genTypeDescriptors
)
{
    public async Task GenerateAsync(string path, string outputDir,
        CancellationToken cancellationToken = default)
    {
        var moduleContent = await File.ReadAllTextAsync(path, cancellationToken);

        if (JsonSerializer.Deserialize(moduleContent, typeof(IDLModule), WebIdlJsonContext.Default) is not IDLModule
            module)
        {
            throw new Exception("Failed to deserialize IDLModule.");
        }

        foreach (var idlRootType in module.IDLParsed.IDLNames.Values)
        {
            if (idlRootType is CallbackType callbackType)
            {
                var outputFile = Path.GetFullPath(Path.Combine(outputDir, callbackType.Name + ".cs"));
                if (File.Exists(outputFile))
                {
                    throw new Exception($"Output file {outputFile} already exists.");
                }

                if (!genTypeDescriptors.TryGet(callbackType.Name, out var gen) ||
                    gen.RootType is not CallbackType foundType)
                {
                    throw new Exception($"Unable to find type {callbackType.Name}.");
                }

                var content = callbackTypeGenerator.Generate(foundType);
                await File.WriteAllTextAsync(outputFile, content, cancellationToken);
            }
            else if (idlRootType is InterfaceType interfaceType)
            {
                var outputFile = Path.GetFullPath(Path.Combine(outputDir, interfaceType.Name + ".cs"));
                if (File.Exists(outputFile))
                {
                    throw new Exception($"Output file {outputFile} already exists.");
                }

                if (!genTypeDescriptors.TryGet(interfaceType.Name, out var gen) ||
                    gen.RootType is not InterfaceType foundType)
                {
                    throw new Exception($"Unable to find type {interfaceType.Name}.");
                }

                var content = interfaceTypeGenerator.Generate(foundType);
                await File.WriteAllTextAsync(outputFile, content, cancellationToken);
            }
            else if (idlRootType is EnumType enumType)
            {
                var outputFile = Path.GetFullPath(Path.Combine(outputDir, enumType.Name + ".cs"));
                if (File.Exists(outputFile))
                {
                    throw new Exception($"Output file {outputFile} already exists.");
                }

                if (!genTypeDescriptors.TryGet(enumType.Name, out var gen) ||
                    gen.RootType is not EnumType foundType)
                {
                    throw new Exception($"Unable to find type {enumType.Name}.");
                }

                var content = enumTypeGenerator.Generate(foundType);
                await File.WriteAllTextAsync(outputFile, content, cancellationToken);
            }
            else
            {
                logger.LogWarning("Skipping {type}", idlRootType.GetType());
            }
        }
    }
}