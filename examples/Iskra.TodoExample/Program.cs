using System.Runtime.InteropServices.JavaScript;
using Iskra.JSCore;
using Iskra.StdWeb;

namespace Iskra.TodoExample;

public static class Program
{
    private static Window? _window;
    private static HTMLElement? _todoList;
    private static readonly List<string> Todos = [];

    public static async Task Main()
    {
        await StdWebProxyFactory.InitializeAsync();

        _window = JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis);
        _window.Console.Log("Todo List App initialized!");

        // Create the main container
        var container = (HTMLElement)_window.Document.CreateElement("div");
        SetStyle(container, "max-width", "600px");
        SetStyle(container, "margin-top", "50px");
        SetStyle(container, "margin-right", "auto");
        SetStyle(container, "margin-bottom", "50px");
        SetStyle(container, "margin-left", "auto");
        SetStyle(container, "padding-top", "30px");
        SetStyle(container, "padding-right", "30px");
        SetStyle(container, "padding-bottom", "30px");
        SetStyle(container, "padding-left", "30px");
        SetStyle(container, "background-color", "white");
        SetStyle(container, "border-top-left-radius", "10px");
        SetStyle(container, "border-top-right-radius", "10px");
        SetStyle(container, "border-bottom-right-radius", "10px");
        SetStyle(container, "border-bottom-left-radius", "10px");
        SetStyle(container, "box-shadow", "0 4px 6px rgba(0,0,0,0.1)");
        _window.Document.Body?.AppendChild(container);

        // Title
        var title = (HTMLElement)_window.Document.CreateElement("h1");
        title.TextContent = "📝 Todo List";
        SetStyle(title, "color", "#333");
        SetStyle(title, "margin-bottom", "20px");
        container.AppendChild(title);

        // Input container
        var inputContainer = (HTMLElement)_window.Document.CreateElement("div");
        SetStyle(inputContainer, "display", "flex");
        SetStyle(inputContainer, "gap", "10px");
        SetStyle(inputContainer, "margin-bottom", "20px");
        container.AppendChild(inputContainer);

        // Input field
        var input = (HTMLInputElement)_window.Document.CreateElement("input");
        input.SetAttribute("type", "text");
        input.SetAttribute("placeholder", "Enter a new task...");
        SetStyle(input, "flex-grow", "1");
        SetStyle(input, "flex-shrink", "1");
        SetStyle(input, "flex-basis", "0%");
        SetStyle(input, "padding-top", "10px");
        SetStyle(input, "padding-right", "10px");
        SetStyle(input, "padding-bottom", "10px");
        SetStyle(input, "padding-left", "10px");
        SetStyle(input, "font-size", "16px");
        SetStyle(input, "border-top-width", "2px");
        SetStyle(input, "border-right-width", "2px");
        SetStyle(input, "border-bottom-width", "2px");
        SetStyle(input, "border-left-width", "2px");
        SetStyle(input, "border-style", "solid");
        SetStyle(input, "border-color", "#ddd");
        SetStyle(input, "border-top-left-radius", "5px");
        SetStyle(input, "border-top-right-radius", "5px");
        SetStyle(input, "border-bottom-right-radius", "5px");
        SetStyle(input, "border-bottom-left-radius", "5px");
        SetStyle(input, "outline-style", "none");
        inputContainer.AppendChild(input);

        // Add button
        var addButton = (HTMLElement)_window.Document.CreateElement("button");
        addButton.TextContent = "Add";
        SetStyle(addButton, "padding-top", "10px");
        SetStyle(addButton, "padding-right", "30px");
        SetStyle(addButton, "padding-bottom", "10px");
        SetStyle(addButton, "padding-left", "30px");
        SetStyle(addButton, "font-size", "16px");
        SetStyle(addButton, "background-color", "#667eea");
        SetStyle(addButton, "color", "white");
        SetStyle(addButton, "border-style", "none");
        SetStyle(addButton, "border-top-left-radius", "5px");
        SetStyle(addButton, "border-top-right-radius", "5px");
        SetStyle(addButton, "border-bottom-right-radius", "5px");
        SetStyle(addButton, "border-bottom-left-radius", "5px");
        SetStyle(addButton, "cursor", "pointer");
        inputContainer.AppendChild(addButton);

        // Todo list container
        _todoList = (HTMLElement)_window.Document.CreateElement("ul");
        SetStyle(_todoList, "list-style-type", "none");
        SetStyle(_todoList, "padding-top", "0");
        SetStyle(_todoList, "padding-right", "0");
        SetStyle(_todoList, "padding-bottom", "0");
        SetStyle(_todoList, "padding-left", "0");
        SetStyle(_todoList, "margin-top", "0");
        SetStyle(_todoList, "margin-right", "0");
        SetStyle(_todoList, "margin-bottom", "0");
        SetStyle(_todoList, "margin-left", "0");
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
            var li = (HTMLElement)_window.Document.CreateElement("li");
            SetStyle(li, "padding-top", "15px");
            SetStyle(li, "padding-right", "15px");
            SetStyle(li, "padding-bottom", "15px");
            SetStyle(li, "padding-left", "15px");
            SetStyle(li, "margin-bottom", "10px");
            SetStyle(li, "background-color", "#f8f9fa");
            SetStyle(li, "border-top-left-radius", "5px");
            SetStyle(li, "border-top-right-radius", "5px");
            SetStyle(li, "border-bottom-right-radius", "5px");
            SetStyle(li, "border-bottom-left-radius", "5px");
            SetStyle(li, "display", "flex");
            SetStyle(li, "justify-content", "space-between");
            SetStyle(li, "align-items", "center");
            SetStyle(li, "transition-property", "background");
            SetStyle(li, "transition-duration", "0.2s");

            var text = (HTMLElement)_window.Document.CreateElement("span");
            text.TextContent = Todos[i];
            SetStyle(text, "flex-grow", "1");
            SetStyle(text, "flex-shrink", "1");
            SetStyle(text, "flex-basis", "0%");
            SetStyle(text, "color", "#333");
            li.AppendChild(text);

            var deleteButton = (HTMLElement)_window.Document.CreateElement("button");
            deleteButton.TextContent = "❌";
            SetStyle(deleteButton, "background-color", "transparent");
            SetStyle(deleteButton, "border-style", "none");
            SetStyle(deleteButton, "font-size", "18px");
            SetStyle(deleteButton, "cursor", "pointer");
            SetStyle(deleteButton, "padding-top", "5px");
            SetStyle(deleteButton, "padding-right", "10px");
            SetStyle(deleteButton, "padding-bottom", "5px");
            SetStyle(deleteButton, "padding-left", "10px");
            deleteButton.AddEventListener("click", new EventListener(_ => RemoveTodo(index)), false);
            li.AppendChild(deleteButton);

            _todoList.AppendChild(li);
        }

        // Show empty state if no todos
        if (Todos.Count == 0)
        {
            var emptyState = (HTMLElement)_window.Document.CreateElement("li");
            emptyState.TextContent = "No tasks yet. Add one above! 🎯";
            SetStyle(emptyState, "padding-top", "30px");
            SetStyle(emptyState, "padding-right", "30px");
            SetStyle(emptyState, "padding-bottom", "30px");
            SetStyle(emptyState, "padding-left", "30px");
            SetStyle(emptyState, "text-align", "center");
            SetStyle(emptyState, "color", "#999");
            SetStyle(emptyState, "font-style", "italic");
            _todoList.AppendChild(emptyState);
        }
    }

    private static void SetStyle(HTMLElement element, string property, string value)
    {
        element.AttributeStyleMap.Set(property, value);
    }
}
