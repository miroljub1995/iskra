using System.Reflection;
using Iskra.StdWebApi.Attributes;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public static class JSTypesGenerator
{
    public static async Task ExecuteAsync(Assembly assembly, string targetDir)
    {
        if (Directory.Exists(targetDir))
        {
            Directory.Delete(targetDir, true);
        }

        Directory.CreateDirectory(targetDir);

        GeneratorContext context = new();

        var allTypesToGenerate = assembly
            .GetTypes()
            .Where(x => x.IsJSObjectWrapper() || x.IsSubclassOf(typeof(Delegate)));

        foreach (var type in allTypesToGenerate)
        {
            var typeContent = type switch
            {
                _ when type.IsSubclassOf(typeof(Delegate)) => DelegateGenerator.Execute(type),
                _ => JSTypeGenerator.Execute(type, context),
            };

            var outputFilePath = Path.Join(targetDir, $"{TypeNameGenerator.Execute(type, null)}.cs");
            await File.WriteAllTextAsync(outputFilePath, typeContent);
        }

        await File.WriteAllTextAsync(
            Path.Join(targetDir, $"{context.ObjectMethods.ClassName}.cs"),
            context.ObjectMethods.ClassCode
        );

        await File.WriteAllTextAsync(
            Path.Join(targetDir, $"{context.GlobalFunctions.ClassName}.cs"),
            context.GlobalFunctions.ClassCode
        );
    }
}