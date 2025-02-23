namespace Iskra.StdWebApi.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class IndexerAliasMethods : Attribute
{
    public string Get { get; set; } = string.Empty;
    public string Set { get; set; } = string.Empty;
}