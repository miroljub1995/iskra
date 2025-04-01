namespace Iskra.StdWebGenerator;

public record JSObjectMethodCallInfo(
    string Name,
    IReadOnlyList<MyType> Parameters,
    MyType? ReturnParam
)
{
    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public virtual bool Equals(JSObjectMethodCallInfo? other)
    {
        if (other is null)
        {
            return false;
        }

        return Name == other.Name
               && Parameters.SequenceEqual(other.Parameters)
               && ReturnParam == other.ReturnParam;
    }
}