using Iskra.WebIDLGenerator.Extensions;
using Iskra.WebIDLGenerator.Models;
using Microsoft.Extensions.Logging;

namespace Iskra.WebIDLGenerator.Generators;

public class ModuleGenerator(
    GenSettings genSettings,
    ILogger<ModuleGenerator> logger,
    CallbackTypeGenerator callbackTypeGenerator,
    CallbackInterfaceTypeGenerator callbackInterfaceTypeGenerator,
    DictionaryTypeGenerator dictionaryTypeGenerator,
    EnumTypeGenerator enumTypeGenerator,
    InterfaceTypeGenerator interfaceTypeGenerator,
    GenTypeDescriptors genTypeDescriptors,
    NamespaceTypeGenerator namespaceTypeGenerator
)
{
    public async Task GenerateAsync(CancellationToken cancellationToken = default)
    {
        foreach (var desc in genTypeDescriptors.Descriptors)
        {
            if (!desc.IsMain)
            {
                continue;
            }

            var idlRootType = desc.RootType;

            if (idlRootType is CallbackType callbackType)
            {
                var outputFile = Path.GetFullPath(Path.Combine(genSettings.Output, callbackType.Name + ".cs"));
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
            else if (idlRootType is CallbackInterfaceType callbackInterfaceType)
            {
                var outputFile = Path.GetFullPath(Path.Combine(genSettings.Output, callbackInterfaceType.Name + ".cs"));
                if (File.Exists(outputFile))
                {
                    throw new Exception($"Output file {outputFile} already exists.");
                }

                if (!genTypeDescriptors.TryGet(callbackInterfaceType.Name, out var gen) ||
                    gen.RootType is not CallbackInterfaceType foundType)
                {
                    throw new Exception($"Unable to find type {callbackInterfaceType.Name}.");
                }

                var content = callbackInterfaceTypeGenerator.Generate(foundType);
                await File.WriteAllTextAsync(outputFile, content, cancellationToken);
            }
            else if (idlRootType is DictionaryType dictionaryType)
            {
                var outputFile = Path.GetFullPath(Path.Combine(genSettings.Output, dictionaryType.Name + ".cs"));
                if (File.Exists(outputFile))
                {
                    throw new Exception($"Output file {outputFile} already exists.");
                }

                if (!genTypeDescriptors.TryGet(dictionaryType.Name, out var gen) ||
                    gen.RootType is not DictionaryType foundType)
                {
                    throw new Exception($"Unable to find type {dictionaryType.Name}.");
                }

                var content = dictionaryTypeGenerator.Generate(foundType);
                await File.WriteAllTextAsync(outputFile, content, cancellationToken);
            }
            else if (idlRootType is InterfaceType interfaceType)
            {
                var outputFile = Path.GetFullPath(Path.Combine(genSettings.Output, interfaceType.Name + ".cs"));
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
                var outputFile = Path.GetFullPath(Path.Combine(genSettings.Output, enumType.Name + ".cs"));
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
            else if (idlRootType is TypedefType)
            {
                // No need to generate typedefs.
            }
            else if (idlRootType is InterfaceMixinType)
            {
                // No need to generate interface mixins.
            }
            else if (idlRootType is NamespaceType namespaceType)
            {
                var fileName = $"{namespaceType.Name.CapitalizeFirstLetter()}Namespace.cs";
                var outputFile = Path.GetFullPath(Path.Combine(genSettings.Output, fileName));
                if (File.Exists(outputFile))
                {
                    throw new Exception($"Output file {outputFile} already exists.");
                }

                var content = namespaceTypeGenerator.Generate(namespaceType);
                await File.WriteAllTextAsync(outputFile, content, cancellationToken);
            }
            else
            {
                logger.LogWarning("Skipping {type}", idlRootType.GetType());
            }
        }
    }
}