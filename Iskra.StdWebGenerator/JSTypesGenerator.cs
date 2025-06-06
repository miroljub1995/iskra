using System.Reflection;
using Iskra.StdWebGenerator.Extensions;
using Iskra.StdWebGenerator.GeneratorContexts;

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
            var typeName = TypeNameGenerator.Execute(new MyType(type, false, null, []));

            var typeContent = type switch
            {
                _ when type.IsSubclassOf(typeof(Delegate)) => DelegateGenerator.Execute(type),
                _ => JSTypeGenerator.Execute(type, context),
            };

            var outputFilePath = Path.Join(targetDir, $"{typeName}.cs");
            await File.WriteAllTextAsync(outputFilePath, typeContent);
        }

        await File.WriteAllTextAsync(
            Path.Join(targetDir, $"{context.GlobalFunctions.ClassName}.cs"),
            context.GlobalFunctions.ClassCode
        );

        await File.WriteAllTextAsync(
            Path.Join(targetDir, $"{context.DelegateMappers.ClassName}.cs"),
            context.DelegateMappers.ClassCode
        );
    }
}