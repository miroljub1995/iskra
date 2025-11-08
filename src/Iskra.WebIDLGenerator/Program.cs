using System.CommandLine;
using System.Text.Json;
using Iskra.WebIDLGenerator.Commands;
using Iskra.WebIDLGenerator.Models;



RootCommand rootCommand = new("WebIDL Generator");
rootCommand.Subcommands.Add(new GenerateCommand());

return await rootCommand.Parse(args).InvokeAsync();