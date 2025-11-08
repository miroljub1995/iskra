namespace Iskra.WebIDLGenerator.Tests.Tests;

public class TestNamespaceTest() : BaseTest<TestNamespace>("testNamespace")
{
    [Test]
    public async Task NamespaceProp()
    {
        var sut = GetSut();

        await Assert.That(sut.TestNS.NamespaceProp).IsEqualTo("namespace value");
    }

    [Test]
    public async Task VoidOperation()
    {
        var sut = GetSut();

        // Should complete without throwing
        sut.TestNS.VoidOperation();

        // If we got here, the operation succeeded
        await Task.CompletedTask;
    }

    [Test]
    public async Task LongOperation()
    {
        var sut = GetSut();

        var result = sut.TestNS.LongOperation();

        await Assert.That(result).IsEqualTo(42);
    }

    [Test]
    public async Task StringOperation()
    {
        var sut = GetSut();

        var result = sut.TestNS.StringOperation();

        await Assert.That(result).IsEqualTo("hello from namespace");
    }

    [Test]
    public async Task AddNumbers()
    {
        var sut = GetSut();

        var result = sut.TestNS.AddNumbers(15, 27);

        await Assert.That(result).IsEqualTo(42);
    }

    [Test]
    public async Task OptionalArgOperationWithDefaultArgument()
    {
        var sut = GetSut();

        var result = sut.TestNS.OptionalArgOperation();

        await Assert.That(result).IsEqualTo("Namespace Message: default namespace");
    }

    [Test]
    public async Task OptionalArgOperationWithArgument()
    {
        var sut = GetSut();

        var result = sut.TestNS.OptionalArgOperation("custom namespace");

        await Assert.That(result).IsEqualTo("Namespace Message: custom namespace");
    }
}
