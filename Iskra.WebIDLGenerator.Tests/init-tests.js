import {TestProperties} from "./Tests/TestProperties.js";
import {TestArrayProperties} from "./Tests/TestArrayProperties.js";

globalThis.tests = {
    get testProperties() {
        return new TestProperties()
    },
    get testArrayProperties() {
        return new TestArrayProperties();
    }
};
