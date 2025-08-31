using ChromeForTesting;
using Microsoft.Extensions.FileProviders;
using PuppeteerSharp;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("index.html",
    () => Results.File(Path.Join(AppDomain.CurrentDomain.BaseDirectory, "./index.html"), "text/html; charset=utf-8")
);

app.UseStaticFiles(new StaticFileOptions
{
    ServeUnknownFileTypes = true,
    FileProvider =
        new PhysicalFileProvider(Path.Join(AppDomain.CurrentDomain.BaseDirectory,
            "../../../../Iskra.StdWeb.Tests/bin/Debug/net9.0/browser-wasm/AppBundle/"))
});

var appStarted = new TaskCompletionSource();
app.Lifetime.ApplicationStarted.Register(appStarted.SetResult);

var appRunTask = app.RunAsync("https://127.0.0.1:0");
await appStarted.Task;

var url = new Uri(app.Urls.Single());

var isDebug = app.Environment.IsDevelopment();
// var isDebug = true;

LaunchOptions options = new()
{
    ExecutablePath = ChromeForTestingInstance.ChromePath,
    Args =
    [
        "--no-sandbox",
        "--no-zygote",

        // https://developer.chrome.com/blog/supercharge-web-ai-testing#enable-webgpu
        "--use-angle=vulkan",
        "--enable-features=Vulkan",
        "--disable-vulkan-surface",
        "--enable-unsafe-webgpu",

        // "--disable-web-security",
    ],
    DumpIO = true,
    Headless = !isDebug,
    Devtools = isDebug,
    DefaultViewport = isDebug ? null : ViewPortOptions.Default,
    AcceptInsecureCerts = true,
};

await using var browser = await Puppeteer.LaunchAsync(options, app.Services.GetRequiredService<ILoggerFactory>());

var pages = await browser.PagesAsync();
var page = pages.Single();

page.Console += (_, args) =>
{
    switch (args.Message.Type)
    {
        case ConsoleType.Error:
            app.Logger.LogError(args.Message.Text);
            break;
        case ConsoleType.Warning:
            app.Logger.LogWarning(args.Message.Text);
            break;
        default:
            app.Logger.LogInformation(args.Message.Text);
            break;
    }
};

await page.GoToAsync($"https://127.0.0.1:{url.Port}/index.html");
await page.WaitForExpressionAsync("!!globalThis.run");
var exitCode = await page.EvaluateExpressionAsync<int>("run();");

if (isDebug)
{
    var closeTaskSource = new TaskCompletionSource();
    page.Close += (_, _) => { closeTaskSource.SetResult(); };
    await closeTaskSource.Task;
}

await app.StopAsync();
await appRunTask;

Environment.Exit(exitCode);