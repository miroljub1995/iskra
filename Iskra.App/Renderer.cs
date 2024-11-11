using System.Runtime.InteropServices.JavaScript;
using Iskra.App.Elements;
using Iskra.StdWeb.Dom;

namespace Iskra.App;

public class Renderer(
    IServiceProvider provider
)
{
    public VirtualNode Render(VirtualNode? current, Element container, RenderNode node)
    {
        if (current is null)
        {
            return Mount(container, node);
        }
        else if (current is VirtualNodeComponent currentVirtualNodeComponent &&
                 node is RenderNodeComponent renderNodeComponent &&
                 currentVirtualNodeComponent.RenderNode.Key == renderNodeComponent.Key &&
                 currentVirtualNodeComponent.RenderNode != renderNodeComponent)
        {
            throw new("Props update on component still not supported.");
        }
        else if (current is VirtualNodeDomElement<HtmlDivElement, HtmlDivElementProps> currentVirtualNodeDivElement &&
                 node is RenderNodeElement<HtmlDivElement, HtmlDivElementProps> renderNodeDivElement &&
                 currentVirtualNodeDivElement.RenderNode.Key == renderNodeDivElement.Key &&
                 currentVirtualNodeDivElement.RenderNode != renderNodeDivElement)
        {
            if (renderNodeDivElement.Props.Class is { } className)
            {
                currentVirtualNodeDivElement.Element.ClassList.Value = className;
            }

            if (currentVirtualNodeDivElement.RenderNode.Props.ChildNodes != renderNodeDivElement.Props.ChildNodes)
            {
                if (currentVirtualNodeDivElement.RenderNode.Props.ChildNodes is not null &&
                    renderNodeDivElement.Props.ChildNodes is not null &&
                    currentVirtualNodeDivElement.RenderNode.Props.ChildNodes.Count ==
                    renderNodeDivElement.Props.ChildNodes.Count)
                {
                    for (int i = 0; i < currentVirtualNodeDivElement.ChildNodes.Count; i++)
                    {
                        currentVirtualNodeDivElement.ChildNodes[i] = Render(
                            currentVirtualNodeDivElement.ChildNodes[i],
                            currentVirtualNodeDivElement.Element,
                            renderNodeDivElement.Props.ChildNodes[i]
                        );
                    }
                }
                else
                {
                    throw new("Not supported.");
                }
            }

            currentVirtualNodeDivElement.RenderNode = renderNodeDivElement;
            return current;
        }
        else if (current is VirtualNodeDomText currentVirtualNodeText && node is RenderNodeText renderNodeText &&
                 currentVirtualNodeText.RenderNode != renderNodeText)
        {
            Text textNode = new Window(JSHost.GlobalThis)
                .Document
                .CreateTextNode(renderNodeText.Text);

            container.ReplaceChild(textNode, currentVirtualNodeText.Node);
            currentVirtualNodeText.Text = textNode;
            currentVirtualNodeText.RenderNode = renderNodeText;

            return currentVirtualNodeText;
        }
        // else if (_root.RenderNode.Key != node.Key || _root.RenderNode.GetType() != node.GetType())
        // {
        //     Replace(out _root, container, node);
        // }
        // else if (_root.RenderNode != node)
        // {
        //     Update(_root, node);
        // }
        else
        {
            return current;
        }
    }

    private VirtualNode Mount(Element container, RenderNode node)
    {
        if (node is RenderNodeText renderNodeText)
        {
            Text textNode = new Window(JSHost.GlobalThis)
                .Document
                .CreateTextNode(renderNodeText.Text);

            container.AppendChild(textNode);

            return new VirtualNodeDomText()
            {
                Text = textNode,
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

            return new VirtualNodeDomElement<HtmlDivElement, HtmlDivElementProps>()
            {
                Element = divElement,
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

    private Node? FindPreviousSiblingNode(VirtualNode virtualNode)
    {
        if (virtualNode is VirtualNodeDomNode virtualNodeDomNode)
        {
            return virtualNodeDomNode.Node.PreviousSibling;
        }
        else
        {
            throw new("Not supported.");
        }
    }
}