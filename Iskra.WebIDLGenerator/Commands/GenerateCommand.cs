using System.CommandLine;
using System.Text.Json;
using Iskra.WebIDLGenerator.Generators;
using Iskra.WebIDLGenerator.Marshallers;
using Iskra.WebIDLGenerator.Models;
using Iskra.WebIDLGenerator.Utils;
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
            var genSettingsFullPath = Path.GetFullPath(genSettingsPath, AppDomain.CurrentDomain.BaseDirectory);

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
                .AddSingleton<ArgumentsToArgsArrayGenerator>()
                .AddSingleton<ArgumentsToDeclarationGenerator>()
                .AddSingleton<AttributeMemberTypeGenerator>()
                .AddSingleton<CallbackTypeGenerator>()
                .AddSingleton<ConstantMemberTypeGenerator>()
                .AddSingleton<CallbackInterfaceTypeGenerator>()
                .AddSingleton<ConstructorMemberTypeGenerator>()
                .AddSingleton<DictionaryTypeGenerator>()
                .AddSingleton<EnumTypeGenerator>()
                .AddSingleton<GenericMarshallerGenerator>()
                .AddSingleton<GetPropertyValueGenerator>()
                .AddSingleton<IDLTypeDescriptionToTypeDeclarationGenerator>()
                .AddSingleton<InterfaceTypeGenerator>()
                .AddSingleton<JSProxyFactoryGenerator>()
                .AddSingleton<MemberTypeGenerator>()
                .AddSingleton<ModuleGenerator>()
                .AddSingleton<NamespaceTypeGenerator>()
                .AddSingleton<OperationMemberTypeGenerator>()
                .AddSingleton<PropertyAccessorGenerator>()
                .AddSingleton<SetPropertyValueGenerator>()
                // Marshaller
                .AddSingleton<IDLTypeDescriptionMarshaller>();

            await using var provider = services.BuildServiceProvider();

            ILogger logger = provider.GetRequiredService<ILogger<GenerateCommand>>();

            var inputFiles = GetModuleFiles(genSettings.Inputs);

            if (Directory.Exists(genSettings.Output))
            {
                Directory.Delete(genSettings.Output, true);
            }

            Directory.CreateDirectory(genSettings.Output);

            var genTypeDescriptors = provider.GetRequiredService<GenTypeDescriptors>();

            await AddGenSettingsToDescriptorsAsync(
                descriptors: genTypeDescriptors,
                gensettingsPath: genSettingsFullPath,
                isMain: true,
                cancellationToken: cancellationToken
            );

            genTypeDescriptors.ResolveTypedefs();
            genTypeDescriptors.ResolveAnyTypes();

            var moduleGenerator = provider.GetRequiredService<ModuleGenerator>();
            await moduleGenerator.GenerateAsync(cancellationToken);

            var jsProxyFactoryGenerator = provider.GetRequiredService<JSProxyFactoryGenerator>();
            await jsProxyFactoryGenerator.GenerateAsync(cancellationToken);

            var genericMarshallerGenerator = provider.GetRequiredService<GenericMarshallerGenerator>();
            await genericMarshallerGenerator.GenerateAsync(cancellationToken);

            var propertyAccessorGenerator = provider.GetRequiredService<PropertyAccessorGenerator>();
            await propertyAccessorGenerator.GenerateAsync(cancellationToken);
        });
    }

    private static void AddOrMergeInterface(
        GenTypeDescriptors descriptors,
        InterfaceType interfaceType,
        string typeNamespace,
        bool isMain
    )
    {
        if (descriptors.TryGet(interfaceType.Name, out var descriptor))
        {
            if (descriptor.RootType is InterfaceType existing)
            {
                if (existing.Inheritance is not null && interfaceType.Inheritance is not null)
                {
                    throw new Exception("Inheritance is already defined.");
                }

                existing.Inheritance ??= interfaceType.Inheritance;

                // Some constructors are duplicate, not sure if this is bug in webref
                var newMembers = interfaceType.Members
                    .Where(x => x is not ConstructorMemberType constructor ||
                                existing.Members.All(y => y is not ConstructorMemberType existingConstructor ||
                                                          constructor.Arguments.Count !=
                                                          existingConstructor.Arguments.Count ||
                                                          !constructor.Arguments.All(arg =>
                                                              existingConstructor.Arguments.All(existingArg =>
                                                                  IDLTypeDescriptionEqualityComparer.Instance
                                                                      .Equals(existingArg.IdlType, arg.IdlType)
                                                              )
                                                          )
                                )
                    )
                    .ToList();

                existing.Members.AddRange(newMembers);
                existing.ExtAttrs.AddRange(interfaceType.ExtAttrs);
            }
            else
            {
                throw new Exception("Something went wrong.");
            }
        }
        else
        {
            descriptors.Add(new GenTypeDescriptor
            {
                Namespace = typeNamespace,
                Name = interfaceType.Name,
                RootType = interfaceType,
                IsMain = isMain,
            });
        }
    }

    private static void AddOrMergeInterfaceMixin(
        GenTypeDescriptors descriptors,
        InterfaceMixinType interfaceMixinType,
        string typeNamespace,
        bool isMain
    )
    {
        if (descriptors.TryGet(interfaceMixinType.Name, out var descriptor))
        {
            if (descriptor.RootType is InterfaceMixinType existing)
            {
                existing.Members.AddRange(interfaceMixinType.Members);
                existing.ExtAttrs.AddRange(interfaceMixinType.ExtAttrs);
            }
            else
            {
                throw new Exception("Something went wrong.");
            }
        }
        else
        {
            descriptors.Add(new GenTypeDescriptor
            {
                Namespace = typeNamespace,
                Name = interfaceMixinType.Name,
                RootType = interfaceMixinType,
                IsMain = isMain,
            });
        }
    }

    private static void AddOrMergeNamespace(
        GenTypeDescriptors descriptors,
        NamespaceType namespaceType,
        string typeNamespace,
        bool isMain
    )
    {
        if (descriptors.TryGet(namespaceType.Name, out var descriptor))
        {
            if (descriptor.RootType is NamespaceType existing)
            {
                existing.Members.AddRange(namespaceType.Members);
                existing.ExtAttrs.AddRange(namespaceType.ExtAttrs);
            }
            else
            {
                throw new Exception("Something went wrong.");
            }
        }
        else
        {
            descriptors.Add(new GenTypeDescriptor
            {
                Namespace = typeNamespace,
                Name = namespaceType.Name,
                RootType = namespaceType,
                IsMain = isMain,
            });
        }
    }

    private static void AddOrMergeDictionary(
        GenTypeDescriptors descriptors,
        DictionaryType dictionaryType,
        string typeNamespace,
        bool isMain
    )
    {
        if (descriptors.TryGet(dictionaryType.Name, out var descriptor))
        {
            if (descriptor.RootType is DictionaryType existing)
            {
                existing.Members.AddRange(dictionaryType.Members);
                existing.ExtAttrs.AddRange(dictionaryType.ExtAttrs);
            }
            else
            {
                throw new Exception("Something went wrong.");
            }
        }
        else
        {
            descriptors.Add(new GenTypeDescriptor
            {
                Namespace = typeNamespace,
                Name = dictionaryType.Name,
                RootType = dictionaryType,
                IsMain = isMain,
            });
        }
    }

    private static async Task AddGenSettingsToDescriptorsAsync(
        GenTypeDescriptors descriptors,
        string gensettingsPath,
        bool isMain,
        CancellationToken cancellationToken = default
    )
    {
        var settings = await GenSettings.ReadFromFileAsync(gensettingsPath, cancellationToken);

        foreach (var reference in settings.References)
        {
            await AddGenSettingsToDescriptorsAsync(descriptors, reference, false, cancellationToken);
        }

        List<IncludesType> includes = [];

        var moduleFiles = GetModuleFiles(settings.Inputs);
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
                        IsMain = isMain,
                    });
                }
                else if (idlRootType is CallbackInterfaceType callbackInterfaceType)
                {
                    descriptors.Add(new GenTypeDescriptor
                    {
                        Namespace = settings.Namespace,
                        Name = callbackInterfaceType.Name,
                        RootType = idlRootType,
                        IsMain = isMain,
                    });
                }
                else if (idlRootType is DictionaryType dictionaryType)
                {
                    AddOrMergeDictionary(descriptors, dictionaryType, settings.Namespace, isMain);
                }
                else if (idlRootType is EnumType enumType)
                {
                    descriptors.Add(new GenTypeDescriptor
                    {
                        Namespace = settings.Namespace,
                        Name = enumType.Name,
                        RootType = idlRootType,
                        IsMain = isMain,
                    });
                }
                else if (idlRootType is InterfaceMixinType interfaceMixinType)
                {
                    AddOrMergeInterfaceMixin(descriptors, interfaceMixinType, settings.Namespace, isMain);
                }
                else if (idlRootType is InterfaceType interfaceType)
                {
                    AddOrMergeInterface(descriptors, interfaceType, settings.Namespace, isMain);
                }
                else if (idlRootType is NamespaceType namespaceType)
                {
                    AddOrMergeNamespace(descriptors, namespaceType, settings.Namespace, isMain);
                }
                else if (idlRootType is TypedefType typedefType)
                {
                    descriptors.Add(new GenTypeDescriptor
                    {
                        Namespace = settings.Namespace,
                        Name = typedefType.Name,
                        RootType = idlRootType,
                        IsMain = isMain,
                    });
                }
                else if (idlRootType is IncludesType includesType)
                {
                    includes.Add(includesType);
                }
                else
                {
                    throw new Exception("Something went wrong.");
                }
            }

            foreach (var extendedIdlRootTypes in module.IDLParsed.IDLExtendedNames.Values)
            {
                foreach (var extendedIdlRootType in extendedIdlRootTypes)
                {
                    if (extendedIdlRootType is InterfaceType interfaceType)
                    {
                        AddOrMergeInterface(descriptors, interfaceType, settings.Namespace, isMain);
                    }
                    else if (extendedIdlRootType is InterfaceMixinType interfaceMixinType)
                    {
                        AddOrMergeInterfaceMixin(descriptors, interfaceMixinType, settings.Namespace, isMain);
                    }
                    else if (extendedIdlRootType is NamespaceType namespaceType)
                    {
                        AddOrMergeNamespace(descriptors, namespaceType, settings.Namespace, isMain);
                    }
                    else if (extendedIdlRootType is DictionaryType dictionaryType)
                    {
                        AddOrMergeDictionary(descriptors, dictionaryType, settings.Namespace, isMain);
                    }
                    else if (extendedIdlRootType is IncludesType extendedIncludesType)
                    {
                        includes.Add(extendedIncludesType);
                    }
                    else
                    {
                        throw new Exception("Something went wrong.");
                    }
                }
            }
        }

        foreach (var include in includes)
        {
            if (
                descriptors.TryGet(include.Target, out var targetDesc) &&
                descriptors.TryGet(include.Includes, out var includesDesc) &&
                includesDesc.RootType is InterfaceMixinType mixinType
            )
            {
                if (targetDesc.RootType is InterfaceType targetInterfaceType)
                {
                    foreach (var member in mixinType.Members)
                    {
                        if (member is AttributeMemberType attributeMemberType)
                        {
                            targetInterfaceType.Members.Add(attributeMemberType);
                        }
                        else if (member is ConstantMemberType constantMemberType)
                        {
                            targetInterfaceType.Members.Add(constantMemberType);
                        }
                        else if (member is OperationMemberType operationMemberType)
                        {
                            targetInterfaceType.Members.Add(operationMemberType);
                        }
                        else
                        {
                            throw new Exception("Something went wrong.");
                        }
                    }
                }
                else
                {
                    throw new Exception("Something went wrong.");
                }
            }
            else
            {
                throw new Exception("Something went wrong.");
            }
        }
    }

    private static List<string> GetModuleFiles(List<string> inputs)
    {
        List<string> res = [];
        foreach (var input in inputs)
        {
            if (!File.Exists(input) && !Directory.Exists(input))
            {
                throw new Exception($"Input \"{input}\" is not found.");
            }

            var isInputFile = File.Exists(input);
            if (isInputFile)
            {
                return [input];
            }

            var files = Directory.GetFiles(input, "*.json", SearchOption.AllDirectories);
            res.AddRange(files.ToList());
        }

        return res;
    }
}