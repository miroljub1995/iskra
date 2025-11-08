export class TestEnumProperties {
    value = "enum-value-1";
    valueNullable = "enum-value-2";

    get valueNullableReadonlyAsNotNull() {
        return "enum-value-3";
    }

    get valueNullableReadonlyAsNull() {
        return null;
    }

    valueInvalid = "invalid-value";
}

globalThis.TestEnumProperties = TestEnumProperties;
