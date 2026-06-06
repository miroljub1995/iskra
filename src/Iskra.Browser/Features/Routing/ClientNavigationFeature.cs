using System.Runtime.Versioning;
using Iskra.Core.Features.Routing;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Browser.Features.Routing;

/// <summary>
/// Client-side implementation of <see cref="INavigationFeature"/>.
/// Uses <c>history.pushState</c> for navigation and listens to <c>popstate</c>
/// to handle back/forward browser buttons.
/// </summary>
[SupportedOSPlatform("browser")]
public sealed class ClientNavigationFeature : INavigationFeature
{
    private readonly Signal<string> _currentPath;
    private readonly Window _window;

    public ClientNavigationFeature(Window window)
    {
        _window = window;

        _currentPath = new Signal<string>(window.Location.Pathname);

        window.AddEventListener("popstate", new EventListener((_) =>
        {
            _currentPath.Value = _window.Location.Pathname;
        }));
    }

    public IReadOnlySignal<string> CurrentPath => _currentPath;

    public Task PushAsync(string path)
    {
        if (_currentPath.Value == path)
            return Task.CompletedTask;

        _window.History.PushState(null, "", path);
        _currentPath.Value = path;
        return Task.CompletedTask;
    }
}
