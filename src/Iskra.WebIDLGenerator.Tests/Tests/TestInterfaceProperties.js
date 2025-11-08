export class TestInterfacePropertiesInterface {
    value = 3;
}

export class TestInterfaceProperties {
    value = new TestInterfacePropertiesInterface();
    valueNullable = new TestInterfacePropertiesInterface();

    get valueNullableReadonlyAsNotNull() {
        const res = new TestInterfacePropertiesInterface();
        res.value = 4;
        return res;
    }

    get valueNullableReadonlyAsNull() {
        return null;
    }
}

globalThis.TestInterfacePropertiesInterface = TestInterfacePropertiesInterface;
globalThis.TestInterfaceProperties = TestInterfaceProperties;
