using Iskra.Reactivity;
using IskraSample;
using static Iskra.Reactivity.ReactivityApi;

Ref<int> counter = new(0);
IComputedRef<int> computedCounter = Computed(() => counter.Value);

EffectsScope counterScope = new();
counterScope.Run(() =>
{
    WatchEffect(() =>
    {
        Console.WriteLine("Effect called.");
        Console.WriteLine($"Tracking counter: {counter.Value}");
    });

    WatchEffect(() =>
    {
        Console.WriteLine("Effect for computed called.");
        Console.WriteLine($"Tracking computed counter: {computedCounter.Value}");
    });
});

// counterScope.Run(() =>
// {
//     WatchEffectHelper.WatchEffect(() =>
//     {
//         Console.WriteLine("Effect 2 called.");
//         Console.WriteLine($"Tracking counter in effect 2: {counter.Value}");
//     });
// });

counter.Value++; // Should trigger effect
counter.Value++; // Should trigger effect
counterScope.Dispose();
counter.Value++; // Should not trigger
return;


Ref<HelloWorld> testRef = new HelloWorld()
{
    TestProp = "Test prop value",
    TestAnotherProp = "Another test prop value",
}.ToRef();

EffectsScope scope = new();
scope.Run(() =>
{
    ReactivityApi.WatchEffect(() =>
    {
        Console.WriteLine("Effect called.");
        Console.WriteLine($"Tracking TestProp: {testRef.Value.TestProp}");
    });
});

scope.Run(() => { });


testRef.Value.TestProp = "test";

testRef.Value.TestProp = "test 2";

scope.Dispose();

testRef.Value.TestAnotherProp = "test another prop 2";

Console.WriteLine("Done!");