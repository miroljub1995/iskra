namespace Iskra.Core.HotReload;

public static class IskraHostBuilderHotReloadExtensions
{
    public static IskraHostBuilder UseDefaultHotReloadManager(this IskraHostBuilder builder)
    {
        // if (HotReloadManager.IsSupported)
        {
            builder.SetFeature<IHotReloadManager>(HotReloadManager.Default);
        }

        return builder;
    }
}
