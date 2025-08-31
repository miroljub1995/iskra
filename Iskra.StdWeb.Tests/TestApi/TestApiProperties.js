export class TestApiProperties {
    intProperty = 1;

    get intPropertyReadOnly() {
        return 2;
    }

    doubleProperty = 1.2;

    get doublePropertyReadOnly() {
        return 2.3
    }

    stringProperty = "string property";

    get stringPropertyReadOnly() {
        return "string property read only";
    }
}

globalThis.TestApiProperties = TestApiProperties;
