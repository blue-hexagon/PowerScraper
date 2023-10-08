namespace PowerScraper.Tonsil;

//@formatter:off
// ReSharper disable always UnusedMember.Local

public enum TokenType
{
    Identifier, Script, Argument, 
    DoubleColon, SquigglyArrow,
    
    LineTerminator, Comma, Dot,
    SingleLineComment, MultilineComment,
    
    LeftParenthesis, RightParenthesis, 
    LeftBrace, RightBrace,
    LeftBracket, RightBracket,
    
    Bang, BangEqual,
    Equal, EqualEqual,
    Greater, GreaterEqual,
    Less, LessEqual,
    Plus, Minus, Divide, Multiply, Modulo,
    PlusAssignment, MinusAssignment, DivideAssignment, MultiplyAssignment,
    
    String, Number, False, True, Nil,
    K_YamlScalar, K_YamlSequence, K_YamlSequenceInline, K_YamlMap, K_YamlMapInline,
    
    // Class, Fun, For, If, Elif, Else, And, Or,
    // Return, Super, This,  Var,
    Print, Log, Debug,
    K_Path, K_Script, K_Tool, K_FieldDelimiter, K_Vars, K_After, K_Seperated, K_By,
    K_PowerShell, K_Bash, K_Subprocess,
    
    // Special debugging and troubleshooting tokens.
    Eof, LexerError, NewLine, ListComprehension, EmptySpace
}
//@formatter:on