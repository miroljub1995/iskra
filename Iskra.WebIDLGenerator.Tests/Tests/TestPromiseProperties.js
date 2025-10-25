export class TestPromiseProperties {
    // Promise<long>
    promisePropertyLong = Promise.resolve(42);

    get promisePropertyLongReadOnly() {
        return Promise.resolve(84);
    }

    promisePropertyLongNullable = null;

    get promisePropertyLongReadOnlyNullableAsNull() {
        return null;
    }

    get promisePropertyLongReadOnlyNullableAsNotNull() {
        return Promise.resolve(126);
    }

    // Promise<string>
    promisePropertyString = Promise.resolve("hello");

    get promisePropertyStringReadOnly() {
        return Promise.resolve("world");
    }

    // Delayed promise for testing async behavior
    get promisePropertyLongDelayed() {
        return new Promise((resolve) => {
            setTimeout(() => resolve(99), 1000);
        });
    }

    // Task to Promise test with setter
    testTaskToPromiseValue = null;

    set testTaskToPromise(value) {
        value.then(x => this.testTaskToPromiseValue = x);
    }
}

globalThis.TestPromiseProperties = TestPromiseProperties;
