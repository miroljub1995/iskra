export class TestApiProperties {
    intProperty = 1;

    get intPropertyReadOnly() {
        return 2;
    }

    stringProperty = "string property";

    get stringPropertyReadOnly() {
        return "string property read only";
    }
}

globalThis.TestApiProperties = TestApiProperties;
