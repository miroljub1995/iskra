namespace Iskra.StdWebApi.Attributes;

public class AddToGlobalFactoryAttribute : Attribute
{
    public string? ConstructorName { get; set; }

    public static Type[] GetDeps(Type baseType)
    {
        return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.BaseType == baseType)
            .ToArray();
    }
}