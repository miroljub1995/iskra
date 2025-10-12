namespace Iskra.WebIDLGenerator.Tests.Tests;

public class TestEnumPropertiesTest() : BaseTest<TestEnumProperties>("testEnumProperties")
{
    [Test]
    public async Task TestEnumProperty()
    {
        var sut = GetSut();

        await Assert.That(sut.Value).IsNotNull();

        await Assert.That(sut.Value).IsEqualTo(TestEnumPropertiesEnum.Enum_value_1);
        await Assert.That(sut.Value = TestEnumPropertiesEnum.Enum_value_3)
            .IsEqualTo(TestEnumPropertiesEnum.Enum_value_3);

        await Assert.That(sut.ValueNullable).IsEqualTo(TestEnumPropertiesEnum.Enum_value_2);
        await Assert.That(sut.ValueNullable = null).IsNull();

        await Assert.That(sut.ValueNullableReadonlyAsNotNull)
            .IsEqualTo(TestEnumPropertiesEnum.Enum_value_3);
        await Assert.That(sut.ValueNullableReadonlyAsNull).IsNull();
    }

    [Test]
    public async Task TestReadonlyEnumProperty()
    {
        var sut = GetSut();

        await Assert.That(PropertyIsReadOnly(nameof(TestEnumProperties.ValueNullableReadonlyAsNotNull))).IsTrue();
        await Assert.That(PropertyIsReadOnly(nameof(TestEnumProperties.ValueNullableReadonlyAsNull))).IsTrue();

        await Assert.That(sut.ValueNullableReadonlyAsNotNull)
            .IsEqualTo(TestEnumPropertiesEnum.Enum_value_3);
        await Assert.That(sut.ValueNullableReadonlyAsNull).IsNull();
    }

    [Test]
    public void TestInvalidEnumProperty()
    {
        var sut = GetSut();

        Assert.Throws(() => { _ = sut.ValueInvalid; });
    }
}