// Issue #2: Subclass instances not recognized by JSObjectProxyFactory
//
// Problem: Issue2Private extends Issue2Public, but when TryGetProxy is called
// on an Issue2Private instance, it fails to match the constructor registered
// in globalThis.Issue2 (which points to Issue2Public).
//
// Expected: JSObjectProxyFactory should recognize Issue2Private instances
// because their prototype chain includes Issue2Public.

class Issue2Public {
  value = 42;
}

class Issue2Private extends Issue2Public {}

export const Issue2 = Issue2Private;

globalThis.Issue2 = Issue2Public;
