using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator.Marshalling.Concrete;

public class MarshallerJSObjectToOneOf : Marshaller
{
    public override bool CanMarshall(MyType type, MyType destination)
        => !type.IsNullable
           && !destination.IsNullable
           && type.Type == typeof(JSObject)
           && destination.Type.IsOneOf();

    public override string Marshall(MyType inputType, string inputVar, MyType outputType, string outputVar,
        GeneratorContext context)
    {
        EnsureCanMarshall(inputType, outputType);

        var propTypeVar = context.GetNextVariableName();

        List<string> genericArgs = [];
        foreach (MyType argType in outputType.GenericTypeArguments)
        {
            genericArgs.Add($$"""
                              {{(genericArgs.Count == 0 ? "if" : "else if")}}({{GetCondition(argType, propTypeVar)}})
                              {
                              {{PropertyGetGenerator.Execute(argType, inputVar, outputVar, "value", context).IndentLines(4)}}
                              }
                              """);
        }

        genericArgs.Add($$"""
                          else
                          {
                              throw new Exception($"Can not convert value type {{{propTypeVar}}} to OneOf.");
                          }
                          """);

        return $$"""
                 string {{propTypeVar}} = {{inputVar}}.GetTypeOfProperty("value");
                 {{string.Join("\n", genericArgs)}}
                 """;
    }

    private string GetCondition(MyType type, string propTypeVar)
    {
        return type switch
        {
            _ when type.Type == typeof(bool) => $$"""
                                                  {{propTypeVar}} == "boolean" 
                                                  """,
            _ when type.Type == typeof(int) => $$"""
                                                 {{propTypeVar}} == "number" 
                                                 """,
            _ when type.Type == typeof(long) => $$"""
                                                  {{propTypeVar}} == "number" 
                                                  """,
            _ when type.Type == typeof(double) => $$"""
                                                    {{propTypeVar}} == "number" 
                                                    """,
            _ when type.Type == typeof(string) => $$"""
                                                    {{propTypeVar}} == "string" 
                                                    """,
            _ => throw new($"Type {type} is not supported.")
        };
    }
}