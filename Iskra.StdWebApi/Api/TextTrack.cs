using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class TextTrack : EventTarget
{
    protected TextTrack() => throw new();
}