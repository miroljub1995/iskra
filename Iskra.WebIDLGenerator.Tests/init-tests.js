import {TestProperties} from "./Tests/TestProperties.js";
import {TestArrayProperties} from "./Tests/TestArrayProperties.js";
import {TestFrozenArrayProperties} from "./Tests/TestFrozenArrayProperties.js";

globalThis.tests = {
    get testProperties() {
        return new TestProperties()
    },
    get testArrayProperties() {
        return new TestArrayProperties();
    },
    get testFrozenArrayProperties() {
        return new TestFrozenArrayProperties();
    },
};
