import {TestApiProperties} from "./TestApiProperties.js";

globalThis.testApi = {
    get testApiProperties() {
        return new TestApiProperties()
    },
};
