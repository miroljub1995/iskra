using Iskra.Core.Features.Routing;
using Iskra.Signals;

namespace Iskra.Core.Client.Tests.TestUtils;

public sealed class FakeNavigationFeature : INavigationFeature
{
    private readonly Signal<string> _currentPath;

    public FakeNavigationFeature(string initialPath)
    {
        _currentPath = new Signal<string>(initialPath);
    }

    public IReadOnlySignal<string> CurrentPath => _currentPath;

    public Task NavigateAsync(string path)
    {
        _currentPath.Value = path;
        return Task.CompletedTask;
    }
}
