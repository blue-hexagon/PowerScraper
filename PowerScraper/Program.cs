using PowerScraper.Core;
using PowerScraper.Core.Utility;

namespace PowerScraper
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                while (true)
                {
                    Console.Write("Enter arguments (empty to exit): ");
                    var argsInput = Console.ReadLine()?.Split(" ");
                    if (argsInput == null || argsInput.First() == "")
                        Environment.Exit(ExitStatus.Success);
                    Console.Write(argsInput.First());

                    new Runner(
                        UnitConversion.Bases.Base10,
                        SerializationFormat.Yaml,
                        LogLevel.Debug
                    ).Execute(argsInput);
                }
            }

            new Runner(
                UnitConversion.Bases.Base10,
                SerializationFormat.Yaml,
                LogLevel.Debug
            ).Execute(args);

            Environment.Exit(ExitStatus.Success);
        }
    }
}