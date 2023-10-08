using PowerScraper.Core;
using PowerScraper.Core.Utility;
using PowerScraper.Tonsil;
using PowerScraper.Tonsil.AST;
using PowerScraper.Tonsil.AST.Expressions;

namespace PowerScraper
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            // Expression expression = new BinaryExpression(
                // new UnaryExpression(
                    // new Token(TokenType.Minus, "-", null, '-'),
                    // new LiteralExpression(123)),
                // new Token(TokenType.Multiply, "*", null, '*'),
                // new GroupingExpression(
                    // new LiteralExpression(45.67)));
            // Console.WriteLine(new AstPrinter().Print(expression));
            // Environment.Exit(1);
            var _ = new Interpreter(args);

            if (args.Length == 0)
            {
                new Runner(
                    UnitConversion.Bases.Base10,
                    SerializationFormat.Yaml,
                    CoreUtilisation.Max,
                    LogLevel.Debug
                ).ExecuteInteractively();
            }
            else if (args.Length > 0)
            {
                new Runner(
                    UnitConversion.Bases.Base10,
                    SerializationFormat.Yaml,
                    CoreUtilisation.Max,
                    LogLevel.Debug
                ).Execute(args);

                Environment.Exit(ExitStatus.Success);
            }
        }
    }
}