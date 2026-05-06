using System.Runtime.InteropServices.JavaScript;
using Iskra.JSCore;
using Iskra.StdWeb;

namespace Iskra.CanvasExample;

public static class Program
{
    private const uint CanvasWidth = 800;
    private const uint CanvasHeight = 600;

    private static Window? _window;
    private static CanvasRenderingContext2D? _ctx;
    private static readonly List<Ball> Balls = [];
    private static readonly Random Random = new();
    private static FrameRequestCallback? _frameRequestCallback = null;

    private class Ball
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double VelocityX { get; set; }
        public double VelocityY { get; set; }
        public double Radius { get; init; }
        public string Color { get; init; } = "#667eea";
    }

    public static async Task Main()
    {
        await StdWebProxyFactory.InitializeAsync();

        _window = JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis);
        _window.Console.Log("Canvas Bouncing Balls initialized!");

        // Create container
        var container = (HTMLDivElement)_window.Document.CreateElement("div");
        _window.Document.Body?.AppendChild(container);
        SetStyle(container, "text-align", "center");
        SetStyle(container, "padding-top", "20px");
        SetStyle(container, "padding-right", "20px");
        SetStyle(container, "padding-bottom", "20px");
        SetStyle(container, "padding-left", "20px");
        SetStyle(container, "font-family", "Arial");

        // Title
        var title = (HTMLElement)_window.Document.CreateElement("h1");
        title.TextContent = "🎨 Canvas Bouncing Balls";
        SetStyle(title, "color", "white");
        SetStyle(title, "margin-bottom", "20px");
        container.AppendChild(title);

        // Canvas
        var canvas = (HTMLCanvasElement)_window.Document.CreateElement("canvas");
        canvas.Width = CanvasWidth;
        canvas.Height = CanvasHeight;
        SetStyle(canvas, "background-color", "white");
        SetStyle(canvas, "border-top-left-radius", "10px");
        SetStyle(canvas, "border-top-right-radius", "10px");
        SetStyle(canvas, "border-bottom-right-radius", "10px");
        SetStyle(canvas, "border-bottom-left-radius", "10px");
        SetStyle(canvas, "box-shadow", "0 4px 6px rgba(0,0,0,0.3)");
        SetStyle(canvas, "display", "block");
        SetStyle(canvas, "margin-left", "auto");
        SetStyle(canvas, "margin-right", "auto");
        container.AppendChild(canvas);

        // Controls
        var controls = (HTMLElement)_window.Document.CreateElement("div");
        SetStyle(controls, "margin-top", "20px");
        container.AppendChild(controls);

        var addButton = (HTMLElement)_window.Document.CreateElement("button");
        addButton.TextContent = "Add Ball";
        StyleButton(addButton, "#667eea");
        addButton.AddEventListener("click", new EventListener(_ => AddBall()), false);
        controls.AppendChild(addButton);

        var clearButton = (HTMLElement)_window.Document.CreateElement("button");
        clearButton.TextContent = "Clear All";
        StyleButton(clearButton, "#764ba2");
        clearButton.AddEventListener("click", new EventListener((e) => ClearBalls()), false);
        controls.AppendChild(clearButton);

        // Get canvas context
        if (canvas.GetContext("2d")?.TryCast(out _ctx) != true)
        {
            throw new NotSupportedException("Failed to get canvas context");
        }

        // Add initial balls
        for (var i = 0; i < 5; i++)
        {
            AddBall();
        }

        _frameRequestCallback = new FrameRequestCallback(static _ => AnimationLoop());

        // Start the animation loop
        AnimationLoop();

        await Task.Delay(Timeout.Infinite);
    }

    private static void StyleButton(HTMLElement button, string background)
    {
        SetStyle(button, "padding-top", "10px");
        SetStyle(button, "padding-right", "30px");
        SetStyle(button, "padding-bottom", "10px");
        SetStyle(button, "padding-left", "30px");
        SetStyle(button, "font-size", "16px");
        SetStyle(button, "background-color", background);
        SetStyle(button, "color", "white");
        SetStyle(button, "border-style", "none");
        SetStyle(button, "border-top-left-radius", "5px");
        SetStyle(button, "border-top-right-radius", "5px");
        SetStyle(button, "border-bottom-right-radius", "5px");
        SetStyle(button, "border-bottom-left-radius", "5px");
        SetStyle(button, "cursor", "pointer");
        SetStyle(button, "margin-top", "5px");
        SetStyle(button, "margin-right", "5px");
        SetStyle(button, "margin-bottom", "5px");
        SetStyle(button, "margin-left", "5px");
    }

    private static void SetStyle(HTMLElement element, string property, string value)
    {
        element.AttributeStyleMap.Set(property, value);
    }

    private static void AddBall()
    {
        string[] colors = ["#667eea", "#764ba2", "#f093fb", "#4facfe", "#43e97b", "#fa709a"];

        Balls.Add(new Ball
        {
            X = Random.Next(50, (int)CanvasWidth - 50),
            Y = Random.Next(50, (int)CanvasHeight - 50),
            VelocityX = Random.Next(-5, 6),
            VelocityY = Random.Next(-5, 6),
            Radius = Random.Next(10, 30),
            Color = colors[Random.Next(colors.Length)]
        });

        _window?.Console.Log($"Ball added! Total balls: {Balls.Count}");
    }

    private static void ClearBalls()
    {
        Balls.Clear();
        _window?.Console.Log("All balls cleared!");
    }

    private static void AnimationLoop()
    {
        if (_ctx == null || _window == null) return;

        // Clear canvas
        _ctx.ClearRect(0, 0, CanvasWidth, CanvasHeight);

        // Update and draw each ball
        foreach (var ball in Balls)
        {
            // Update position
            ball.X += ball.VelocityX;
            ball.Y += ball.VelocityY;

            // Bounce off walls
            if (ball.X - ball.Radius < 0 || ball.X + ball.Radius > CanvasWidth)
            {
                ball.VelocityX = -ball.VelocityX;
            }

            if (ball.Y - ball.Radius < 0 || ball.Y + ball.Radius > CanvasHeight)
            {
                ball.VelocityY = -ball.VelocityY;
            }

            // Keep the ball within bounds
            ball.X = Math.Max(ball.Radius, Math.Min(CanvasWidth - ball.Radius, ball.X));
            ball.Y = Math.Max(ball.Radius, Math.Min(CanvasHeight - ball.Radius, ball.Y));

            // Draw ball
            _ctx.BeginPath();
            _ctx.Arc(ball.X, ball.Y, ball.Radius, 0, Math.PI * 2);
            _ctx.FillStyle = ball.Color;
            _ctx.Fill();
            _ctx.ClosePath();
        }

        // Request next frame
        if (_frameRequestCallback is not null)
        {
            _window.RequestAnimationFrame(_frameRequestCallback);
        }
    }
}