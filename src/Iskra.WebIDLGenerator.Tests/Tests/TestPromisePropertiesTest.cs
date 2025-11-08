namespace Iskra.WebIDLGenerator.Tests.Tests;

public class TestPromisePropertiesTest() : BaseTest<TestPromiseProperties>("testPromiseProperties")
{
    [Test]
    public async Task TestPromisePropertyLong()
    {
        var sut = GetSut();

        var result = await sut.PromisePropertyLong;
        await Assert.That(result).IsEqualTo(42);

        sut.PromisePropertyLong = Task.FromResult(100);
        var newResult = await sut.PromisePropertyLong;
        await Assert.That(newResult).IsEqualTo(100);
    }

    [Test]
    public async Task TestPromisePropertyLongReadOnly()
    {
        var sut = GetSut();

        var result = await sut.PromisePropertyLongReadOnly;
        await Assert.That(result).IsEqualTo(84);
        await Assert.That(PropertyIsReadOnly(nameof(TestPromiseProperties.PromisePropertyLongReadOnly))).IsTrue();
    }

    [Test]
    public async Task TestPromisePropertyLongNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.PromisePropertyLongNullable).IsEqualTo(null);

        sut.PromisePropertyLongNullable = Task.FromResult(50);
        var result = await sut.PromisePropertyLongNullable!;
        await Assert.That(result).IsEqualTo(50);
    }

    [Test]
    public async Task TestPromisePropertyLongReadOnlyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.PromisePropertyLongReadOnlyNullableAsNull).IsEqualTo(null);

        var result = await sut.PromisePropertyLongReadOnlyNullableAsNotNull!;
        await Assert.That(result).IsEqualTo(126);
    }

    [Test]
    public async Task TestPromisePropertyString()
    {
        var sut = GetSut();

        var result = await sut.PromisePropertyString;
        await Assert.That(result).IsEqualTo("hello");

        sut.PromisePropertyString = Task.FromResult("test");
        var newResult = await sut.PromisePropertyString;
        await Assert.That(newResult).IsEqualTo("test");
    }

    [Test]
    public async Task TestPromisePropertyStringReadOnly()
    {
        var sut = GetSut();

        var result = await sut.PromisePropertyStringReadOnly;
        await Assert.That(result).IsEqualTo("world");
        await Assert.That(PropertyIsReadOnly(nameof(TestPromiseProperties.PromisePropertyStringReadOnly))).IsTrue();
    }

    [Test]
    public async Task TestPromisePropertyLongDelayed()
    {
        var sut = GetSut();

        var promiseTask = (Task<int>)sut.PromisePropertyLongDelayed;
        await Assert.That(promiseTask.IsCompleted).IsFalse();

        var timeoutTask = Task.Delay(2000);
        var completedTask = await Task.WhenAny(promiseTask, timeoutTask);

        await Assert.That(ReferenceEquals(completedTask, promiseTask)).IsTrue();

        var result = await promiseTask;
        await Assert.That(result).IsEqualTo(99);
    }

    [Test]
    public async Task TestTaskToPromiseSetterWithContinueWith()
    {
        var sut = GetSut();

        await Assert.That(sut.TestTaskToPromiseValue).IsNull();
        sut.TestTaskToPromise = Task.Delay(1000).ContinueWith(_ => 17);
        await Task.Delay(1100);

        await Assert.That(sut.TestTaskToPromiseValue).IsEqualTo(17);
    }
}