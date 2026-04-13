using Iskra.Core.Components;
using Iskra.Signals;

namespace Iskra.CoreExample.Components;

public class ParentComponentProps
{
}

public class ParentComponentExpose
{
}

public class ParentComponent : BaseComponent<ParentComponentProps, BaseEmits, ParentComponentExpose>
{
    protected override IComponent[] Setup(ParentComponentProps props, BaseEmits? events, out ParentComponentExpose exposed)
    {
        var firstName = new Signal<string>("Petar");
        var lastName = new Signal<string>("Petrov");

        exposed = new ParentComponentExpose();

        return
        [
            new ChildComponent
            {
                Props = new ChildComponentProps
                {
                    FirstName = firstName,
                    LastName = lastName,
                },
                Events = new ChildComponentEvents
                {
                    OnUpdateFirstName = value =>
                    {
                        Console.WriteLine($"FirstName updated: {value}");
                        firstName.Value = value;
                    },
                    OnUpdateLastName = value =>
                    {
                        Console.WriteLine($"LastName updated: {value}");
                        lastName.Value = value;
                    },
                },
            }
        ];
    }
}
