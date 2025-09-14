using System.Text.Json;
using Iskra.WebIDLGenerator.Models;
using Microsoft.Extensions.Logging;

namespace Iskra.WebIDLGenerator.Generators;

public class ModuleGenerator(
    ILogger<ModuleGenerator> logger,
    InterfaceGenerator interfaceGenerator
)
{
    public async Task GenerateAsync(string path, string outputDir, string ns,
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
            if (idlRootType is InterfaceType interfaceType)
            {
                var outputFile = Path.GetFullPath(Path.Combine(outputDir, interfaceType.Name + ".cs"));
                if (File.Exists(outputFile))
                {
                    throw new Exception($"Output file {outputFile} already exists.");
                }

                var interfaceContent = interfaceGenerator.Generate(interfaceType, ns);
                await File.WriteAllTextAsync(outputFile, interfaceContent, cancellationToken);
            }
            else
            {
                logger.LogWarning("Skipping {type}", idlRootType.GetType());
            }
        }
    }
}