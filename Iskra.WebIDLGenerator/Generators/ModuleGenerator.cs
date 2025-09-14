using System.Text.Json;
using Iskra.WebIDLGenerator.Models;
using Microsoft.Extensions.Logging;

namespace Iskra.WebIDLGenerator.Generators;

public class ModuleGenerator(
    ILogger<ModuleGenerator> logger,
    InterfaceGenerator interfaceGenerator
)
{
    public async Task GenerateAsync(string path, string outputDir, string ns)
    {
        var moduleContent = await File.ReadAllTextAsync(path);

        if (JsonSerializer.Deserialize(moduleContent, typeof(IDLModule), WebIdlJsonContext.Default) is not IDLModule
            module)
        {
            throw new Exception("Failed to deserialize IDLModule.");
        }

        foreach (var idlRootType in module.IDLParsed.IDLNames.Values)
        {
            if (idlRootType is InterfaceType interfaceType)
            {
                var interafce = interfaceGenerator.Generate(interfaceType, ns);
            }
            else
            {
                logger.LogWarning("Skipping {type}", idlRootType.GetType());
            }
        }
    }
}