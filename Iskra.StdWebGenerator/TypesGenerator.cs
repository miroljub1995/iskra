using System.Reflection;
using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebGenerator;

public static class TypesGenerator
{
    public static async Task ExecuteAsync(Assembly assembly, string targetDir)
    {
        if (Directory.Exists(targetDir))
        {
            Directory.Delete(targetDir, true);
        }

        Directory.CreateDirectory(targetDir);

        var allTypesToGenerate = assembly.GetTypes().Where(x => x.IsDefined(typeof(GenerateBindingsAttribute)));

        foreach (var type in allTypesToGenerate)
        {
            var (typeContent, name) = TypeGenerator.Execute(type);

            var outputFilePath = Path.Join(targetDir, $"{name}.cs");
            await File.WriteAllTextAsync(outputFilePath, typeContent);
        }
    }
}