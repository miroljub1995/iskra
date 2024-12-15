using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
public class Node : EventTarget
{
    private Node() => throw new();
}