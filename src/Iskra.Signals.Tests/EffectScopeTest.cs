namespace Iskra.Signals.Tests;

[ParallelLimiter<SingleParallelLimit>]
public class EffectScopeTest
{
    [Test]
    public async Task ShouldRunEffectImmediately()
    {
        var scope = new EffectScope();

        var runCount = 0;
        scope.Run(() => { new Effect(_ => { runCount++; }); });

        await Assert.That(runCount).IsEqualTo(1);
    }

    [Test]
    public async Task ShouldRunEffectOnChange()
    {
        var signal = new Signal<string>("test");
        var scope = new EffectScope();

        var runCount = 0;
        scope.Run(() =>
        {
            new Effect(_ =>
            {
                var __ = signal.Value;
                runCount++;
            });
        });

        signal.Value = "new test";

        await Assert.That(runCount).IsEqualTo(2);
    }

    [Test]
    public async Task ShouldNoRunDisposedEffectOnChange()
    {
        var signal = new Signal<string>("test");
        var scope = new EffectScope();

        var runCount = 0;
        scope.Run(() =>
        {
            new Effect(_ =>
            {
                var __ = signal.Value;
                runCount++;
            });
        });

        scope.Dispose();
        signal.Value = "new test";

        await Assert.That(runCount).IsEqualTo(1);
    }

    [Test]
    public async Task ShouldDisposeNestedEffectScopes()
    {
        var signal = new Signal<string>("test");
        var parentScope = new EffectScope();

        var parentRunCount = 0;
        var childRunCount = 0;
        var nestedChildRunCount = 0;

        parentScope.Run(() =>
        {
            // Effect in parent scope
            new Effect(_ =>
            {
                var __ = signal.Value;
                parentRunCount++;
            });

            // Nested child scope
            var childScope = new EffectScope();
            childScope.Run(() =>
            {
                new Effect(_ =>
                {
                    var __ = signal.Value;
                    childRunCount++;
                });

                // Nested grandchild scope
                var nestedChildScope = new EffectScope();
                nestedChildScope.Run(() =>
                {
                    new Effect(_ =>
                    {
                        var __ = signal.Value;
                        nestedChildRunCount++;
                    });
                });
            });
        });

        // All effects should run initially
        await Assert.That(parentRunCount).IsEqualTo(1);
        await Assert.That(childRunCount).IsEqualTo(1);
        await Assert.That(nestedChildRunCount).IsEqualTo(1);

        // All effects should run on signal change
        signal.Value = "new test";
        await Assert.That(parentRunCount).IsEqualTo(2);
        await Assert.That(childRunCount).IsEqualTo(2);
        await Assert.That(nestedChildRunCount).IsEqualTo(2);

        // Dispose parent scope - all nested scopes should be disposed
        parentScope.Dispose();
        signal.Value = "another test";

        // No effects should run after parent disposal
        await Assert.That(parentRunCount).IsEqualTo(2);
        await Assert.That(childRunCount).IsEqualTo(2);
        await Assert.That(nestedChildRunCount).IsEqualTo(2);
    }

    [Test]
    public async Task ShouldCreateDetachedScope()
    {
        var signal = new Signal<string>("test");
        var parentScope = new EffectScope();

        var parentRunCount = 0;
        var detachedRunCount = 0;

        parentScope.Run(() =>
        {
            new Effect(_ =>
            {
                var __ = signal.Value;
                parentRunCount++;
            });

            // Create detached scope - should not be affected by parent disposal
            var detachedScope = new EffectScope(detached: true);
            detachedScope.Run(() =>
            {
                new Effect(_ =>
                {
                    var __ = signal.Value;
                    detachedRunCount++;
                });
            });
        });

        await Assert.That(parentRunCount).IsEqualTo(1);
        await Assert.That(detachedRunCount).IsEqualTo(1);

        // Dispose parent scope
        parentScope.Dispose();
        signal.Value = "new test";

        // Parent effect should not run, but detached scope should still be active
        await Assert.That(parentRunCount).IsEqualTo(1);
        await Assert.That(detachedRunCount).IsEqualTo(2);
    }

    [Test]
    public async Task ShouldDisposeMultipleEffectsInScope()
    {
        var signal1 = new Signal<string>("test1");
        var signal2 = new Signal<int>(1);
        var scope = new EffectScope();

        var effect1RunCount = 0;
        var effect2RunCount = 0;
        var effect3RunCount = 0;

        scope.Run(() =>
        {
            new Effect(_ =>
            {
                var __ = signal1.Value;
                effect1RunCount++;
            });

            new Effect(_ =>
            {
                var __ = signal2.Value;
                effect2RunCount++;
            });

            new Effect(_ =>
            {
                var _1 = signal1.Value;
                var _2 = signal2.Value;
                effect3RunCount++;
            });
        });

        // All effects should run initially
        await Assert.That(effect1RunCount).IsEqualTo(1);
        await Assert.That(effect2RunCount).IsEqualTo(1);
        await Assert.That(effect3RunCount).IsEqualTo(1);

        signal1.Value = "test2";
        await Assert.That(effect1RunCount).IsEqualTo(2);
        await Assert.That(effect3RunCount).IsEqualTo(2);

        // Dispose scope - all effects should stop
        scope.Dispose();
        signal1.Value = "test3";
        signal2.Value = 2;

        await Assert.That(effect1RunCount).IsEqualTo(2);
        await Assert.That(effect2RunCount).IsEqualTo(1);
        await Assert.That(effect3RunCount).IsEqualTo(2);
    }

    [Test]
    public async Task ShouldCallCleanupOnDispose()
    {
        var signal = new Signal<string>("test");
        var scope = new EffectScope();

        var cleanupCallCount = 0;

        scope.Run(() =>
        {
            new Effect(onCleanup =>
            {
                var __ = signal.Value;
                onCleanup(() => { cleanupCallCount++; });
            });
        });

        await Assert.That(cleanupCallCount).IsEqualTo(0);

        // Trigger effect re-run - should call cleanup
        signal.Value = "new test";
        await Assert.That(cleanupCallCount).IsEqualTo(1);

        // Dispose scope - should call cleanup again
        scope.Dispose();
        await Assert.That(cleanupCallCount).IsEqualTo(2);
    }

    [Test]
    public async Task ShouldIsolateScopesFromEachOther()
    {
        var signal = new Signal<string>("test");
        var scope1 = new EffectScope();
        var scope2 = new EffectScope();

        var scope1RunCount = 0;
        var scope2RunCount = 0;

        scope1.Run(() =>
        {
            new Effect(_ =>
            {
                var __ = signal.Value;
                scope1RunCount++;
            });
        });

        scope2.Run(() =>
        {
            new Effect(_ =>
            {
                var __ = signal.Value;
                scope2RunCount++;
            });
        });

        await Assert.That(scope1RunCount).IsEqualTo(1);
        await Assert.That(scope2RunCount).IsEqualTo(1);

        // Both scopes should react to signal change
        signal.Value = "new test";
        await Assert.That(scope1RunCount).IsEqualTo(2);
        await Assert.That(scope2RunCount).IsEqualTo(2);

        // Dispose only scope1
        scope1.Dispose();
        signal.Value = "another test";

        // Only scope2 should still react
        await Assert.That(scope1RunCount).IsEqualTo(2);
        await Assert.That(scope2RunCount).IsEqualTo(3);
    }

    [Test]
    public async Task ShouldDisposeChildScopeIndependently()
    {
        var signal = new Signal<string>("test");
        var parentScope = new EffectScope();

        var parentRunCount = 0;
        var childRunCount = 0;
        EffectScope? childScope = null;

        parentScope.Run(() =>
        {
            new Effect(_ =>
            {
                var __ = signal.Value;
                parentRunCount++;
            });

            childScope = new EffectScope();
            childScope.Run(() =>
            {
                new Effect(_ =>
                {
                    var __ = signal.Value;
                    childRunCount++;
                });
            });
        });

        await Assert.That(parentRunCount).IsEqualTo(1);
        await Assert.That(childRunCount).IsEqualTo(1);

        // Dispose child scope independently
        childScope?.Dispose();
        signal.Value = "new test";

        // Parent should still run, child should not
        await Assert.That(parentRunCount).IsEqualTo(2);
        await Assert.That(childRunCount).IsEqualTo(1);

        // Parent can still be disposed normally
        parentScope.Dispose();
        signal.Value = "another test";
        await Assert.That(parentRunCount).IsEqualTo(2);
    }

    [Test]
    public async Task ShouldHandleDoubleDisposal()
    {
        var signal = new Signal<string>("test");
        var scope = new EffectScope();

        var runCount = 0;
        var cleanupCount = 0;

        scope.Run(() =>
        {
            new Effect(onCleanup =>
            {
                var __ = signal.Value;
                runCount++;
                onCleanup(() => { cleanupCount++; });
            });
        });

        await Assert.That(runCount).IsEqualTo(1);

        // First disposal
        scope.Dispose();
        await Assert.That(cleanupCount).IsEqualTo(1);

        // Second disposal - should be idempotent
        scope.Dispose();
        await Assert.That(cleanupCount).IsEqualTo(1); // Should not increase

        signal.Value = "new test";
        await Assert.That(runCount).IsEqualTo(1); // Effect should not run
    }

    [Test]
    public async Task ShouldThrowWhenCreatingEffectOutsideScope()
    {
        var signal = new Signal<string>("test");

        await Assert.That(() =>
        {
            new Effect(_ =>
            {
                var __ = signal.Value;
            });
        }).Throws<Exception>();
    }

    [Test]
    public async Task ShouldMaintainActiveScopeContext()
    {
        var scope1 = new EffectScope();
        var scope2 = new EffectScope();

        IEffectScope? capturedScope1 = null;
        IEffectScope? capturedScope2 = null;
        IEffectScope? capturedNestedScope = null;
        IEffectScope? capturedAfterNested = null;

        scope1.Run(() =>
        {
            capturedScope1 = EffectScopeContext.Active;

            var nestedScope = new EffectScope();
            nestedScope.Run(() => { capturedNestedScope = EffectScopeContext.Active; });

            // Context should be restored after nested scope.Run
            capturedAfterNested = EffectScopeContext.Active;
        });

        scope2.Run(() => { capturedScope2 = EffectScopeContext.Active; });

        // Verify each scope captured its own context
        await Assert.That(capturedScope1).IsEqualTo(scope1);
        await Assert.That(capturedScope2).IsEqualTo(scope2);
        await Assert.That(capturedNestedScope).IsNotEqualTo(scope1);
        await Assert.That(capturedNestedScope).IsNotNull();
        await Assert.That(capturedAfterNested).IsEqualTo(scope1);
    }

    [Test]
    public async Task ShouldRestoreContextAfterRunCompletion()
    {
        var initialContext = EffectScopeContext.Active;
        var scope = new EffectScope();

        IEffectScope? insideContext = null;
        scope.Run(() => { insideContext = EffectScopeContext.Active; });

        await Assert.That(insideContext).IsEqualTo(scope);
        var afterContext = EffectScopeContext.Active;
        await Assert.That(afterContext).IsEqualTo(initialContext);
    }

    [Test]
    public async Task ShouldRestoreContextEvenOnException()
    {
        var initialContext = EffectScopeContext.Active;
        var scope = new EffectScope();

        try
        {
            scope.Run(() => { throw new InvalidOperationException("Test exception"); });
        }
        catch (InvalidOperationException)
        {
            // Expected
        }

        var afterContext = EffectScopeContext.Active;
        await Assert.That(afterContext).IsEqualTo(initialContext);
    }

    [Test]
    public async Task ShouldHandleComplexNestedHierarchy()
    {
        var signal = new Signal<int>(0);
        var rootScope = new EffectScope();

        var runCounts = new int[5];

        rootScope.Run(() =>
        {
            new Effect(_ =>
            {
                var __ = signal.Value;
                runCounts[0]++;
            });

            var branch1 = new EffectScope();
            branch1.Run(() =>
            {
                new Effect(_ =>
                {
                    var __ = signal.Value;
                    runCounts[1]++;
                });

                var leaf1 = new EffectScope();
                leaf1.Run(() =>
                {
                    new Effect(_ =>
                    {
                        var __ = signal.Value;
                        runCounts[2]++;
                    });
                });
            });

            var branch2 = new EffectScope();
            branch2.Run(() =>
            {
                new Effect(_ =>
                {
                    var __ = signal.Value;
                    runCounts[3]++;
                });

                var leaf2 = new EffectScope();
                leaf2.Run(() =>
                {
                    new Effect(_ =>
                    {
                        var __ = signal.Value;
                        runCounts[4]++;
                    });
                });
            });
        });

        // All effects run initially
        for (int i = 0; i < 5; i++)
        {
            await Assert.That(runCounts[i]).IsEqualTo(1);
        }

        // All effects react to signal change
        signal.Value = 1;
        for (int i = 0; i < 5; i++)
        {
            await Assert.That(runCounts[i]).IsEqualTo(2);
        }

        // Dispose root - all should stop
        rootScope.Dispose();
        signal.Value = 2;
        for (int i = 0; i < 5; i++)
        {
            await Assert.That(runCounts[i]).IsEqualTo(2);
        }
    }

    [Test]
    public async Task ShouldDisposeEffectsBeforeChildScopes()
    {
        var disposalOrder = new List<string>();
        var scope = new EffectScope();

        scope.Run(() =>
        {
            new Effect(onCleanup => { onCleanup(() => { disposalOrder.Add("parent-effect"); }); });

            var childScope = new EffectScope();
            childScope.Run(() =>
            {
                new Effect(onCleanup => { onCleanup(() => { disposalOrder.Add("child-effect"); }); });
            });
        });

        scope.Dispose();

        // Effects should be disposed, then child scopes
        await Assert.That(disposalOrder.Count).IsEqualTo(2);
        await Assert.That(disposalOrder[0]).IsEqualTo("child-effect");
        await Assert.That(disposalOrder[1]).IsEqualTo("parent-effect");
    }

    [Test]
    public async Task ShouldHandleEmptyScopeDisposal()
    {
        var scope = new EffectScope();

        // Scope with no effects or children should dispose cleanly
        scope.Dispose();

        // Should be idempotent
        scope.Dispose();

        // Test passes if no exceptions thrown
    }

    [Test]
    public async Task ShouldDisposeScopeWithOnlyChildScopes()
    {
        var signal = new Signal<string>("test");
        var parentScope = new EffectScope();

        var child1RunCount = 0;
        var child2RunCount = 0;

        parentScope.Run(() =>
        {
            // No effects in parent scope, only child scopes
            var child1 = new EffectScope();
            child1.Run(() =>
            {
                new Effect(_ =>
                {
                    var __ = signal.Value;
                    child1RunCount++;
                });
            });

            var child2 = new EffectScope();
            child2.Run(() =>
            {
                new Effect(_ =>
                {
                    var __ = signal.Value;
                    child2RunCount++;
                });
            });
        });

        await Assert.That(child1RunCount).IsEqualTo(1);
        await Assert.That(child2RunCount).IsEqualTo(1);

        parentScope.Dispose();
        signal.Value = "new test";

        await Assert.That(child1RunCount).IsEqualTo(1);
        await Assert.That(child2RunCount).IsEqualTo(1);
    }

    [Test]
    public async Task ShouldHandleMixedDetachedAndNormalScopes()
    {
        var signal = new Signal<string>("test");
        var parentScope = new EffectScope();

        var normalChildRunCount = 0;
        var detachedChildRunCount = 0;
        EffectScope? detachedScope = null;

        parentScope.Run(() =>
        {
            var normalChild = new EffectScope();
            normalChild.Run(() =>
            {
                new Effect(_ =>
                {
                    var __ = signal.Value;
                    normalChildRunCount++;
                });
            });

            detachedScope = new EffectScope(detached: true);
            detachedScope.Run(() =>
            {
                new Effect(_ =>
                {
                    var __ = signal.Value;
                    detachedChildRunCount++;
                });
            });
        });

        await Assert.That(normalChildRunCount).IsEqualTo(1);
        await Assert.That(detachedChildRunCount).IsEqualTo(1);

        // Dispose parent - only normal child should be affected
        parentScope.Dispose();
        signal.Value = "new test";

        await Assert.That(normalChildRunCount).IsEqualTo(1);
        await Assert.That(detachedChildRunCount).IsEqualTo(2);

        // Manually dispose detached scope
        detachedScope!.Dispose();
        signal.Value = "another test";
        await Assert.That(detachedChildRunCount).IsEqualTo(2);
    }

    [Test]
    public async Task ShouldHandleMultipleCleanupFunctions()
    {
        var signal = new Signal<string>("test");
        var scope = new EffectScope();

        var cleanup1Count = 0;
        var cleanup2Count = 0;
        var cleanup3Count = 0;

        scope.Run(() =>
        {
            new Effect(onCleanup =>
            {
                var __ = signal.Value;
                onCleanup(() => { cleanup1Count++; });
                onCleanup(() => { cleanup2Count++; });
                onCleanup(() => { cleanup3Count++; });
            });
        });

        // Trigger effect re-run
        signal.Value = "new test";

        await Assert.That(cleanup1Count).IsEqualTo(1);
        await Assert.That(cleanup2Count).IsEqualTo(1);
        await Assert.That(cleanup3Count).IsEqualTo(1);

        // Dispose scope
        scope.Dispose();

        await Assert.That(cleanup1Count).IsEqualTo(2);
        await Assert.That(cleanup2Count).IsEqualTo(2);
        await Assert.That(cleanup3Count).IsEqualTo(2);
    }
}