namespace Iskra.App;

public class SequenceEqualList<T> : List<T>
{
    public override bool Equals(object? obj)
    {
        if (base.Equals(obj))
        {
            return true;
        }

        if (obj is List<T> list)
        {
            return this.SequenceEqual(list);
        }

        return false;
    }

    // public override int GetHashCode()
    // {
    //     HashCode hash = new();
    //     foreach (T item in this)
    //     {
    //         hash.Add(item);
    //     }
    //
    //     return hash.ToHashCode();
    // }
}