namespace Iskra.WebIDLGenerator.Models;

public class GenTypeDescriptor
{
    public required string Name { get; set; }
    public required string Namespace { get; set; }
    public required IDLRootType RootType { get; set; }
    public required bool IsMain { get; set; }
}