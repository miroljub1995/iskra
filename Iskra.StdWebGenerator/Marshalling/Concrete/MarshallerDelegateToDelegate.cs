using System.Reflection;
using Iskra.StdWebGenerator.Extensions;
using Iskra.StdWebGenerator.GeneratorContexts;

namespace Iskra.StdWebGenerator.Marshalling.Concrete;

public class MarshallerDelegateToDelegate : Marshaller
{
    public override bool CanMarshall(MyType type, MyType destination)
        => !type.IsNullable
           && !destination.IsNullable
           && type.Type.IsSubclassOf(typeof(Delegate))
           && destination.Type.IsSubclassOf(typeof(Delegate));

    public override string Marshall(
        MyType inputType,
        string inputVar,
        MyType outputType,
        string outputVar,
        GeneratorContext context
    )
    {
        EnsureCanMarshall(inputType, outputType);

        var inputParameters = GetDelegateParameterTypes(inputType);
        var outputParameters = GetDelegateParameterTypes(outputType);

        var inputReturnType = GetDelegateReturnType(inputType);
        var outputReturnType = GetDelegateReturnType(outputType);

        var outputParameterVars = outputParameters
            .Select(_ => context.GetNextVariableName())
            .ToList();

        var marshalledParametersVar = outputParameters
            .Select(_ => context.GetNextVariableName())
            .ToList();

        var marshalledParameters = inputParameters
            .Select((outParam, i) =>
            {
                var marshallRes = Marshallers.Instance
                    .GetNext(outputParameters[i], outParam)
                    .Marshall(outputParameters[i], outputParameterVars[i], outParam, marshalledParametersVar[i],
                        context);

                return $$"""
                         {{TypeNameGenerator.Execute(outParam)}} {{marshalledParametersVar[i]}};
                         {{marshallRes}}
                         """;
            }).ToList();

        var inputParameterList = string.Join(", ", outputParameterVars);
        var marshalledParametersList = string.Join(", ", marshalledParametersVar);

        if (inputReturnType is null && outputReturnType is null)
        {
            return $$"""
                     {{outputVar}} = ({{inputParameterList}}) =>
                     {
                     {{string.Join("\n\n", marshalledParameters).IndentLines(4)}}
                         {{inputVar}}({{marshalledParametersList}});
                     };
                     """;
        }
        else if (inputReturnType is not null && outputReturnType is not null)
        {
            throw new Exception("Func is currently not supported.");
        }
        else
        {
            throw new Exception("Can not mix Action and Func.");
        }
    }

    private static MyType[] GetDelegateParameterTypes(MyType type)
    {
        if (type.Type.IsGenericType && type.Type.GetGenericTypeDefinition() is { } def)
        {
            if (def == typeof(Action<>) ||
                def == typeof(Action<,>) ||
                def == typeof(Action<,,>) ||
                def == typeof(Action<,,,>) ||
                def == typeof(Action<,,,,>))
            {
                return type.GenericTypeArguments;
            }

            if (def == typeof(Func<>) ||
                def == typeof(Func<,>) ||
                def == typeof(Func<,,>) ||
                def == typeof(Func<,,,>) ||
                def == typeof(Func<,,,,>))
            {
                return type.GenericTypeArguments[..^1];
            }
        }

        var inputMethodInfo = type.Type.GetDelegateMethodInfo();
        return inputMethodInfo.GetParameters().Select(MyType.From).ToArray();
    }

    private static MyType? GetDelegateReturnType(MyType type)
    {
        if (type.Type.IsGenericType && type.Type.GetGenericTypeDefinition() is { } def)
        {
            if (def == typeof(Action<>) ||
                def == typeof(Action<,>) ||
                def == typeof(Action<,,>) ||
                def == typeof(Action<,,,>) ||
                def == typeof(Action<,,,,>))
            {
                return null;
            }

            if (def == typeof(Func<>) ||
                def == typeof(Func<,>) ||
                def == typeof(Func<,,>) ||
                def == typeof(Func<,,,>) ||
                def == typeof(Func<,,,,>))
            {
                return type.GenericTypeArguments[^1];
            }
        }

        var inputMethodInfo = type.Type.GetDelegateMethodInfo();
        return inputMethodInfo.IsVoid() ? null : MyType.From(inputMethodInfo.ReturnParameter);
    }
}