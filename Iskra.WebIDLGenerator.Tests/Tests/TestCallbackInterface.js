export class TestCallbackInterface {
    invokeCallback(callbackInterface) {
        return callbackInterface.processValue(999);
    }
}

globalThis.TestCallbackInterface = TestCallbackInterface;
