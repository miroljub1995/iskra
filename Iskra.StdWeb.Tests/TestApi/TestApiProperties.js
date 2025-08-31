export class TestApiProperties {

    stringProperty = "string property";

    get readOnlyStringProperty() {
        return "read only string property";
    }
}

globalThis.TestApiProperties = TestApiProperties;
