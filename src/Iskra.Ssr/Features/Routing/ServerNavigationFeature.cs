using Iskra.Core.Features.Routing;
using Iskra.Signals;

namespace Iskra.Ssr.Features.Routing;

/// <summary>
/// SSR implementation of <see cref="INavigationFeature"/>.
/// The path is constant for the lifetime of the request.
/// When <see cref="PushAsync"/> is called, the redirect location is stored
/// in <see cref="RedirectLocation"/> so the server middleware can return a 302 response.
/// </summary>
public sealed class ServerNavigationFeature : INavigationFeature
{
    public ServerNavigationFeature(string path)
    {
        CurrentPath = new Signal<string>(path);
    }

    public IReadOnlySignal<string> CurrentPath { get; }

    /// <summary>
    /// The path passed to <see cref="PushAsync"/>, or <c>null</c> if no
    /// navigation was requested. The server middleware should check this
    /// after rendering and return a 302 redirect when set.
    /// </summary>
    public string? RedirectLocation { get; private set; }

    public Task PushAsync(string path)
    {
        RedirectLocation = path;
        return Task.CompletedTask;
    }
}
