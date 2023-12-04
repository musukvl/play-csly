// See https://aka.ms/new-console-template for more information


using MyParsers;
using Newtonsoft.Json;
using sly.parser.generator;

string expression = @" { 
    ""name"" = ""John"", 
    ""age"" = 42 
} ";

var jsonParser = new EbnfJsonGenericParser();
var builder = new ParserBuilder<JsonTokenGeneric, JSon>();
var parserBuildResult = builder.BuildParser(jsonParser, ParserType.EBNF_LL_RECURSIVE_DESCENT, "root");

if (!parserBuildResult.IsOk)
{
    Console.WriteLine("parser construction failed");
    Console.WriteLine(string.Join("\n", parserBuildResult.Errors));
    return;
}

var parser = parserBuildResult.Result;

var parseResult = parser.Parse(expression);



if (!parseResult.IsError) 
{
    Console.WriteLine($"result of <{expression}>  is {JsonConvert.SerializeObject(parseResult.Result, Formatting.Indented)}");
    
}
else
{
    if (parseResult.Errors != null && parseResult.Errors.Any())
    {
        parseResult.Errors.ForEach(error => Console.WriteLine(error.ErrorMessage));
    }
}

Console.WriteLine("Done.");