namespace PowerScraper.Tonsil;

public class Token
{
    public TokenType Type { get; }
    public string Value { get; }
    public int? Line { get; set; }
    public object? Literal { get; }

    public Token(TokenType type, string value, int? line, object? literal = null)
    {
        Type = type;
        Value = value;
        Literal = literal;
        
        Line = line;
    }

    public override string ToString()
    {
        return $"{Type} {Value} {Literal}";
    }
}