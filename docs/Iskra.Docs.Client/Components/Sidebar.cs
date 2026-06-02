using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Signals;

namespace Iskra.Docs.Client.Components;

public class SidebarProps { }

public class Sidebar : BaseComponent<SidebarProps, NoEvents, NoSlots, NoExpose>
{
    protected override IComponent[] Setup(out NoExpose exposed)
    {
        exposed = default;

        return
        [
            new Nav
            {
                Props = new NavProps
                {
                    Class = "hidden md:flex flex-col gap-1 w-56 shrink-0 border-r border-gray-200 px-4 py-6 bg-gray-50/50".ToConstSignal(),
                },
                Children =
                [
                    new NavItems
                    {
                        Props = new NavItemsProps
                        {
                            LinkClass = "px-3 py-2 rounded-lg text-sm font-medium text-gray-600 hover:text-gray-900 hover:bg-gray-100 transition-colors",
                            ActiveLinkClass = "px-3 py-2 rounded-lg text-sm font-medium text-indigo-600 bg-indigo-50 transition-colors",
                        },
                    },
                ],
            },
        ];
    }
}
