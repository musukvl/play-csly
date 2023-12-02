using sly.lexer;

namespace MyParsers;

public enum ExpressionToken {

    //[Lexeme("[0-9]+")]
    [Lexeme("[0-9]+")]
    INT = 1,

    [Lexeme("\\+")] 
    PLUS = 2,
    
    [Lexeme("\\-")] 
    MINUS = 3,

    [Lexeme("[ \\t]+", isSkippable:true)] // the lexeme is marked isSkippable : it will not be sent to the parser and simply discarded.
    WS = 40 

}