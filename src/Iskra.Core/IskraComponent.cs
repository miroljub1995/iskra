using Microsoft.Extensions.DependencyInjection;

namespace Iskra.Core;

public abstract class IskraComponent<TProps>(
    IKeyedServiceProvider provider
)
{
    public abstract ComponentInstance Setup(TProps props);
}