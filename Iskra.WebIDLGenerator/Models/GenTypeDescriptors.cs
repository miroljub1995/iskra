using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualBasic.CompilerServices;

namespace Iskra.WebIDLGenerator.Models;

public class GenTypeDescriptors
{
    private readonly List<GenTypeDescriptor> _genTypeDescriptors = [];

    public IReadOnlyList<GenTypeDescriptor> Descriptors => _genTypeDescriptors.AsReadOnly();

    public void Add(GenTypeDescriptor genTypeDescriptor)
    {
        if (_genTypeDescriptors.Any(x => x.Name == genTypeDescriptor.Name))
        {
            throw new Exception($"Type Descriptor with name \"{genTypeDescriptor.Name}\" already exists.");
        }

        _genTypeDescriptors.Add(genTypeDescriptor);
    }

    public bool TryGet(string name, [NotNullWhen(true)] out GenTypeDescriptor? genTypeDescriptor)
    {
        genTypeDescriptor = _genTypeDescriptors.SingleOrDefault(x => x.Name == name);
        return genTypeDescriptor is not null;
    }

    public GenTypeDescriptor GetRequired(string name)
    {
        if (TryGet(name, out var descriptor))
        {
            return descriptor;
        }

        throw new Exception($"Type Descriptor with name \"{name}\" does not exist.");
    }

    public void ResolveTypedefs()
    {
        foreach (var genTypeDescriptor in _genTypeDescriptors)
        {
            ResolveTypedefInIDLRootType(genTypeDescriptor.RootType);
        }
    }

    private void ResolveTypedefInIDLRootType(IDLRootType input)
    {
        if (input is CallbackType callbackType)
        {
            ResolveTypedefInCallbackType(callbackType);
        }
        else if (input is CallbackInterfaceType callbackInterfaceType)
        {
            ResolveTypedefInCallbackInterfaceType(callbackInterfaceType);
        }
        else if (input is DictionaryType dictionaryType)
        {
            ResolveTypedefInDictionaryType(dictionaryType);
        }
        else if (input is InterfaceMixinType interfaceMixinType)
        {
            ResolveTypedefInInterfaceMixinType(interfaceMixinType);
        }
        else if (input is InterfaceType interfaceType)
        {
            ResolveTypedefInInterfaceType(interfaceType);
        }
        else if (input is NamespaceType namespaceType)
        {
            ResolveTypedefInNamespaceType(namespaceType);
        }
    }

    private void ResolveTypedefInCallbackType(CallbackType input)
    {
        input.IdlType = ResolveTypedefInIDLTypeDescription(input.IdlType);
        foreach (var arg in input.Arguments)
        {
            arg.IdlType = ResolveTypedefInIDLTypeDescription(arg.IdlType);
        }
    }

    private void ResolveTypedefInCallbackInterfaceType(CallbackInterfaceType input)
    {
        foreach (var member in input.Members)
        {
            ResolveTypedefInMemberType(member);
        }
    }

    private void ResolveTypedefInDictionaryType(DictionaryType input)
    {
        foreach (var member in input.Members)
        {
            member.IdlType = ResolveTypedefInIDLTypeDescription(member.IdlType);
        }
    }

    private void ResolveTypedefInInterfaceMixinType(InterfaceMixinType input)
    {
        foreach (var member in input.Members)
        {
            ResolveTypedefInMemberType(member);
        }
    }

    private void ResolveTypedefInInterfaceType(InterfaceType input)
    {
        foreach (var member in input.Members)
        {
            ResolveTypedefInMemberType(member);
        }
    }

    private void ResolveTypedefInNamespaceType(NamespaceType input)
    {
        foreach (var member in input.Members)
        {
            ResolveTypedefInMemberType(member);
        }
    }

    private void ResolveTypedefInMemberType(IDLCallbackInterfaceMemberType input)
    {
        if (input is AttributeMemberType attribute)
        {
            attribute.IdlType = ResolveTypedefInIDLTypeDescription(attribute.IdlType);
        }
        else if (input is ConstantMemberType constant)
        {
            constant.IdlType = ResolveTypedefInIDLTypeDescription(constant.IdlType);
        }
        else if (input is ConstructorMemberType constructor)
        {
            foreach (var arg in constructor.Arguments)
            {
                arg.IdlType = ResolveTypedefInIDLTypeDescription(arg.IdlType);
            }
        }
        else if (input is IterableDeclarationMemberType iterable)
        {
            for (var i = 0; i < iterable.IdlType.Count; i++)
            {
                iterable.IdlType[i] = ResolveTypedefInIDLTypeDescription(iterable.IdlType[i]);
            }

            foreach (var arg in iterable.Arguments)
            {
                arg.IdlType = ResolveTypedefInIDLTypeDescription(arg.IdlType);
            }
        }
        else if (input is AsyncIterableMemberType asyncIterable)
        {
            for (var i = 0; i < asyncIterable.IdlType.Count; i++)
            {
                asyncIterable.IdlType[i] = ResolveTypedefInIDLTypeDescription(asyncIterable.IdlType[i]);
            }

            foreach (var arg in asyncIterable.Arguments)
            {
                arg.IdlType = ResolveTypedefInIDLTypeDescription(arg.IdlType);
            }
        }
        else if (input is MaplikeDeclarationMemberType maplikeDeclaration)
        {
            for (var i = 0; i < maplikeDeclaration.IdlType.Count; i++)
            {
                maplikeDeclaration.IdlType[i] = ResolveTypedefInIDLTypeDescription(maplikeDeclaration.IdlType[i]);
            }
        }
        else if (input is SetlikeDeclarationMemberType setlikeDeclaration)
        {
            for (var i = 0; i < setlikeDeclaration.IdlType.Count; i++)
            {
                setlikeDeclaration.IdlType[i] = ResolveTypedefInIDLTypeDescription(setlikeDeclaration.IdlType[i]);
            }
        }
        else if (input is OperationMemberType operation)
        {
            if (operation.IdlType is not null)
            {
                operation.IdlType = ResolveTypedefInIDLTypeDescription(operation.IdlType);
            }

            foreach (var arg in operation.Arguments)
            {
                arg.IdlType = ResolveTypedefInIDLTypeDescription(arg.IdlType);
            }
        }
        else
        {
            throw new Exception($"Unknown IDL type: {input.GetType()}");
        }
    }

    private IDLTypeDescription ResolveTypedefInIDLTypeDescription(IDLTypeDescription input)
    {
        if (input is SingleTypeDescription singleTypeDescription)
        {
            if (TryGet(singleTypeDescription.IdlType, out var desc) && desc.RootType is TypedefType typedefType)
            {
                var resolvedSingle = ResolveTypedefInIDLTypeDescription(typedefType.IdlType);
                resolvedSingle.Nullable |= input.Nullable;
                return resolvedSingle;
            }

            return new SingleTypeDescription
            {
                IdlType = singleTypeDescription.IdlType,
                Nullable = singleTypeDescription.Nullable,
                ExtAttrs = singleTypeDescription.ExtAttrs,
            };
        }
        else if (input is FrozenArrayTypeDescription frozenArrayTypeDescription)
        {
            return new FrozenArrayTypeDescription
            {
                Nullable = frozenArrayTypeDescription.Nullable,
                IdlType = frozenArrayTypeDescription.IdlType
                    .Select(ResolveTypedefInIDLTypeDescription)
                    .ToList(),
                ExtAttrs = frozenArrayTypeDescription.ExtAttrs,
            };
        }
        else if (input is ObservableArrayTypeDescription observableArrayTypeDescription)
        {
            return new ObservableArrayTypeDescription
            {
                Nullable = observableArrayTypeDescription.Nullable,
                IdlType = observableArrayTypeDescription.IdlType
                    .Select(ResolveTypedefInIDLTypeDescription)
                    .ToList(),
                ExtAttrs = observableArrayTypeDescription.ExtAttrs,
            };
        }
        else if (input is PromiseTypeDescription promiseTypeDescription)
        {
            return new PromiseTypeDescription
            {
                Nullable = promiseTypeDescription.Nullable,
                IdlType = promiseTypeDescription.IdlType
                    .Select(ResolveTypedefInIDLTypeDescription)
                    .ToList(),
                ExtAttrs = promiseTypeDescription.ExtAttrs,
            };
        }
        else if (input is RecordTypeDescription recordTypeDescription)
        {
            return new RecordTypeDescription
            {
                Nullable = recordTypeDescription.Nullable,
                IdlType = recordTypeDescription.IdlType
                    .Select(ResolveTypedefInIDLTypeDescription)
                    .ToList(),
                ExtAttrs = recordTypeDescription.ExtAttrs,
            };
        }
        else if (input is SequenceTypeDescription sequenceTypeDescription)
        {
            return new SequenceTypeDescription
            {
                Nullable = sequenceTypeDescription.Nullable,
                IdlType = sequenceTypeDescription.IdlType
                    .Select(ResolveTypedefInIDLTypeDescription)
                    .ToList(),
                ExtAttrs = sequenceTypeDescription.ExtAttrs,
            };
        }
        else if (input is UnionTypeDescription unionTypeDescription)
        {
            return FlattenUnionTypeDescription(new UnionTypeDescription
            {
                Nullable = unionTypeDescription.Nullable,
                IdlType = unionTypeDescription.IdlType
                    .Select(ResolveTypedefInIDLTypeDescription)
                    .ToList(),
                ExtAttrs = unionTypeDescription.ExtAttrs,
            });
        }

        throw new Exception($"Unknown IDL type: {input.GetType()}");
    }

    private static IDLTypeDescription FlattenUnionTypeDescription(UnionTypeDescription input)
    {
        var nullable = input.Nullable;
        List<IDLTypeDescription> flattenedIdlType = [];
        foreach (var type in input.IdlType)
        {
            if (type is UnionTypeDescription unionTypeDescription)
            {
                var flattenedNestedType = FlattenUnionTypeDescription(unionTypeDescription);
                if (flattenedNestedType is UnionTypeDescription nestedUnionTypeDescription)
                {
                    flattenedIdlType.AddRange(nestedUnionTypeDescription.IdlType);
                }
                else
                {
                    flattenedIdlType.Add(flattenedNestedType);
                }

                nullable |= flattenedNestedType.Nullable;
            }
            else if (type is SingleTypeDescription { IdlType: BuiltinTypes.Undefined })
            {
                nullable = true;
            }
            else
            {
                flattenedIdlType.Add(type);
                nullable |= type.Nullable;
            }
        }

        if (flattenedIdlType.Count == 1)
        {
            return flattenedIdlType[0] with { Nullable = flattenedIdlType[0].Nullable || nullable };
        }

        return new UnionTypeDescription
        {
            Nullable = nullable,
            IdlType = flattenedIdlType,
            ExtAttrs = input.ExtAttrs,
        };
    }
}