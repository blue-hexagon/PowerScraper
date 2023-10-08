namespace PowerScraper.Tonsil;

public class Parser
{
    private readonly List<Token> _tokens;
    private int _position;

    public Parser(List<Token> tokens)
    {
        _tokens = tokens;
        _position = 0;
    }

    public void Parse()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        while (_position < _tokens.Count)
        {
            if (_position < _tokens.Count)
            {
                var currentToken = _tokens[_position];
                if (currentToken.Type == TokenType.SingleLineComment || currentToken.Type == TokenType.MultilineComment)
                {
                _position++;
                    continue;
                }
                if (currentToken.Type == TokenType.LineTerminator)
                    Console.WriteLine(currentToken.Value);
                else
                    Console.Write(currentToken.Value + " ");
                _position++;
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine();
        Console.WriteLine("Parsing finished.");
    }
}