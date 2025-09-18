export class TestProperties {
    // Int
    intProperty = 1;

    get intPropertyReadOnly() {
        return 2;
    }

    intPropertyNullable = null;

    get intPropertyReadOnlyNullableAsNull() {
        return null;
    }

    get intPropertyReadOnlyNullableAsNotNull() {
        return 3;
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
}

globalThis.TestProperties = TestProperties;
