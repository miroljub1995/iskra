using Iskra.StdWebGenerator.Marshalling.Concrete;

namespace Iskra.StdWebGenerator.Marshalling;

public class Marshallers
{
    private readonly List<Marshaller> _marshallers = [];

    private static readonly Lazy<Marshallers> LazyInstance = new(() =>
    {
        var list = new Marshallers();

        list.Add(new MarshallerJSObjectToArray());
        list.Add(new MarshallerJSObjectToIReadOnlyList());
        list.Add(new MarshallerJSObjectToOneOf());
        list.Add(new MarshallerToWrapperObject());
        list.Add(new MarshallerNoOp());
        list.Add(new MarshallerNullable());

        return list;
    });

    public static Marshallers Instance => LazyInstance.Value;

    public void Add(Marshaller marshaller) => _marshallers.Add(marshaller);

    public Marshaller GetNext(MyType type, MyType destination)
    {
        var marshallers = _marshallers
            .Where(x => x.CanMarshall(type, destination))
            .ToList();

        if (marshallers.Count == 0)
        {
            throw new($"No marshaller found for type {type} for destination {destination}.");
        }

        if (marshallers.Count > 1)
        {
            string marshallerNames = string.Join(", ", marshallers.Select(x => x.GetType().Name));

            throw new(
                $"Multiple marshallers found for type {type} for destination {destination}. Found {marshallerNames} marshaller.");
        }

        return marshallers[0];
    }
}