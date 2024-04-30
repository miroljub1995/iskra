using System.Runtime.InteropServices.JavaScript;
using Iskra.App.Elements;
using Iskra.StdWeb.Dom;

namespace Iskra.App;

public class Renderer
{
    private VirtualNode? _root;

    public void Render(Element container, RenderNode node)
    {
        if (_root is null)
        {
            Mount(out _root, container, node);
        }
        // else if (_root.RenderNode.Key != node.Key || _root.RenderNode.GetType() != node.GetType())
        // {
        //     Unmount(ref _root);
        //     Mount(out _root, container, node);
        // }
        // else if (_root.RenderNode != node)
        // {
        //     Patch(_root, node);
        // }
    }

    private void Mount(out VirtualNode vnode, Element container, RenderNode node)
    {
        if (node is RenderNodeText renderNodeText)
        {
            Text textNode = new Window(JSHost.GlobalThis)
                .Document
                .CreateTextNode(renderNodeText.Text);

            vnode = new VirtualNodeText()
            {
                ContainerNode = container,
                RenderNode = renderNodeText,
            };

            container.AppendChild(textNode);
        }
        else if (node is RenderNodeElement<HtmlDivElement, HtmlDivElementProps> renderNodeDivElement)
        {
            HtmlDivElement divElement = new Window(JSHost.GlobalThis)
                .Document
                .CreateElement<HtmlDivElement>();

            if (renderNodeDivElement.Props.Class is { } className)
            {
                divElement.ClassList.Value = className;
            }

            SequenceEqualList<RenderNode> propsChildNodes = renderNodeDivElement.Props.ChildNodes ?? [];
            List<VirtualNode> childNodes = new(propsChildNodes.Count);

            vnode = new VirtualNodeElement<HtmlDivElement, HtmlDivElementProps>()
            {
                ContainerNode = container,
                RenderNode = renderNodeDivElement,
                ChildNodes = childNodes,
            };

            foreach (RenderNode propsChildNode in propsChildNodes)
            {
                Mount(out VirtualNode childRoot, divElement, propsChildNode);
                childNodes.Add(childRoot);
            }

            container.AppendChild(divElement);
        }
        else
        {
            throw new("Not supported.");
        }
    }

    private void Unmount(ref VirtualNode node)
    {
        throw new();
    }

    private void Patch(VirtualNode vnode, RenderNode node)
    {
        throw new();
    }
}