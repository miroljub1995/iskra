using Iskra.Core.Instances;

namespace Iskra.Core;

public record ClientComponent<TExpose>(
    TExpose Expose,
    Func<BaseInstance[]> Render
);