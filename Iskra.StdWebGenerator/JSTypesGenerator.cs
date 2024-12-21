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

        var allTypesToGenerate = assembly.GetTypes().Where(x => x.IsJSObjectWrapper());

        foreach (var type in allTypesToGenerate)
        {
            var typeContent = type switch
            {
                _ when type.IsSubclassOf(typeof(Delegate)) => DelegateGenerator.Execute(type),
                _ => JSTypeGenerator.Execute(type),
            };

            var outputFilePath = Path.Join(targetDir, $"{TypeNameGenerator.Execute(type)}.cs");
            await File.WriteAllTextAsync(outputFilePath, typeContent);
        }
    }
}