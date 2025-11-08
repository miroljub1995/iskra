using Iskra.Core;
using Iskra.Reactivity;
using Iskra.StdWeb;
using Microsoft.Extensions.DependencyInjection;

namespace Iskra.CoreExample.Components;

public record HelloWorldProps();

public sealed class HelloWorld(
    IKeyedServiceProvider provider
) : IskraComponent<HelloWorldProps>(provider)
{
    // public static IskraComponent<HelloWorldProps> Setup(IKeyedServiceProvider provider, HelloWorldProps props)
    // {
    //     Ref<int> counter = 0.ToRef();
    //     {
    //     }
    //
    //     {
    //         // Render
    //     }
    //
    //     void OnClick(Event e)
    //     {
    //     }
    //
    //     return new HelloWorld()
    //     {
    //     };
    // }

    public override ComponentInstance Setup(HelloWorldProps props)
    {
        Ref<int> counter = 0.ToRef();

        {
            // Render steps

            // Before mount
            DomAnchor anchor = provider.GetRequiredService<DomAnchor>();
            // Mount to anchor
            // Mounted
        }

        return new ComponentInstance(
            Unmount: () => { }
        );

        void OnClick(Event e)
        {
            counter.Value++;
        }
    }
}