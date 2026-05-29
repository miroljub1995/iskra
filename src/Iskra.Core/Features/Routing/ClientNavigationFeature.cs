using System.Runtime.Versioning;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.Features.Routing;

/// <summary>
/// Client-side implementation of <see cref="INavigationFeature"/>.
/// Listens to the browser Navigation API's <c>currententrychange</c> event
/// and updates the reactive <see cref="CurrentPath"/> signal on each navigation.
/// </summary>
[SupportedOSPlatform("browser")]
public sealed class ClientNavigationFeature : INavigationFeature
{
    private readonly Signal<string> _currentPath;
    private readonly Navigation _navigation;

    public ClientNavigationFeature(Window window)
    {
        _navigation = window.Navigation;

        _currentPath = new Signal<string>(GetPath(_navigation));

        _navigation.AddEventListener("currententrychange", new EventListener((_) =>
        {
            _currentPath.Value = GetPath(_navigation);
        }));
    }

    public IReadOnlySignal<string> CurrentPath => _currentPath;

    public async Task NavigateAsync(string path) => await _navigation.Navigate(path).Finished;

    private static string GetPath(Navigation navigation)
    {
        var url = navigation.CurrentEntry?.Url;
        return url is not null ? new Uri(url).AbsolutePath : "/";
    }
}
