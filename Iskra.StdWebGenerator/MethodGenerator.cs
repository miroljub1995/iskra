using System.Reflection;
using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebGenerator;

public static class MethodGenerator
{
    public static string Execute(MethodInfo methodInfo)
    {
        var isManualBinding = methodInfo.IsDefined(typeof(ManualBindingAttribute));
        var returnType = TypeNameGenerator.Execute(methodInfo.ReturnType, methodInfo.ReturnTypeCustomAttributes);
        var staticKeyword = methodInfo.IsStatic ? " static" : "";
        var name = methodInfo.Name;
        var genericDef = MethodGenericDefinitionGenerator.Execute(methodInfo);
        var parameters = MethodParametersGenerator.Execute(methodInfo);

        if (isManualBinding)
        {
            var res = $$"""
                        public{{staticKeyword}} partial {{returnType}} {{name}}{{genericDef}}({{parameters.Content}});
                        """;

            return res;
        }
        else
        {
            var methodName = JSPropertyNameGenerator.Execute(methodInfo);

            var res = $$"""
                        public{{staticKeyword}} {{returnType}} {{name}}{{genericDef}}({{parameters.Content}})
                        {
                            if (!JSObject.HasProperty("{{methodName}}"))
                            {
                                throw new Exception($"Method {{methodName}} is not defined.");
                            }
                        
                            if (JSObject.GetTypeOfProperty("{{methodName}}") != "function")
                            {
                                throw new Exception($"Property {{methodName}} is not a function.");
                            }
                        
                            var method = JSObject.GetPropertyAsJSObject("{{methodName}}")
                                         ?? throw new Exception("Should be handled before.");
                        
                            Reflect.Apply(method, JSObject, args);
                        }
                        """;

            return res;
        }
    }
}