using Iskra.JSCore;

namespace Iskra.WebIDLGenerator.Tests.Tests;

public class TestPropertiesTest() : BaseTest<TestProperties>("testProperties")
{
    [Before(Class)]
    public static async Task Before()
    {
        await JSCoreShims.InitializeAsync();
        JSCoreProxyFactory.Initialize();
        WebIDLGeneratorTestsProxyFactory.Initialize();
    }

    // Bool
    [Test]
    public async Task TestBoolPropertyGet()
    {
        var sut = GetSut();

        await Assert.That(sut.BoolProperty).IsEqualTo(true);
        await Assert.That(sut.BoolProperty = false).IsEqualTo(false);
    }

    [Test]
    public async Task TestReadOnlyBoolProperty()
    {
        var sut = GetSut();

        await Assert.That(sut.BoolPropertyReadOnly).IsEqualTo(true);
        await Assert.That(PropertyIsReadOnly(nameof(TestProperties.BoolPropertyReadOnly))).IsTrue();
    }

    [Test]
    public async Task BoolPropertyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.BoolPropertyNullable).IsEqualTo(null);
        await Assert.That(sut.BoolPropertyNullable = true).IsEqualTo(true);
        await Assert.That(sut.BoolPropertyNullable = false).IsEqualTo(false);
    }

    [Test]
    public async Task BoolPropertyReadOnlyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.BoolPropertyReadOnlyNullableAsNull).IsEqualTo(null);
        await Assert.That(sut.BoolPropertyReadOnlyNullableAsTrue).IsEqualTo(true);
        await Assert.That(sut.BoolPropertyReadOnlyNullableAsFalse).IsEqualTo(false);
    }

    // Byte
    [Test]
    public async Task TestByteProperty()
    {
        var sut = GetSut();

        await Assert.That(sut.ByteProperty).IsEqualTo((byte)1);
        await Assert.That(sut.ByteProperty = 3).IsEqualTo<byte>(3);
    }

    [Test]
    public async Task TestReadOnlyByteProperty()
    {
        var sut = GetSut();

        await Assert.That(sut.BytePropertyReadOnly).IsEqualTo<byte>(2);
        await Assert.That(PropertyIsReadOnly(nameof(TestProperties.BytePropertyReadOnly))).IsTrue();
    }

    [Test]
    public async Task TestBytePropertyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.BytePropertyNullable).IsEqualTo(null);
        await Assert.That(sut.BytePropertyNullable = 1).IsEqualTo<byte?>(1);
    }

    [Test]
    public async Task TestBytePropertyReadOnlyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.BytePropertyReadOnlyNullableAsNull).IsEqualTo(null);
        await Assert.That(sut.BytePropertyReadOnlyNullableAsNotNull).IsEqualTo<byte?>(3);
    }

    // SignedByte
    [Test]
    public async Task TestSignedByteProperty()
    {
        var sut = GetSut();

        await Assert.That(sut.SignedByteProperty).IsEqualTo<sbyte>(1);
        await Assert.That(sut.SignedByteProperty = 3).IsEqualTo<sbyte>(3);
    }

    [Test]
    public async Task TestReadOnlySignedByteProperty()
    {
        var sut = GetSut();

        await Assert.That(sut.SignedBytePropertyReadOnly).IsEqualTo<sbyte>(2);
        await Assert.That(PropertyIsReadOnly(nameof(TestProperties.SignedBytePropertyReadOnly))).IsTrue();
    }

    [Test]
    public async Task TestSignedBytePropertyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.SignedBytePropertyNullable).IsEqualTo(null);
        await Assert.That(sut.SignedBytePropertyNullable = 1).IsEqualTo<sbyte?>(1);
        await Assert.That(sut.SignedBytePropertyNullable = -1).IsEqualTo<sbyte?>(-1);
    }

    [Test]
    public async Task TestSignedBytePropertyReadOnlyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.SignedBytePropertyReadOnlyNullableAsNull).IsEqualTo(null);
        await Assert.That(sut.SignedBytePropertyReadOnlyNullableAsNotNull).IsEqualTo<sbyte?>(3);
    }

    // Short
    [Test]
    public async Task TestShortProperty()
    {
        var sut = GetSut();

        await Assert.That(sut.ShortProperty).IsEqualTo<short>(1);
        await Assert.That(sut.ShortProperty = 3).IsEqualTo<short>(3);
    }

    [Test]
    public async Task TestReadOnlyShortProperty()
    {
        var sut = GetSut();

        await Assert.That(sut.ShortPropertyReadOnly).IsEqualTo<short>(2);
        await Assert.That(PropertyIsReadOnly(nameof(TestProperties.ShortPropertyReadOnly))).IsTrue();
    }

    [Test]
    public async Task TestShortPropertyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.ShortPropertyNullable).IsEqualTo(null);
        await Assert.That(sut.ShortPropertyNullable = 1).IsEqualTo<short?>(1);
        await Assert.That(sut.ShortPropertyNullable = -1).IsEqualTo<short?>(-1);
    }

    [Test]
    public async Task TestShortPropertyReadOnlyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.ShortPropertyReadOnlyNullableAsNull).IsEqualTo(null);
        await Assert.That(sut.ShortPropertyReadOnlyNullableAsNotNull).IsEqualTo<short?>(3);
    }

    // UnsignedShort
    [Test]
    public async Task TestUnsignedShortProperty()
    {
        var sut = GetSut();

        await Assert.That(sut.UnsignedShortProperty).IsEqualTo<ushort>(1);
        await Assert.That(sut.UnsignedShortProperty = 3).IsEqualTo<ushort>(3);
    }

    [Test]
    public async Task TestReadOnlyUnsignedShortProperty()
    {
        var sut = GetSut();

        await Assert.That(sut.UnsignedShortPropertyReadOnly).IsEqualTo<ushort>(2);
        await Assert.That(PropertyIsReadOnly(nameof(TestProperties.UnsignedShortPropertyReadOnly))).IsTrue();
    }

    [Test]
    public async Task TestUnsignedShortPropertyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.UnsignedShortPropertyNullable).IsEqualTo(null);
        await Assert.That(sut.UnsignedShortPropertyNullable = 1).IsEqualTo<ushort?>(1);
    }

    [Test]
    public async Task TestUnsignedShortPropertyReadOnlyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.UnsignedShortPropertyReadOnlyNullableAsNull).IsEqualTo(null);
        await Assert.That(sut.UnsignedShortPropertyReadOnlyNullableAsNotNull).IsEqualTo<ushort?>(3);
    }

    // Int32
    [Test]
    public async Task TestInt32Property()
    {
        var sut = GetSut();

        await Assert.That(sut.Int32Property).IsEqualTo(1);
        await Assert.That(sut.Int32Property = 3).IsEqualTo(3);
        await Assert.That(sut.Int32Property = -3).IsEqualTo(-3);
    }

    [Test]
    public async Task TestReadOnlyInt32Property()
    {
        var sut = GetSut();

        await Assert.That(sut.Int32PropertyReadOnly).IsEqualTo(2);
        await Assert.That(PropertyIsReadOnly(nameof(TestProperties.Int32PropertyReadOnly))).IsTrue();
    }

    [Test]
    public async Task TestInt32PropertyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.Int32PropertyNullable).IsEqualTo(null);
        await Assert.That(sut.Int32PropertyNullable = 1).IsEqualTo(1);
        await Assert.That(sut.Int32PropertyNullable = -1).IsEqualTo(-1);
    }

    [Test]
    public async Task TestInt32PropertyReadOnlyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.Int32PropertyReadOnlyNullableAsNull).IsEqualTo(null);
        await Assert.That(sut.Int32PropertyReadOnlyNullableAsNotNull).IsEqualTo(3);
    }

    // UnsignedInt32
    [Test]
    public async Task TestUnsignedInt32Property()
    {
        var sut = GetSut();

        await Assert.That(sut.UnsignedInt32Property).IsEqualTo<uint>(1);
        await Assert.That(sut.UnsignedInt32Property = 3).IsEqualTo<uint>(3);
    }

    [Test]
    public async Task TestReadOnlyUnsignedInt32Property()
    {
        var sut = GetSut();

        await Assert.That(sut.UnsignedInt32PropertyReadOnly).IsEqualTo<uint>(2);
        await Assert.That(PropertyIsReadOnly(nameof(TestProperties.UnsignedInt32PropertyReadOnly))).IsTrue();
    }

    [Test]
    public async Task TestUnsignedInt32PropertyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.UnsignedInt32PropertyNullable).IsEqualTo(null);
        await Assert.That(sut.UnsignedInt32PropertyNullable = 1).IsEqualTo<uint?>(1);
    }

    [Test]
    public async Task TestUnsignedInt32PropertyReadOnlyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.UnsignedInt32PropertyReadOnlyNullableAsNull).IsEqualTo(null);
        await Assert.That(sut.UnsignedInt32PropertyReadOnlyNullableAsNotNull).IsEqualTo<uint?>(3);
    }

    // Int64
    [Test]
    public async Task TestInt64Property()
    {
        var sut = GetSut();

        await Assert.That(sut.Int64Property).IsEqualTo(1L);
        await Assert.That(sut.Int64Property = 10_000_000_000L).IsEqualTo(10_000_000_000L);
        await Assert.That(sut.Int64Property = -10_000_000_000L).IsEqualTo(-10_000_000_000L);
    }

    [Test]
    public async Task TestReadOnlyInt64Property()
    {
        var sut = GetSut();

        await Assert.That(sut.Int64PropertyReadOnly).IsEqualTo(2L);
        await Assert.That(PropertyIsReadOnly(nameof(TestProperties.Int64PropertyReadOnly))).IsTrue();
    }

    [Test]
    public async Task TestInt64PropertyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.Int64PropertyNullable).IsEqualTo(null);
        await Assert.That(sut.Int64PropertyNullable = 10_000_000_000L).IsEqualTo(10_000_000_000L);
        await Assert.That(sut.Int64PropertyNullable = -10_000_000_000L).IsEqualTo(-10_000_000_000L);
    }

    [Test]
    public async Task TestInt64PropertyReadOnlyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.Int64PropertyReadOnlyNullableAsNull).IsEqualTo(null);
        await Assert.That(sut.Int64PropertyReadOnlyNullableAsNotNull).IsEqualTo(3L);
    }

    // UnsignedInt64
    [Test]
    public async Task TestUnsignedInt64Property()
    {
        var sut = GetSut();

        await Assert.That(sut.UnsignedInt64Property).IsEqualTo(1UL);
        await Assert.That(sut.UnsignedInt64Property = 10_000_000_000UL).IsEqualTo(10_000_000_000UL);
    }

    [Test]
    public async Task TestReadOnlyUnsignedInt64Property()
    {
        var sut = GetSut();

        await Assert.That(sut.UnsignedInt64PropertyReadOnly).IsEqualTo(2UL);
        await Assert.That(PropertyIsReadOnly(nameof(TestProperties.UnsignedInt64PropertyReadOnly))).IsTrue();
    }

    [Test]
    public async Task TestUnsignedInt64PropertyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.UnsignedInt64PropertyNullable).IsEqualTo(null);
        await Assert.That(sut.UnsignedInt64PropertyNullable = 10_000_000_000UL).IsEqualTo(10_000_000_000UL);
    }

    [Test]
    public async Task TestUnsignedInt64PropertyReadOnlyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.UnsignedInt64PropertyReadOnlyNullableAsNull).IsEqualTo(null);
        await Assert.That(sut.UnsignedInt64PropertyReadOnlyNullableAsNotNull).IsEqualTo(3UL);
    }

    // Double
    [Test]
    public async Task TestDoubleProperty()
    {
        var sut = GetSut();

        await Assert.That(sut.DoubleProperty).IsEqualTo(1.2);
        await Assert.That(sut.DoubleProperty = 3.4).IsEqualTo(3.4);
    }

    [Test]
    public async Task TestReadOnlyDoubleProperty()
    {
        var sut = GetSut();

        await Assert.That(sut.DoublePropertyReadOnly).IsEqualTo(2.3);
        await Assert.That(PropertyIsReadOnly(nameof(TestProperties.DoublePropertyReadOnly))).IsTrue();
    }

    [Test]
    public async Task TestDoublePropertyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.DoublePropertyNullable).IsEqualTo(null);
        await Assert.That(sut.DoublePropertyNullable = 1.2).IsEqualTo(1.2);
    }

    [Test]
    public async Task TestDoublePropertyReadOnlyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.DoublePropertyReadOnlyNullableAsNull).IsEqualTo(null);
        await Assert.That(sut.DoublePropertyReadOnlyNullableAsNotNull).IsEqualTo(2.4);
    }

    // String
    [Test]
    public async Task TestStringPropertyGet()
    {
        var sut = GetSut();

        await Assert.That(sut.StringProperty).IsEqualTo("string property");
        await Assert.That(sut.StringProperty = "set string property").IsEqualTo("set string property");
    }

    [Test]
    public async Task TestReadOnlyStringPropertyGet()
    {
        var sut = GetSut();

        await Assert.That(sut.StringPropertyReadOnly).IsEqualTo("string property read only");
        await Assert.That(PropertyIsReadOnly(nameof(TestProperties.StringPropertyReadOnly))).IsTrue();
    }

    [Test]
    public async Task TestStringPropertyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.StringPropertyNullable).IsEqualTo(null);
        await Assert.That(sut.StringPropertyNullable = "some new string").IsEqualTo("some new string");
        await Assert.That(sut.StringPropertyNullable = string.Empty).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task TestStringPropertyReadOnlyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.StringPropertyReadOnlyNullableAsNull).IsEqualTo(null);
        await Assert.That(sut.StringPropertyReadOnlyNullableAsNotNull).IsEqualTo("this is not null string");
        await Assert.That(sut.StringPropertyReadOnlyNullableAsEmpty).IsEqualTo("");
    }
}