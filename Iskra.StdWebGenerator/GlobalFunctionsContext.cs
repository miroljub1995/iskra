using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public class GlobalFunctionsContext
{
    private class Function
    {
        public required GlobalFunctionCallInfo Info { get; init; }

        public string Code { get; set; } = string.Empty;
    }

    private readonly List<Function> _functions = [];

    public string ClassCode
    {
        get
        {
            var functionsCode = string.Join("\n\n", _functions.Select(x => x.Code));

            return $$"""
                     // <auto-generated/>

                     using System.Runtime.InteropServices.JavaScript;

                     namespace Iskra.StdWeb;

                     #nullable enable

                     internal static partial class {{ClassName}}
                     {
                     {{functionsCode.IndentLines(4)}}
                     }
                     """;
        }
    }

    public string ClassName => "GlobalFunctions";

    public GlobalFunctionCallInfo GetGlobalFunctionCallInfo(
        string functionName,
        IReadOnlyList<MyType> parameters,
        MyType? returnParam
    )
    {
        GlobalFunctionCallInfo? info = _functions
            .Select(x => x.Info)
            .SingleOrDefault(x =>
                x.FunctionName == functionName &&
                x.Parameters.SequenceEqual(parameters) &&
                x.ReturnParam == returnParam
            );

        if (info is null)
        {
            info = new(
                Name: $"{CleanupName(functionName)}_{_functions.Count}",
                FunctionName: functionName,
                Parameters: parameters,
                ReturnParam: returnParam
            );

            var func = new Function
            {
                Info = info,
            };

            _functions.Add(func);

            PopulateCode(func);
        }

        return info with { Name = $"{ClassName}.{info.Name}" };
    }

    private static string CleanupName(string functionName) => functionName.Replace('.', '_');

    private static void PopulateCode(Function func)
    {
        var returnTypeName = func.Info.ReturnParam is null ? "void" : TypeNameGenerator.Execute(func.Info.ReturnParam);

        var jsImportParameters = func.Info.Parameters.Select((x, i) =>
            $"{GetMarshallAttributeIfNeeded(x)}{TypeNameGenerator.Execute(x)} arg{i}");

        var jsImportParametersList = string.Join(", ", jsImportParameters);

        var code =
            $$"""
              [JSImport("globalThis.{{func.Info.FunctionName}}")]
              public static partial {{returnTypeName}} {{func.Info.Name}}({{jsImportParametersList}});
              """;

        func.Code = code;
    }

    private static string GetMarshallAttributeIfNeeded(MyType type)
    {
        if (type.Type == typeof(ObjectForJS))
        {
            return "[JSMarshalAs<JSType.Any>] ";
        }

        return "";
    }
}