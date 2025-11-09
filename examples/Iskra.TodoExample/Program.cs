using System.Runtime.InteropServices.JavaScript;
using Iskra.JSCore;
using Iskra.StdWeb;

namespace Iskra.TodoExample;

public static class Program
{
    private static Window? _window;
    private static Element? _todoList;
    private static readonly List<string> Todos = [];

    public static async Task Main()
    {
        await StdWebProxyFactory.InitializeAsync();

        _window = JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis);
        _window.Console.Log("Todo List App initialized!");

        // Create the main container
        var container = _window.Document.CreateElement("div");
        container.SetAttribute("style",
            "max-width: 600px; margin: 50px auto; padding: 30px; " +
            "background: white; border-radius: 10px; box-shadow: 0 4px 6px rgba(0,0,0,0.1);");
        _window.Document.Body?.AppendChild(container);

        // Title
        var title = _window.Document.CreateElement("h1");
        title.TextContent = "📝 Todo List";
        title.SetAttribute("style", "color: #333; margin-bottom: 20px;");
        container.AppendChild(title);

        // Input container
        var inputContainer = _window.Document.CreateElement("div");
        inputContainer.SetAttribute("style", "display: flex; gap: 10px; margin-bottom: 20px;");
        container.AppendChild(inputContainer);

        // Input field
        var input = (HTMLInputElement)_window.Document.CreateElement("input");
        input.SetAttribute("type", "text");
        input.SetAttribute("placeholder", "Enter a new task...");
        input.SetAttribute("style",
            "flex: 1; padding: 10px; font-size: 16px; border: 2px solid #ddd; " +
            "border-radius: 5px; outline: none;");
        inputContainer.AppendChild(input);

        // Add button
        var addButton = _window.Document.CreateElement("button");
        addButton.TextContent = "Add";
        addButton.SetAttribute("style",
            "padding: 10px 30px; font-size: 16px; background: #667eea; " +
            "color: white; border: none; border-radius: 5px; cursor: pointer;");
        inputContainer.AppendChild(addButton);

        // Todo list container
        _todoList = _window.Document.CreateElement("ul");
        _todoList.SetAttribute("style",
            "list-style: none; padding: 0; margin: 0;");
        container.AppendChild(_todoList);

        // Event handlers
        addButton.AddEventListener("click", new EventListener((e) => AddTodo(input)), false);

        input.AddEventListener("keypress", new EventListener((e) =>
        {
            if (e is KeyboardEvent { Key: "Enter" })
            {
                AddTodo(input);
            }
        }), false);

        // Add some sample todos
        Todos.Add("Learn Iskra framework");
        Todos.Add("Build awesome WebAssembly apps");
        Todos.Add("Share with the community");
        RenderTodos();

        await Task.Delay(Timeout.Infinite);
    }

    private static void AddTodo(HTMLInputElement input)
    {
        var text = input.Value.Trim();
        if (!string.IsNullOrEmpty(text))
        {
            Todos.Add(text);
            input.Value = "";
            RenderTodos();
            _window?.Console.Log($"Added todo: {text}");
        }
    }

    private static void RemoveTodo(int index)
    {
        if (index >= 0 && index < Todos.Count)
        {
            var todo = Todos[index];
            Todos.RemoveAt(index);
            RenderTodos();
            _window?.Console.Log($"Removed todo: {todo}");
        }
    }

    private static void RenderTodos()
    {
        if (_todoList == null || _window == null)
        {
            return;
        }

        // Clear existing todos
        _todoList.InnerHTML = "";

        // Render each todo
        for (var i = 0; i < Todos.Count; i++)
        {
            var index = i; // Capture for closure
            var li = _window.Document.CreateElement("li");
            li.SetAttribute("style",
                "padding: 15px; margin-bottom: 10px; background: #f8f9fa; " +
                "border-radius: 5px; display: flex; justify-content: space-between; " +
                "align-items: center; transition: background 0.2s;");

            var text = _window.Document.CreateElement("span");
            text.TextContent = Todos[i];
            text.SetAttribute("style", "flex: 1; color: #333;");
            li.AppendChild(text);

            var deleteButton = _window.Document.CreateElement("button");
            deleteButton.TextContent = "❌";
            deleteButton.SetAttribute("style",
                "background: none; border: none; font-size: 18px; " +
                "cursor: pointer; padding: 5px 10px;");
            deleteButton.AddEventListener("click", new EventListener(_ => RemoveTodo(index)), false);
            li.AppendChild(deleteButton);

            _todoList.AppendChild(li);
        }

        // Show empty state if no todos
        if (Todos.Count == 0)
        {
            var emptyState = _window.Document.CreateElement("li");
            emptyState.TextContent = "No tasks yet. Add one above! 🎯";
            emptyState.SetAttribute("style",
                "padding: 30px; text-align: center; color: #999; font-style: italic;");
            _todoList.AppendChild(emptyState);
        }
    }
}