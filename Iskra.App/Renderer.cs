using System.Runtime.InteropServices.JavaScript;
using Iskra.App.Elements;
using Iskra.StdWeb.Dom;
using Microsoft.Extensions.DependencyInjection;

namespace Iskra.App;

public class Renderer(
    IServiceProvider provider
)
{
    private VirtualNode? _root;

    public void Render(Element container, RenderNode node)
    {
        if (_root is null)
        {
            _root = Mount(container, node);
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

    private VirtualNode Mount(Element container, RenderNode node)
    {
        if (node is RenderNodeText renderNodeText)
        {
            Text textNode = new Window(JSHost.GlobalThis)
                .Document
                .CreateTextNode(renderNodeText.Text);

            container.AppendChild(textNode);

            return new VirtualNodeText()
            {
                ContainerNode = container,
                RenderNode = renderNodeText,
            };
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

            foreach (RenderNode propsChildNode in propsChildNodes)
            {
                VirtualNode childRoot = Mount(divElement, propsChildNode);
                childNodes.Add(childRoot);
            }

            container.AppendChild(divElement);

            return new VirtualNodeElement<HtmlDivElement, HtmlDivElementProps>()
            {
                ContainerNode = container,
                RenderNode = renderNodeDivElement,
                ChildNodes = childNodes,
            };
        }
        else if (node is RenderNodeComponent nodeComponent)
        {
            IIskraComponentLife componentLife = nodeComponent.GetIskraComponentLife(provider);
            componentLife.Start(container, nodeComponent.PropsObject);

            return new VirtualNodeComponent
            {
                ContainerNode = container,
                RenderNode = nodeComponent,
                ComponentLife = componentLife,
            };
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