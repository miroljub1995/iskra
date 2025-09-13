using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

/// <summary>
/// Base class for all WebIDL AST nodes.
/// Uses "type" as the JSON discriminator.
/// </summary>
public abstract class AbstractBase
{
    /// <summary>
    /// A list of extended attributes.
    /// </summary>
    [JsonPropertyName("extAttrs")]
    public required List<ExtendedAttribute> ExtAttrs { get; set; }
}