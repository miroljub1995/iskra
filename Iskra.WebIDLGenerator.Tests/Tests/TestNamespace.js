export class TestNamespace {
    testNS = {
        namespaceProp: "namespace value",

        voidOperation() {
            // Returns undefined
        },

        longOperation() {
            return 42;
        },

        stringOperation() {
            return "hello from namespace";
        },

        addNumbers(a, b) {
            return a + b;
        },

        optionalArgOperation(message = "default namespace") {
            return `Namespace Message: ${message}`;
        }
    };
}

globalThis.TestNamespace = TestNamespace;
