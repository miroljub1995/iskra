import {TestProperties} from "./Tests/TestProperties.js";

globalThis.tests = {
    get testProperties() {
        return new TestProperties()
    },
};
