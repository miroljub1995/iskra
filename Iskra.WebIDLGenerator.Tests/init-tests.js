import {TestProperties} from "./Tests/TestProperties.js";
import {TestArrayProperties} from "./Tests/TestArrayProperties.js";
import {TestEnumProperties} from "./Tests/TestEnumProperties.js";
import {TestFrozenArrayProperties} from "./Tests/TestFrozenArrayProperties.js";
import {TestUnionProperties} from "./Tests/TestUnionProperties.js";

globalThis.tests = {
    get testProperties() {
        return new TestProperties()
    },
    get testEnumProperties() {
        return new TestEnumProperties();
    },
    get testArrayProperties() {
        return new TestArrayProperties();
    },
    get testFrozenArrayProperties() {
        return new TestFrozenArrayProperties();
    },
    get testUnionProperties() {
        return new TestUnionProperties();
    }
};
