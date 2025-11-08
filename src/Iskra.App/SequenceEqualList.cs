namespace Iskra.App;

public class SequenceEqualList<T> : List<T>
{
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj is List<T> list)
        {
            return this.SequenceEqual(list);
        }

        return false;
    }

    public override int GetHashCode()
    {
        HashCode hash = new();
        foreach (T item in this)
        {
            hash.Add(item);
        }

        return hash.ToHashCode();
    }

    public static bool operator ==(SequenceEqualList<T>? obj1, SequenceEqualList<T>? obj2)
        => obj1?.Equals(obj2) == true;

    public static bool operator !=(SequenceEqualList<T>? obj1, SequenceEqualList<T>? obj2)
        => !(obj1 == obj2);
}