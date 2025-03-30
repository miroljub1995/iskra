using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator.Marshalling.Concrete;

public class MarshallerObjectToOneOf : Marshaller
{
    public override bool CanMarshall(MyType type, MyType destination)
        => !type.IsNullable
           && !destination.IsNullable
           && type.Type == typeof(object)
           && destination.Type.IsOneOf();

    public override string Marshall(MyType inputType, string inputVar, MyType outputType, string outputVar,
        GeneratorContext context)
    {
        EnsureCanMarshall(inputType, outputType);

        List<string> genericArgs = [];
        foreach (MyType argType in outputType.GenericTypeArguments)
        {
            (string condition, MyType objectValueType, string conditionVar) =
                GetConditionV2(argType, inputVar, context);

            var marshalledArgVar = context.GetNextVariableName();

            var marshalledArgRes = Marshallers.Instance
                .GetNext(objectValueType, argType)
                .Marshall(objectValueType, conditionVar, argType, marshalledArgVar, context);

            genericArgs.Add($$"""
                              {{(genericArgs.Count == 0 ? "if" : "else if")}}({{condition}})
                              {
                                  {{TypeNameGenerator.Execute(argType)}} {{marshalledArgVar}};
                              {{marshalledArgRes.IndentLines(4)}}
                                  {{outputVar}} = {{marshalledArgVar}};
                              }
                              """);
        }

        genericArgs.Add($$"""
                          else
                          {
                              throw new Exception($"Can not convert value type {{{inputVar}}.GetType()} to OneOf<...>.");
                          }
                          """);

        return $$"""
                 {{string.Join("\n", genericArgs)}}
                 """;
    }

    private static (string condition, MyType valueType, string conditionVar) GetConditionV2(MyType type,
        string inputVar, GeneratorContext context)
    {
        if (type.Type == typeof(bool))
        {
            var conditionVar = context.GetNextVariableName();
            return (
                $$"""
                  {{inputVar}} is bool {{conditionVar}}
                  """,
                type,
                conditionVar
            );
        }
        else if (type.Type == typeof(int))
        {
            var conditionVar = context.GetNextVariableName();
            return (
                $$"""
                  {{inputVar}} is double {{conditionVar}}
                  """,
                type with { Type = typeof(double) },
                conditionVar
            );
        }
        else if (type.Type == typeof(long))
        {
            var conditionVar = context.GetNextVariableName();
            return (
                $$"""
                  {{inputVar}} is double {{conditionVar}}
                  """,
                type with { Type = typeof(double) },
                conditionVar
            );
        }
        else if (type.Type == typeof(double))
        {
            var conditionVar = context.GetNextVariableName();
            return (
                $$"""
                  {{inputVar}} is double {{conditionVar}}
                  """,
                type,
                conditionVar
            );
        }
        else if (type.Type == typeof(string))
        {
            var conditionVar = context.GetNextVariableName();
            return (
                $$"""
                  {{inputVar}} is string {{conditionVar}}
                  """,
                type,
                conditionVar
            );
        }
        else if (type.Type == typeof(JSObject))
        {
            var conditionVar = context.GetNextVariableName();
            return (
                $$"""
                  {{inputVar}} is JSObject {{conditionVar}}
                  """,
                type,
                conditionVar
            );
        }
        else
        {
            throw new Exception($"Type {type} is not supported.");
        }
    }
}