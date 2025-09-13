// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using Iskra.WebIDLGenerator.Models;


var baseDir = AppDomain.CurrentDomain.BaseDirectory;


var webrefParsedRootDir = Path.GetFullPath(Path.Combine(baseDir, "../../../../submodules/webref/curated/ed/idlparsed"));
var htmlModulePath = Path.Combine(webrefParsedRootDir, "html.json");
var htmlModuleContent = await File.ReadAllTextAsync(htmlModulePath);

var htmlModule =
    JsonSerializer.Deserialize(htmlModuleContent, typeof(IDLModule), WebIdlJsonContext.Default) as IDLModule;

Console.WriteLine("Hello, World!");