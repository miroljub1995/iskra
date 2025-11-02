import {TestProperties} from "./Tests/TestProperties.js";
import {TestAnyProperties} from "./Tests/TestAnyProperties.js";
import {TestArrayProperties} from "./Tests/TestArrayProperties.js";
import {TestCallbackProperties} from "./Tests/TestCallbackProperties.js";
import {TestDictionaryProperties} from "./Tests/TestDictionaryProperties.js";
import {TestEnumProperties} from "./Tests/TestEnumProperties.js";
import {TestFrozenArrayProperties} from "./Tests/TestFrozenArrayProperties.js";
import {TestInterfaceProperties} from "./Tests/TestInterfaceProperties.js";
import {TestObservableArrayProperties} from "./Tests/TestObservableArrayProperties.js";
import {TestOperations} from "./Tests/TestOperations.js";
import {TestPromiseProperties} from "./Tests/TestPromiseProperties.js";
import {TestRecordLong} from "./Tests/TestRecordLong.js";
import {TestStaticProperties} from "./Tests/TestStaticProperties.js";
import {TestUnionProperties} from "./Tests/TestUnionProperties.js";

globalThis.tests = {
    get testProperties() {
        return new TestProperties()
    },
    get testAnyProperties() {
        return new TestAnyProperties();
    },
    get testEnumProperties() {
        return new TestEnumProperties();
    },
    get testArrayProperties() {
        return new TestArrayProperties();
    },
    get testCallbackProperties() {
        return new TestCallbackProperties();
    },
    get testDictionaryProperties() {
        return new TestDictionaryProperties();
    },
    get testFrozenArrayProperties() {
        return new TestFrozenArrayProperties();
    },
    get testInterfaceProperties() {
        return new TestInterfaceProperties();
    },
    get testObservableArrayProperties() {
        return new TestObservableArrayProperties();
    },
    get testOperations() {
        return new TestOperations();
    },
    get testPromiseProperties() {
        return new TestPromiseProperties();
    },
    get testRecordLong() {
        return new TestRecordLong();
    },
    get testStaticProperties() {
        return new TestStaticProperties();
    },
    get testUnionProperties() {
        return new TestUnionProperties();
    },
};
