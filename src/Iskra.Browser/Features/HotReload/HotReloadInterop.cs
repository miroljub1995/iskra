using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using System.Text.Json;
using Iskra.Core.HotReload;

namespace Iskra.Browser.Features.HotReload;

[SupportedOSPlatform("browser")]
internal static partial class HotReloadInterop
{
    private static Dictionary<(Guid ModuleId, int Token), Type>? _typeCache;

    [JSExport]
    [UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "Only used during hot reload with the interpreter; no trimming occurs.")]
    public static void BeforeUpdate(string deltasJson)
    {
        try
        {
            Console.WriteLine("[Iskra] BeforeUpdate...");
            var sw = System.Diagnostics.Stopwatch.StartNew();

            EnsureTypeCache();
            var types = ResolveUpdatedTypes(deltasJson);
            HotReloadManager.Default.FireBeforeUpdate(types);

            Console.WriteLine($"[Iskra] BeforeUpdate done in {sw.ElapsedMilliseconds} ms.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"[Iskra] BeforeUpdate failed: {ex}");
        }
    }

    [UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "Only used during hot reload with the interpreter; no trimming occurs.")]
    private static void EnsureTypeCache()
    {
        if (_typeCache is not null)
            return;

        _typeCache = new();
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            try
            {
                var module = assembly.ManifestModule;
                var mvid = module.ModuleVersionId;
                foreach (var type in assembly.GetTypes())
                {
                    _typeCache[(mvid, type.MetadataToken)] = type;
                }
            }
            catch
            {
                // Some assemblies may not support reflection
            }
        }
    }

    private static Type[]? ResolveUpdatedTypes(string deltasJson)
    {
        using var doc = JsonDocument.Parse(deltasJson);
        var result = new List<Type>();

        foreach (var delta in doc.RootElement.EnumerateArray())
        {
            if (!delta.TryGetProperty("updatedTypes", out var updatedTypes))
                continue;

            var moduleIdStr = delta.GetProperty("moduleId").GetString();
            if (moduleIdStr is null || !Guid.TryParse(moduleIdStr, out var moduleId))
                continue;

            foreach (var token in updatedTypes.EnumerateArray())
            {
                if (_typeCache!.TryGetValue((moduleId, token.GetInt32()), out var type))
                {
                    result.Add(type);
                }
            }
        }

        return result.Count > 0 ? result.ToArray() : null;
    }
}
