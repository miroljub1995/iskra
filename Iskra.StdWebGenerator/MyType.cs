using System.Reflection;

namespace Iskra.StdWebGenerator;

public record MyType(
    Type Type,
    bool IsNullable,
    MyType? ElementType,
    MyType[] GenericTypeArguments
)
{
    public static MyType From(Type type, NullabilityInfo nullabilityInfo, bool isFromReadState)
    {
        var nullabilityState = isFromReadState ? nullabilityInfo.ReadState : nullabilityInfo.WriteState;
        var isNullable = nullabilityState == NullabilityState.Nullable;

        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            type = type.GetGenericArguments()[0];
        }

        MyType? elementType;
        if (type.IsArray && type.GetElementType() is { } eType && nullabilityInfo.ElementType is { } nie)
        {
            elementType = From(eType, nie, true);
        }
        else
        {
            elementType = null;
        }

        MyType[] genericTypeArguments;
        if (type.IsGenericType)
        {
            genericTypeArguments = type
                .GetGenericArguments()
                .Select((x, i) => From(x, nullabilityInfo.GenericTypeArguments[i], true))
                .ToArray();
        }
        else
        {
            genericTypeArguments = [];
        }

        return new MyType(
            Type: type,
            IsNullable: isNullable,
            ElementType: elementType,
            GenericTypeArguments: genericTypeArguments
        );
    }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public virtual bool Equals(MyType? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        bool isElementTypeEqual = ElementType is null && other.ElementType is null ||
                                  ElementType?.Equals(other.ElementType) == true;

        bool isGenericTypeArgumentsEqual = GenericTypeArguments.Length == other.GenericTypeArguments.Length &&
                                           GenericTypeArguments.Select(
                                                   (x, i) => x.Equals(other.GenericTypeArguments[i]))
                                               .All(x => x);

        return Type == other.Type && IsNullable == other.IsNullable && isElementTypeEqual &&
               isGenericTypeArgumentsEqual;
    }
}