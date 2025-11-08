using Iskra.WebIDLGenerator.Models;

namespace Iskra.WebIDLGenerator.Utils;

public class IDLTypeDescriptionEqualityComparer : IEqualityComparer<IDLTypeDescription>
{
    public static readonly IDLTypeDescriptionEqualityComparer Instance = new();

    public bool Equals(IDLTypeDescription? x, IDLTypeDescription? y)
    {
        if (ReferenceEquals(x, y))
        {
            return true;
        }

        if (x is null || y is null)
        {
            return false;
        }

        if (x.Nullable != y.Nullable)
        {
            return false;
        }

        // if (a.ExtAttrs.Count != b.ExtAttrs.Count)
        // {
        //     return false;
        // }
        //
        // for (var i = 0; i < a.ExtAttrs.Count; i++)
        // {
        //     if (!Equals(a.ExtAttrs[i], b.ExtAttrs[i]))
        //     {
        //         return false;
        //     }
        // }

        if (x is UnionTypeDescription unionA && y is UnionTypeDescription unionB)
        {
            return Equals(unionA.IdlType, unionB.IdlType);
        }

        if (x is SingleTypeDescription singleA && y is SingleTypeDescription singleB)
        {
            var typeA = singleA.IdlType switch
            {
                BuiltinTypes.UnrestrictedDouble => BuiltinTypes.Double,
                BuiltinTypes.UnrestrictedFloat => BuiltinTypes.Float,
                _ => singleA.IdlType
            };

            var typeB = singleB.IdlType switch
            {
                BuiltinTypes.UnrestrictedDouble => BuiltinTypes.Double,
                BuiltinTypes.UnrestrictedFloat => BuiltinTypes.Float,
                _ => singleB.IdlType
            };

            return typeA == typeB;
        }

        if (x is FrozenArrayTypeDescription frozenA && y is FrozenArrayTypeDescription frozenB)
        {
            return Equals(frozenA.IdlType, frozenB.IdlType);
        }

        if (x is ObservableArrayTypeDescription observableA && y is ObservableArrayTypeDescription observableB)
        {
            return Equals(observableA.IdlType, observableB.IdlType);
        }

        if (x is PromiseTypeDescription promiseA && y is PromiseTypeDescription promiseB)
        {
            return Equals(promiseA.IdlType, promiseB.IdlType);
        }

        if (x is RecordTypeDescription recordA && y is RecordTypeDescription recordB)
        {
            return Equals(recordA.IdlType, recordB.IdlType);
        }

        if (x is SequenceTypeDescription sequenceA && y is SequenceTypeDescription sequenceB)
        {
            return Equals(sequenceA.IdlType, sequenceB.IdlType);
        }

        return false;
    }

    public int GetHashCode(IDLTypeDescription obj)
    {
        var hash = new HashCode();
        hash.Add(obj.Nullable);

        switch (obj)
        {
            case UnionTypeDescription union:
                hash.Add(union.IdlType.Count);
                foreach (var item in union.IdlType)
                {
                    hash.Add(GetHashCode(item));
                }

                break;

            case SingleTypeDescription single:
                var normalizedType = single.IdlType switch
                {
                    BuiltinTypes.UnrestrictedDouble => BuiltinTypes.Double,
                    BuiltinTypes.UnrestrictedFloat => BuiltinTypes.Float,
                    _ => single.IdlType
                };
                hash.Add(normalizedType);
                break;

            case FrozenArrayTypeDescription frozen:
                hash.Add(nameof(FrozenArrayTypeDescription));
                hash.Add(frozen.IdlType.Count);
                foreach (var item in frozen.IdlType)
                {
                    hash.Add(GetHashCode(item));
                }

                break;

            case ObservableArrayTypeDescription observable:
                hash.Add(nameof(ObservableArrayTypeDescription));
                hash.Add(observable.IdlType.Count);
                foreach (var item in observable.IdlType)
                {
                    hash.Add(GetHashCode(item));
                }

                break;

            case PromiseTypeDescription promise:
                hash.Add(nameof(PromiseTypeDescription));
                hash.Add(promise.IdlType.Count);
                foreach (var item in promise.IdlType)
                {
                    hash.Add(GetHashCode(item));
                }

                break;

            case RecordTypeDescription record:
                hash.Add(nameof(RecordTypeDescription));
                hash.Add(record.IdlType.Count);
                foreach (var item in record.IdlType)
                {
                    hash.Add(GetHashCode(item));
                }

                break;

            case SequenceTypeDescription sequence:
                hash.Add(nameof(SequenceTypeDescription));
                hash.Add(sequence.IdlType.Count);
                foreach (var item in sequence.IdlType)
                {
                    hash.Add(GetHashCode(item));
                }

                break;
        }

        return hash.ToHashCode();
    }


    private bool Equals(List<IDLTypeDescription> a, List<IDLTypeDescription> b)
    {
        if (a.Count != b.Count)
        {
            return false;
        }

        for (var i = 0; i < a.Count; i++)
        {
            if (!Equals(a[i], b[i]))
            {
                return false;
            }
        }

        return true;
    }
}