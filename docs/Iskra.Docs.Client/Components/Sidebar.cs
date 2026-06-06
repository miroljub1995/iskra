using Iskra.Core.Components;
using Iskra.Dom.Components;
using Iskra.Signals;

namespace Iskra.Docs.Client.Components;

public class Sidebar : BaseComponent<NoProps, NoEvents, NoSlots, NoExpose>
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
                    Class = "hidden md:flex flex-col gap-1 w-56 shrink-0 border-r border-gray-200 dark:border-gray-700 px-4 py-6 bg-gray-50/50 dark:bg-gray-900/50".ToConstSignal(),
                },
                Children =
                [
                    new NavItems
                    {
                        Props = new NavItemsProps
                        {
                            LinkClass = "px-3 py-2 rounded-lg text-sm font-medium text-gray-600 dark:text-gray-400 hover:text-gray-900 dark:hover:text-white hover:bg-gray-100 dark:hover:bg-gray-800 transition-colors",
                            ActiveLinkClass = "px-3 py-2 rounded-lg text-sm font-medium text-indigo-600 dark:text-indigo-400 bg-indigo-50 dark:bg-indigo-950 transition-colors",
                        },
                    },
                ],
            },
        ];
    }
}
