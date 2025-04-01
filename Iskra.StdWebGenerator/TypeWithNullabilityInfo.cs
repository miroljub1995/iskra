using System.Reflection;

namespace Iskra.StdWebGenerator;

public record TypeWithNullabilityInfo(
    Type Type,
    NullabilityInfo NullabilityInfo,
    bool IsFromReadState
);