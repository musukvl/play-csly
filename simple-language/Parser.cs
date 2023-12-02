using sly.lexer;
using sly.parser;
using sly.parser.generator;

namespace MyParsers;

public class MyFirstParser
{
    public static Parser<ExpressionToken,int> GetParser() {

        var parserInstance = new ExpressionParser();
        var builder = new ParserBuilder<ExpressionToken, int>();
        var Parser = builder.BuildParser(parserInstance, ParserType.LL_RECURSIVE_DESCENT, "expression").Result;

        return Parser;
    }
}

public class ExpressionParser
{
    [Production("expression: INT")]
    public int intExpr(Token<ExpressionToken> intToken)
    {
        return intToken.IntValue;
    }

    [Production("expression: term PLUS expression")]
    public int Expression(int left, Token<ExpressionToken> operatorToken, int right) {
        return left + right;
    }
    
    [Production("expression: term MINUS expression")]
    public int Expression1(int left, Token<ExpressionToken> operatorToken, int right) {
        return left - right;
    }

    [Production("term: INT")]
    public int Expression(Token<ExpressionToken> intToken) {
        return intToken.IntValue;
    }
}