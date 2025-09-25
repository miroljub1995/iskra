using System.Text.Json;
using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public record GenSettings
{
    [JsonPropertyName("references")] public List<string> References { get; set; } = [];

    [JsonPropertyName("inputs")] public required List<string> Inputs { get; set; }

    [JsonPropertyName("output")] public required string Output { get; set; }

    [JsonPropertyName("namespace")] public required string Namespace { get; set; }

    [JsonPropertyName("proxyFactoryName")] public string? ProxyFactoryName { get; set; }

    public static async Task<GenSettings> ReadFromFileAsync(string gensettingsPath,
        CancellationToken cancellationToken = default)
    {
        var content = await File.ReadAllTextAsync(gensettingsPath, cancellationToken);

        if (JsonSerializer.Deserialize(content, typeof(GenSettings), WebIdlJsonContext.Default) is not GenSettings
            settings)
        {
            throw new Exception("GenSettings is null.");
        }

        var baseDir = Path.GetDirectoryName(gensettingsPath)
                      ?? throw new Exception("Base directory is null.");

        return settings with
        {
            References = settings.References.Select(path => Path.GetFullPath(path, baseDir)).ToList(),
            Inputs = settings.Inputs.Select(input => Path.GetFullPath(input, baseDir)).ToList(),
            Output = Path.GetFullPath(settings.Output, baseDir),
        };
    }
}