using Iskra.Signals;

namespace Iskra.Core.Features.Routing;

/// <summary>
/// Provides the current navigation path as a reactive signal.
/// Different implementations exist for SSR and client-side rendering.
/// </summary>
public interface INavigationFeature
{
    /// <summary>
    /// The current URL pathname (e.g. <c>/users/42</c>). Does not include
    /// query string or fragment.
    /// </summary>
    IReadOnlySignal<string> CurrentPath { get; }

    /// <summary>
    /// Navigates to the specified path.
    /// On the client, this performs a client-side navigation using the browser Navigation API.
    /// On the server, this records the path so the host can return a 302 redirect.
    /// </summary>
    Task PushAsync(string path);
}
