namespace Iskra.Core.Sfc;

public static class SfcClientComponentFactory
{
    public static ClientComponent<TExpose> SetupClientComponent<TComponent, TPropsInit, TProps, TExpose, TFallthrough>(
        TPropsInit props, TFallthrough fallthrough)
        where TComponent : ISfcClientComponent<TComponent, TPropsInit, TProps, TExpose, TFallthrough>
        where TProps : ISetupProps<TPropsInit, TProps>
    {
        var propsForComponent = TProps.Init(props);

        var render = TComponent.SetupClient(propsForComponent, fallthrough, out var expose);

        return new ClientComponent<TExpose>(
            Expose: expose,
            Render: render
        );
    }
}