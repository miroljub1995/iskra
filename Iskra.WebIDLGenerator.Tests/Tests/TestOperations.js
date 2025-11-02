export class TestOperations {
    voidOperation() {
        // Returns undefined
    }

    boolOperation() {
        return true;
    }

    longOperation() {
        return 42;
    }

    stringOperation() {
        return "hello world";
    }

    addNumbers(a, b) {
        return a + b;
    }

    optionalArgOperation(message = "default") {
        return `Message: ${message}`;
    }

    nullableReturnOperation(returnNull) {
        if (returnNull) {
            return null;
        }

        return "not null";
    }

    promiseOperation(value) {
        return Promise.resolve(value * 2);
    }

    variadicOperation(...numbers) {
        return numbers.reduce((sum, num) => sum + num, 0);
    }
}

globalThis.TestOperations = TestOperations;
