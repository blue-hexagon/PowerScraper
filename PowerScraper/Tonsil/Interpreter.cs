using PowerScraper.Core.Utility.OS;

namespace PowerScraper.Tonsil;

public class Interpreter
{
    private readonly TonsilLexer _lexer = new();
    private bool _hadError;

    public Interpreter(IReadOnlyList<string> args)
    {
        if (args == null || args[0] != "--tonsil-prompt" && args[0] != "--tonsil-test-file")
            return;
        switch (args[0])
        {
            case "--tonsil-test-file":
                StartInterpreter();
                break;
            case "--tonsil-prompt":
                StartInterpreter(null);
                break;
        }

        ExitMessage.Write("Success");
    }

    private void StartInterpreter()
    {
        StartInterpreter(new[] { @"C:\Users\Tobias\Desktop\PowerScraper\PowerScraper\PowerScraper\Tonsil\resource\test-input.txt" });
    }

    private void StartInterpreter(IReadOnlyList<string>? args)
    {
        if (args == null)
            RunPrompt();
        else if (args.Count == 1)
            RunFile(args[0]);
        else if (args.Count > 1)
        {
            Console.WriteLine("Usage: tonsil [script]");
            Environment.Exit(64); // https://man.freebsd.org/cgi/man.cgi?query=sysexits&apropos=0&sektion=0&manpath=FreeBSD+4.3-RELEASE&format=html
        }
    }


    private void RunFile(string filePath)
    {
        var inputStream = ParseFileToString(filePath);
        Run(inputStream);
        if (_hadError)
            Environment.Exit(65);
    }

    private void RunPrompt()
    {
        var inputReader = new StreamReader(Console.OpenStandardInput());
        var reader = new StreamReader(inputReader.BaseStream);
        while (true)
        {
            Console.Write("> ");
            var line = reader.ReadLine();
            if (line == null) break;
            Run(line);
            _hadError = false;
        }

        reader.Close();
        if (_hadError)
            Environment.Exit(65);
    }

    private void Run(string inputStream)
    {
        var tokens = _lexer.ScanTokens(inputStream);
        new Parser(tokens).Parse();
    }

    // ReSharper disable once UnusedMember.Local
    private void Error(int line, string message)
    {
        Report(line, "", message);
    }

    private void Report(int line, String where, string message)
    {
        Console.WriteLine($"[line {line}] Error {where}: {message}");
        _hadError = true;
    }

    private static string ParseFileToString(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var allLines = String.Join("\r\n", lines);
        Console.WriteLine(allLines);

        return allLines;
    }
}