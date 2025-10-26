export class TestCallbackProperties {
    voidCallback = (value) => {
        // Default implementation does nothing
    };

    set callVoidCallbackOnSet(value) {
        this.voidCallback(value);
    }

    variadicCallback = (param1, ...values) => {
        // Default implementation does nothing
    };

    set callVariadicCallbackOnSet(values) {
        this.variadicCallback(999, ...values);
    }
}

globalThis.TestCallbackProperties = TestCallbackProperties;
