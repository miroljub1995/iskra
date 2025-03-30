using System.Reflection;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public record MyType(
    Type Type,
    bool IsNullable,
    MyType? ElementType,
    MyType[] GenericTypeArguments
)
{
    public static MyType From(PropertyInfo propertyInfo)
    {
        var nullabilityInfo = new NullabilityInfoContext().Create(propertyInfo);
        return From(propertyInfo.PropertyType, nullabilityInfo, propertyInfo.CanRead);
    }

    public static MyType From(ParameterInfo parameterInfo)
    {
        var nullabilityInfo = new NullabilityInfoContext().Create(parameterInfo);
        return From(parameterInfo.ParameterType, nullabilityInfo, true);
    }

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
        var hash = new HashCode();
        hash.Add(Type);
        hash.Add(IsNullable);
        hash.Add(ElementType);

        foreach (var arg in GenericTypeArguments)
        {
            hash.Add(arg);
        }

        return hash.ToHashCode();
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

        return Type == other.Type
               && IsNullable == other.IsNullable
               && ElementType == other.ElementType
               && GenericTypeArguments.SequenceEqual(other.GenericTypeArguments);
    }
}