export class TestConstructors {
    constructor(...args) {
        this.args = args;
    }

    get getArgsAsJson() {
        return JSON.stringify(this.args);
    }
}

globalThis.TestConstructors = TestConstructors;

