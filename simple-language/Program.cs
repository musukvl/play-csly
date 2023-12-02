// See https://aka.ms/new-console-template for more information


using MyParsers;

string expression = "42  + 42 - 7";

var parser = MyFirstParser.GetParser();
var parseResult = parser.Parse(expression);



if (!parseResult.IsError) 
{
    Console.WriteLine($"result of <{expression}>  is {(int)parseResult.Result}");
    // outputs : result of <42 + 42>  is 84"
}
else
{
    if (parseResult.Errors != null && parseResult.Errors.Any())
    {
        // display errors
        parseResult.Errors.ForEach(error => Console.WriteLine(error.ErrorMessage));
    }
}

Console.WriteLine("Hello, World!");