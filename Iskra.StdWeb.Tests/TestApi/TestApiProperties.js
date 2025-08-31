export class TestApiProperties {
    intProperty = 1;

    get intPropertyReadOnly() {
        return 2;
    }

    intPropertyNullable = null;

    get intPropertyReadOnlyNullableAsNull() {
        return null;
    }

    get intPropertyReadOnlyNullableAsNotNull() {
        return 2;
    }

    doubleProperty = 1.2;

    get doublePropertyReadOnly() {
        return 2.3
    }

    boolProperty = true;

    get boolPropertyReadOnly() {
        return true;
    }

    stringProperty = "string property";

    get stringPropertyReadOnly() {
        return "string property read only";
    }
}

globalThis.TestApiProperties = TestApiProperties;
