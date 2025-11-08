import {TestProperties} from "./Tests/TestProperties.js";
import {TestAnyProperties} from "./Tests/TestAnyProperties.js";
import {TestArrayProperties} from "./Tests/TestArrayProperties.js";
import {TestCallbackInterface} from "./Tests/TestCallbackInterface.js";
import {TestCallbackProperties} from "./Tests/TestCallbackProperties.js";
import {TestConstructors} from "./Tests/TestConstructors.js";
import {TestDictionary} from "./Tests/TestDictionary.js";
import {TestEnumProperties} from "./Tests/TestEnumProperties.js";
import {TestFrozenArrayProperties} from "./Tests/TestFrozenArrayProperties.js";
import {TestInterfaceProperties} from "./Tests/TestInterfaceProperties.js";
import {TestNamespace} from "./Tests/TestNamespace.js";
import {TestObservableArrayProperties} from "./Tests/TestObservableArrayProperties.js";
import {TestOperations} from "./Tests/TestOperations.js";
import {TestPromiseProperties} from "./Tests/TestPromiseProperties.js";
import {TestRecordLong} from "./Tests/TestRecordLong.js";
import {TestStaticProperties} from "./Tests/TestStaticProperties.js";
import {TestUnionProperties} from "./Tests/TestUnionProperties.js";
import {issues} from "./init-tests-issues.js";

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
    get testCallbackInterface() {
        return new TestCallbackInterface();
    },
    get testCallbackProperties() {
        return new TestCallbackProperties();
    },
    get testConstructors() {
        return new TestConstructors();
    },
    get testDictionary() {
        return new TestDictionary();
    },
    get testFrozenArrayProperties() {
        return new TestFrozenArrayProperties();
    },
    get testInterfaceProperties() {
        return new TestInterfaceProperties();
    },
    get testNamespace() {
        return new TestNamespace();
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

Object.defineProperties(globalThis.tests, Object.getOwnPropertyDescriptors(issues));
