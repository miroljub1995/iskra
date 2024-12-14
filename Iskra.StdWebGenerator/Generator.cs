using System.Reflection;
using Iskra.StdWebApi.Interfaces;

namespace Iskra.StdWebGenerator;

public static class Generator
{
    public static async Task ExecuteAsync()
    {
        var targetDir =
            Path.GetFullPath(Path.Combine(ProjectDir.ProjectDirPath, "../Iskra.StdWeb/AutoGenerated"));

        await TypesGenerator.ExecuteAsync(typeof(IMarkerInterface).Assembly, targetDir);
    }
}