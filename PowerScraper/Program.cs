using PowerScraper.Core;
using PowerScraper.Core.Utility;
using System.Data.Sql;
using PowerScraper.Core.Utility.OS;
using PowerScraper.Tonsil;

namespace PowerScraper
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            // LexerTester.Test();
            // ExitMessage.Write("Success");
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