using Iskra.WebIDLGenerator.Extensions;
using Iskra.WebIDLGenerator.Models;

namespace Iskra.WebIDLGenerator.Generators;

public class AttributeMemberTypeGenerator(
    IDLTypeDescriptionToTypeGenerator descriptionToTypeGenerator
)
{
    public string Generate(AttributeMemberType input)
    {
        List<string> bodyParts = [];

        var isStatic = input.Special == AttributeSpecial.Static;
        var staticKeyword = isStatic ? " static" : "";

        var returnType = descriptionToTypeGenerator.Generate(input.IdlType);

        var getter = $$"""
                       get
                       {
                           throw new Exception();
                       }
                       """;

        bodyParts.Add(getter);

        if (!input.Readonly)
        {
            var setter = $$"""
                           set
                           {
                               throw new Exception();
                           }
                           """;

            bodyParts.Add(setter);
        }

        var body = string.Join("\n", bodyParts);

        var content = $$"""
                        public{{staticKeyword}} {{returnType}} {{input.Name.Replace('-', '_').CapitalizeFirstLetter()}}
                        {
                        {{body.IndentLines(4)}}
                        }
                        """;

        return content;
    }
}