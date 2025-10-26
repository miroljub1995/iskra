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

    nonVoidCallback = (a, b) => {
        // Default implementation returns 0
        return 0;
    };

    get nonVoidCallbackCallAndGetResult() {
        return this.nonVoidCallback(10, 20);
    }
}

globalThis.TestCallbackProperties = TestCallbackProperties;
