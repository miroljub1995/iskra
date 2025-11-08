using Iskra.WebIDLGenerator.Extensions;
using Iskra.WebIDLGenerator.Models;
using Iskra.WebIDLGenerator.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Iskra.WebIDLGenerator.Generators;

public class OperationMemberTypeGenerator(
    IServiceProvider provider
)
{
    public string Generate(OperationMemberType input, string containingTypeName)
    {
        var argsArrayGenerator = provider.GetRequiredService<ArgumentsToArgsArrayGenerator>();
        var descriptionToTypeDeclarationGenerator =
            provider.GetRequiredService<IDLTypeDescriptionToTypeDeclarationGenerator>();
        var argumentsToDeclarationGenerator = provider.GetRequiredService<ArgumentsToDeclarationGenerator>();
        var propertyAccessorGenerator = provider.GetRequiredService<PropertyAccessorGenerator>();

        var isStatic = input.Special == OperationSpecial.Static;
        var staticKeyword = isStatic ? " static" : "";
        var isEmpty = input.Arguments.Count == 0;
        var isVoid = input.IdlType is SingleTypeDescription { IdlType: BuiltinTypes.Undefined };
        var isEmptyGetter = string.IsNullOrEmpty(input.Name) && input.Special == OperationSpecial.Getter;
        var isEmptySetter = string.IsNullOrEmpty(input.Name) && input.Special == OperationSpecial.Setter;
        var isEmptyDeleter = string.IsNullOrEmpty(input.Name) && input.Special == OperationSpecial.Deleter;

        var name = input.Name.Replace('-', '_').CapitalizeFirstLetter();
        if (name == containingTypeName)
        {
            name += "_";
        }

        if (isEmptyGetter)
        {
            name = "Get";
        }
        else if (isEmptySetter)
        {
            name = "Set";
        }
        else if (isEmptyDeleter)
        {
            name = "Delete";
        }

        if (name == string.Empty)
        {
            name += "_";
        }

        var inputVar = isStatic
            ? "global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsConstructorProxy" +
              $"(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, \"{containingTypeName}\")"
            : "JSObject";

        var returnTypeDeclaration =
            isVoid || input.IdlType is null ? "void" : descriptionToTypeDeclarationGenerator.Generate(input.IdlType);

        var args = argumentsToDeclarationGenerator.Generate(input.Arguments);

        var argVars = input.Arguments
            .Select(x => x.ValidCSharpName)
            .ToList();

        List<string> bodyStatements = [];

        using (VariableName.CreateScope())
        {
            var argsArrayVar = VariableName.Current.GetNext("argsArray");
            var resOwnerVar = VariableName.Current.GetNext("resOwner");

            if (!isEmpty)
            {
                bodyStatements.Add(argsArrayGenerator.Generate(
                    args: input.Arguments,
                    argVars: argVars,
                    argsArrayVar: argsArrayVar
                ));
            }

            if (!isVoid)
            {
                bodyStatements.Add(
                    $"using global::Iskra.JSCore.FunctionResPool.Owner {resOwnerVar} = global::Iskra.JSCore.FunctionResPool.Shared.Rent();");
            }

            if (isEmptyGetter)
            {
                bodyStatements.Add(
                    $"global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallGetter({inputVar}, {argsArrayVar}.JSObject, {resOwnerVar}.JSObject);");
            }
            else if (isEmptySetter)
            {
                bodyStatements.Add(
                    $"global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallSetter({inputVar}, {argsArrayVar}.JSObject);");
            }
            else if (isEmptyDeleter)
            {
                bodyStatements.Add(
                    $"global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallDeleter({inputVar}, {argsArrayVar}.JSObject);");
            }
            else if (isEmpty)
            {
                if (isVoid)
                {
                    bodyStatements.Add(
                        $"global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyVoidFunctionProperty({inputVar}, \"{input.Name}\", {inputVar});");
                }
                else
                {
                    bodyStatements.Add(
                        $"global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyNonVoidFunctionProperty({inputVar}, \"{input.Name}\", {inputVar}, {resOwnerVar}.JSObject);");
                }
            }
            else
            {
                if (isVoid)
                {
                    bodyStatements.Add(
                        $"global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyVoidFunctionProperty({inputVar}, \"{input.Name}\", {inputVar}, {argsArrayVar}.JSObject);");
                }
                else
                {
                    bodyStatements.Add(
                        $"global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyNonVoidFunctionProperty({inputVar}, \"{input.Name}\", {inputVar}, {argsArrayVar}.JSObject, {resOwnerVar}.JSObject);");
                }
            }

            if (!isVoid && input.IdlType is not null)
            {
                var returnType = descriptionToTypeDeclarationGenerator.Generate(input.IdlType);
                var resPropertyAccessor = propertyAccessorGenerator.GetOrCreateAccessor(input.IdlType);

                bodyStatements.Add(
                    $$"""
                      // Return Value
                      return global::Iskra.JSCore.Generics.PropertyAccessor.Get<{{returnType}}, {{resPropertyAccessor}}>({{resOwnerVar}}.JSObject, "value");
                      """
                );
            }
        }

        var body = string.Join("\n\n", bodyStatements);

        var content = $$"""
                        public{{staticKeyword}} {{returnTypeDeclaration}} {{name}}({{args}})
                        {
                        {{body.IndentLines(4)}}
                        }
                        """;

        return content;
    }
}