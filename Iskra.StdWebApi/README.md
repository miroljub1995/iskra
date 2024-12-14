## Example of defining interface

```cs
[GenerateBindings]
public class TestClass
{
    public TestClass() => throw new();

    public string TestProp
    {
        get => throw new();
        set => throw new();
    }

    public string TestMethod(int arg) => throw new();

    public static int TestStaticMethod(int arg) => throw new();
}
```
