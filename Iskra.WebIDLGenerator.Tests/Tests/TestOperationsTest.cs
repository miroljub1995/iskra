namespace Iskra.WebIDLGenerator.Tests.Tests;

public class TestOperationsTest() : BaseTest<TestOperations>("testOperations")
{
    [Test]
    public async Task VoidOperation()
    {
        var sut = GetSut();

        // Should complete without throwing
        sut.VoidOperation();

        // If we got here, the operation succeeded
        await Task.CompletedTask;
    }

    [Test]
    public async Task BoolOperation()
    {
        var sut = GetSut();

        var result = sut.BoolOperation();

        await Assert.That(result).IsEqualTo(true);
    }

    [Test]
    public async Task LongOperation()
    {
        var sut = GetSut();

        var result = sut.LongOperation();

        await Assert.That(result).IsEqualTo(42);
    }

    [Test]
    public async Task StringOperation()
    {
        var sut = GetSut();

        var result = sut.StringOperation();

        await Assert.That(result).IsEqualTo("hello world");
    }

    [Test]
    public async Task AddNumbers()
    {
        var sut = GetSut();

        var result = sut.AddNumbers(10, 20);

        await Assert.That(result).IsEqualTo(30);
    }

    [Test]
    public async Task OptionalArgOperationWithDefaultArgument()
    {
        var sut = GetSut();

        var result = sut.OptionalArgOperation();

        await Assert.That(result).IsEqualTo("Message: default");
    }

    [Test]
    public async Task OptionalArgOperationWithArgument()
    {
        var sut = GetSut();

        var result = sut.OptionalArgOperation("custom");

        await Assert.That(result).IsEqualTo("Message: custom");
    }

    [Test]
    public async Task NullableReturnOperationReturnsNull()
    {
        var sut = GetSut();

        var result = sut.NullableReturnOperation(true);

        await Assert.That(result).IsEqualTo(null);
    }

    [Test]
    public async Task NullableReturnOperationReturnsValue()
    {
        var sut = GetSut();

        var result = sut.NullableReturnOperation(false);

        await Assert.That(result).IsEqualTo("not null");
    }

    [Test]
    public async Task PromiseOperation()
    {
        var sut = GetSut();

        var result = await sut.PromiseOperation(21);

        await Assert.That(result).IsEqualTo(42);
    }

    [Test]
    public async Task PromiseOperationWithZero()
    {
        var sut = GetSut();

        var result = await sut.PromiseOperation(0);

        await Assert.That(result).IsEqualTo(0);
    }

    [Test]
    public async Task VariadicOperationNoArguments()
    {
        var sut = GetSut();

        var result = sut.VariadicOperation();

        await Assert.That(result).IsEqualTo(0);
    }

    [Test]
    public async Task VariadicOperationOneArgument()
    {
        var sut = GetSut();

        var result = sut.VariadicOperation(5);

        await Assert.That(result).IsEqualTo(5);
    }

    [Test]
    public async Task VariadicOperationMultipleArguments()
    {
        var sut = GetSut();

        var result = sut.VariadicOperation(1, 2, 3, 4, 5);

        await Assert.That(result).IsEqualTo(15);
    }

    [Test]
    public async Task VariadicOperationManyArguments()
    {
        var sut = GetSut();

        int[] args = [10, 20, 30, 40, 50, 60];
        var result = sut.VariadicOperation(args);

        await Assert.That(result).IsEqualTo(210);
    }
}