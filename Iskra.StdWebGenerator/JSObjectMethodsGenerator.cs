using System.Reflection;
using System.Text;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public class JSObjectMethodsGenerator
{
    public static string Execute(GeneratorContext context)
    {
        var membersList = new List<string>();

        GenerateGetterMethods(context, membersList);

        var members = string.Join("\n\n", membersList);

        return $$"""
                 using System.Runtime.InteropServices.JavaScript;

                 namespace Iskra.StdWeb;

                 public static class JSObjectMethodsExtensions
                 {
                 {{members.IndentLines(4)}}
                 }
                 """;
    }

    private static void GenerateGetterMethods(GeneratorContext context, List<string> outputMembers)
    {
        var methods = context.ObjectMethods.PropertyMethods;
        if (methods.Count == 0)
        {
            return;
        }

        foreach (var method in methods)
        {
            outputMembers.Add(
                $$"""
                  public static void {{method.Name}}(this JSObject obj, string propertyName){} 
                  """
            );
        }
    }
}