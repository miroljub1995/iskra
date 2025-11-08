export class TestDictionary {
    processDictionary(value) {
        return JSON.stringify(value, Object.keys(value).sort());
    }
}

globalThis.TestDictionary = TestDictionary;
