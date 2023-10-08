using System.Management.Automation;
using PowerScraper.Tonsil.Error;
using System.Text.RegularExpressions;

namespace PowerScraper.Tonsil;

public class TonsilLexer
{
    private readonly List<Token> _tokens = new();
    private string _programInput = "";

    /* All string index tracking is kept zero-indexed
     * ScannerLine: The line of the source file we are at
     * LineColumnStart: The start of the character we are at, on the current ScannerLine
     * LineColumnEnd: The end of the character we are at (non inclusive), on the current ScannerLine
     * StreamColumn: The index of the last character of the lexeme, of the flattened string index we are at.
                     Flattened as in 'it's one long string without linebreaks'. Also non-inclusive. */
    private int _streamColumn;

    private int _scannerLine;
    private int _lineColumnStart;
    private int _lineColumnEnd;

    /* RegEx list for lexemes, paired with their respective TokenType */
    private readonly List<(Regex regex, TokenType type)> _tokenPatterns = new()
    {
        /* Non-Significant Tokens */
        (new Regex(@"\r\n|\n|\r"), TokenType.NewLine),
        (new Regex(@"\s+"), TokenType.EmptySpace),
        (new Regex(@"\/\*+(?s:.*?)\*+\/"), TokenType.MultilineComment),
        (new Regex(@"#+.*|\/\/.*|\-\-.*"), TokenType.SingleLineComment),

        /* Special tokens */
        (new Regex("{:(?s:.*?):}"), TokenType.Script),
        (new Regex(@"\[:.*:\]"), TokenType.ListComprehension),
        (new Regex(@"arg_(?=\d{1,})\d{1,}|arg_(?=\S+)\S+|arg"),
            TokenType.Argument), /* Named Arguments; name ::= arg_<digit|digits> | arg_<alfa_word> */
        (new Regex(@","), TokenType.Comma),
        (new Regex(@"\."), TokenType.Dot),
        (new Regex(@"::"), TokenType.DoubleColon),
        (new Regex(@"<~"), TokenType.SquigglyArrow),

        /* Compound Assignment Operator Tokens */
        (new Regex(@"\+="), TokenType.PlusAssignment),
        (new Regex(@"-="), TokenType.MinusAssignment),
        (new Regex(@"\/="), TokenType.DivideAssignment),
        (new Regex(@"\*="), TokenType.MultiplyAssignment),
        (new Regex(@"=="), TokenType.EqualEqual),
        (new Regex(@"!="), TokenType.BangEqual),
        (new Regex(@"<="), TokenType.LessEqual),
        (new Regex(@">="), TokenType.GreaterEqual),

        /* Arithmetic Operator Tokens */
        (new Regex(@"\+"), TokenType.Plus),
        (new Regex(@"-"), TokenType.Minus),
        (new Regex(@"\/"), TokenType.Divide),
        (new Regex(@"\*"), TokenType.Multiply),
        (new Regex(@"%"), TokenType.Modulo),
        (new Regex(@"="), TokenType.Equal),
        (new Regex(@"!"), TokenType.Bang),
        (new Regex(@"<"), TokenType.Less),
        (new Regex(@">"), TokenType.Greater),

        /* Grouping Tokens */
        (new Regex(@"\("), TokenType.LeftParenthesis),
        (new Regex(@"\)"), TokenType.RightParenthesis),
        (new Regex(@"\["), TokenType.LeftBrace),
        (new Regex(@"]"), TokenType.RightBrace),
        (new Regex(@"\{"), TokenType.LeftBracket),
        (new Regex(@"\}"), TokenType.RightBracket),

        /* Literal Tokens */
        (new Regex("\".*?\""), TokenType.String),
        (new Regex(@"-?\d+(\.\d+)?"), TokenType.Number),
        (new Regex(@"yes|true"), TokenType.True),
        (new Regex(@"no|false"), TokenType.False),
        (new Regex(@"absent|nil"), TokenType.Nil),

        /* Keywords */
        (new Regex(@"YAMLScalar"), TokenType.K_YamlScalar),
        (new Regex(@"YAMLSequence"), TokenType.K_YamlSequence),
        (new Regex(@"YAMLSequenceInline"), TokenType.K_YamlSequenceInline),
        (new Regex(@"YAMLMap"), TokenType.K_YamlMap),
        (new Regex(@"YAMLMapInline"), TokenType.K_YamlMapInline),
        (new Regex(@"path"), TokenType.K_Path),
        (new Regex(@"script"), TokenType.K_Script),
        (new Regex(@"tool"), TokenType.K_Tool),
        (new Regex(@"field_delimiter"), TokenType.K_FieldDelimiter),
        (new Regex(@"vars"), TokenType.K_Vars),
        (new Regex(@"powershell"), TokenType.K_PowerShell),
        (new Regex(@"bash"), TokenType.K_Bash),
        (new Regex(@"subprocess"), TokenType.K_Subprocess),
        (new Regex(@"seperated"), TokenType.K_Seperated),
        (new Regex(@"by"), TokenType.K_By),

        /* Variable Identifier */
        (new Regex(@"\w+"), TokenType.Identifier),

        // Catch anything else that slid through, as an error
        (new Regex(@".*"), TokenType.LexerError)
    };

    /**
     * Iterate over the programs input characters and add the tokens to _tokens
     * If a token is recognized as an EmptySpace token, continue
     * If a token is recognized a LexerError throw an error
     * If a token is recognized as a ScannerNewLine token, increment the line counter _scannerLine
     */
    public List<Token> ScanTokens(string programInput)
    {
        _programInput = programInput;
        while (_streamColumn < _programInput.Length)
        {
            var token = NextToken();
            if (token.Type is TokenType.EmptySpace)
                continue;
            if (token.Type is TokenType.LexerError)
                throw new LexingException($"Got an unexpected token: {token.Value} at line: {token.Line}");
            if (token.Type == TokenType.NewLine)
                _scannerLine += 1;
            else
                _tokens.Add(token);
        }

        _tokens.Add(new Token(TokenType.Eof, "", _scannerLine));
        _streamColumn = 0;
        _scannerLine = 0;
        _lineColumnStart = 0;
        _lineColumnEnd = 0;
        return _tokens;
    }

    private Token NextToken(bool printTokens = true)
    {
        foreach (var (regex, tokenType) in _tokenPatterns)
        {
            object? tokenLiteral = null;
            var match = regex.Match(_programInput, _streamColumn);
            if (match.Success && match.Index == _streamColumn)
            {
                _streamColumn += match.Length;
                _lineColumnStart = _lineColumnEnd;
                _lineColumnEnd += match.Length;

                var tokenValue = tokenType == TokenType.NewLine ? "\\n" : match.Value;
                if (tokenType == TokenType.String)
                    tokenLiteral = match.Value.Substring(1, match.Value.Length - 2);
                if (printTokens) PrintToken(tokenType, tokenValue, tokenLiteral, printNonMeaningfulLTokens: false);
                if (tokenType == TokenType.NewLine)
                    _lineColumnEnd = 0;
                return new Token(tokenType, match.Value, _scannerLine, tokenLiteral);
            }
        }

        throw new RuntimeException($"Uncaught token. Check the Lexers token regex list - it should have a catch all regex at the end.");
    }

    /* Prints info about the token: token-type, string-index boundaries, value and literal value */
    private void PrintToken(TokenType tokenType, string tokenValue, object? tokenLiteral, bool printNonMeaningfulLTokens)
    {
        if (printNonMeaningfulLTokens == false)
            if (tokenType is TokenType.NewLine or TokenType.EmptySpace or TokenType.SingleLineComment or TokenType.MultilineComment)
                return;
        tokenLiteral ??= new string("null");

        var line = _scannerLine.ToString().PadRight(4);
        var lineColumnEnd = _lineColumnEnd.ToString().PadRight(4);
        var lineColumnStart = _lineColumnStart.ToString().PadLeft(4);
        var streamColumn = _streamColumn.ToString().PadLeft(4);
        var type = tokenType.ToString().PadRight(18);

        var literal = tokenLiteral.ToString()![..Math.Clamp(tokenLiteral.ToString()!.Length, 1, 13)];
        if (literal.Length >= 13) literal = literal.PadRight(16, '.');
        literal = literal.PadRight(16);

        var linePositionType = $"[{streamColumn} @ L{line}:{lineColumnStart}-{lineColumnEnd} - {type}] Literal: {literal} Value: ".PadRight(25);
        var linePositionTypeValue = linePositionType + tokenValue.PadRight(30);
        var linePositionTypeValueLiteral = $"{linePositionTypeValue}";
        var lexedToken = linePositionTypeValueLiteral[..Math.Clamp(linePositionTypeValueLiteral.Length, 0, Console.WindowWidth - 4)];
        if (lexedToken.Length == Console.WindowWidth - 4)
            lexedToken += "...";
        Console.WriteLine(lexedToken);
    }
}