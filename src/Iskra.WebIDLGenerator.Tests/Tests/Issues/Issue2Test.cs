namespace Iskra.WebIDLGenerator.Tests.Tests.Issues;

/// <summary>
/// Tests for Issue #2: Subclass instances not recognized by JSObjectProxyFactory
/// </summary>
/// <seealso href="https://github.com/miroljub1995/iskra/issues/2"/>
public class Issue2Test() : BaseTest<Issue2>("issue2")
{
    [Test]
    public async Task Issue2InstanceHasCorrectValue()
    {
        var sut = GetSut();
        await Assert.That(sut.Value).IsEqualTo(42);
    }
}
