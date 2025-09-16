namespace Iskra.WebIDLGenerator.Models;

public class GenTypeDescriptors
{
    private readonly List<GenTypeDescriptor> _genTypeDescriptors = [];

    public void Add(GenTypeDescriptor genTypeDescriptor)
    {
        if (_genTypeDescriptors.Any(x => x.Name == genTypeDescriptor.Name))
        {
            throw new Exception($"Type Descriptor with name \"{genTypeDescriptor.Name}\" already exists.");
        }

        _genTypeDescriptors.Add(genTypeDescriptor);
    }

    public GenTypeDescriptor? TryGet(string name) => _genTypeDescriptors.SingleOrDefault(x => x.Name == name);
}