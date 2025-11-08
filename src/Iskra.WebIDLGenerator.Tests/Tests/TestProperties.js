export class TestProperties {
    // Bool
    boolProperty = true;

    get boolPropertyReadOnly() {
        return true;
    }

    boolPropertyNullable = null;

    get boolPropertyReadOnlyNullableAsNull() {
        return null;
    }

    get boolPropertyReadOnlyNullableAsTrue() {
        return true;
    }

    get boolPropertyReadOnlyNullableAsFalse() {
        return false;
    }

    // Byte
    byteProperty = 1;

    get bytePropertyReadOnly() {
        return 2;
    }

    bytePropertyNullable = null;

    get bytePropertyReadOnlyNullableAsNull() {
        return null;
    }

    get bytePropertyReadOnlyNullableAsNotNull() {
        return 3;
    }

    // SignedByte
    signedByteProperty = 1;

    get signedBytePropertyReadOnly() {
        return 2;
    }

    signedBytePropertyNullable = null;

    get signedBytePropertyReadOnlyNullableAsNull() {
        return null;
    }

    get signedBytePropertyReadOnlyNullableAsNotNull() {
        return 3;
    }

    // Short
    shortProperty = 1;

    get shortPropertyReadOnly() {
        return 2;
    }

    shortPropertyNullable = null;

    get shortPropertyReadOnlyNullableAsNull() {
        return null;
    }

    get shortPropertyReadOnlyNullableAsNotNull() {
        return 3;
    }

    // UnsignedShort
    unsignedShortProperty = 1;

    get unsignedShortPropertyReadOnly() {
        return 2;
    }

    unsignedShortPropertyNullable = null;

    get unsignedShortPropertyReadOnlyNullableAsNull() {
        return null;
    }

    get unsignedShortPropertyReadOnlyNullableAsNotNull() {
        return 3;
    }

    // Int32
    int32Property = 1;

    get int32PropertyReadOnly() {
        return 2;
    }

    int32PropertyNullable = null;

    get int32PropertyReadOnlyNullableAsNull() {
        return null;
    }

    get int32PropertyReadOnlyNullableAsNotNull() {
        return 3;
    }

    // UnsignedInt32
    unsignedInt32Property = 1;

    get unsignedInt32PropertyReadOnly() {
        return 2;
    }

    unsignedInt32PropertyNullable = null;

    get unsignedInt32PropertyReadOnlyNullableAsNull() {
        return null;
    }

    get unsignedInt32PropertyReadOnlyNullableAsNotNull() {
        return 3;
    }

    // Int64
    int64Property = 1;

    get int64PropertyReadOnly() {
        return 2;
    }

    int64PropertyNullable = null;

    get int64PropertyReadOnlyNullableAsNull() {
        return null;
    }

    get int64PropertyReadOnlyNullableAsNotNull() {
        return 3;
    }

    // UnsignedInt64
    unsignedInt64Property = 1;

    get unsignedInt64PropertyReadOnly() {
        return 2;
    }

    unsignedInt64PropertyNullable = null;

    get unsignedInt64PropertyReadOnlyNullableAsNull() {
        return null;
    }

    get unsignedInt64PropertyReadOnlyNullableAsNotNull() {
        return 3;
    }

    // Float
    floatProperty = 1.2;

    get floatPropertyReadOnly() {
        return 2.3
    }

    floatPropertyNullable = null;

    get floatPropertyReadOnlyNullableAsNull() {
        return null;
    }

    get floatPropertyReadOnlyNullableAsNotNull() {
        return 2.4;
    }

    // UnrestrictedFloat
    unrestrictedFloatProperty = 1.2;

    get unrestrictedFloatPropertyReadOnly() {
        return 2.3
    }

    unrestrictedFloatPropertyNullable = null;

    get unrestrictedFloatPropertyReadOnlyNullableAsNull() {
        return null;
    }

    get unrestrictedFloatPropertyReadOnlyNullableAsNotNull() {
        return 2.4;
    }

    // Double
    doubleProperty = 1.2;

    get doublePropertyReadOnly() {
        return 2.3
    }

    doublePropertyNullable = null;

    get doublePropertyReadOnlyNullableAsNull() {
        return null;
    }

    get doublePropertyReadOnlyNullableAsNotNull() {
        return 2.4;
    }

    // UnrestrictedDouble
    unrestrictedDoubleProperty = 1.2;

    get unrestrictedDoublePropertyReadOnly() {
        return 2.3
    }

    unrestrictedDoublePropertyNullable = null;

    get unrestrictedDoublePropertyReadOnlyNullableAsNull() {
        return null;
    }

    get unrestrictedDoublePropertyReadOnlyNullableAsNotNull() {
        return 2.4;
    }

    // String
    stringProperty = "string property";

    get stringPropertyReadOnly() {
        return "string property read only";
    }

    stringPropertyNullable = null;

    get stringPropertyReadOnlyNullableAsNull() {
        return null;
    }

    get stringPropertyReadOnlyNullableAsNotNull() {
        return "this is not null string";
    }

    get stringPropertyReadOnlyNullableAsEmpty() {
        return "";
    }

    // Object
    objectProperty = {key: "object property"};

    get objectPropertyReadOnly() {
        return {key: "object property read only"};
    }

    objectPropertyNullable = null;

    get objectPropertyReadOnlyNullableAsNull() {
        return null;
    }

    get objectPropertyReadOnlyNullableAsNotNull() {
        return {key: "not null object"};
    }

    // BigInt
    bigIntProperty = 9223372036854775807000n;

    get bigIntPropertyReadOnly() {
        return 18446744073709551616n;
    }

    bigIntPropertyNullable = null;

    get bigIntPropertyReadOnlyNullableAsNull() {
        return null;
    }

    get bigIntPropertyReadOnlyNullableAsNotNull() {
        return 123456789012345678901234567890n;
    }
}

globalThis.TestProperties = TestProperties;
