using PowerScraper.Core;
using PowerScraper.Core.Utility;
using System.Data.Sql;

namespace PowerScraper
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                new Runner(
                    UnitConversion.Bases.Base10,
                    SerializationFormat.Yaml,
                    CoreUtilisation.Medium,
                    LogLevel.Debug
                ).ExecuteInteractively();
            }
            else if (args.Length > 0)
            {
                new Runner(
                    UnitConversion.Bases.Base10,
                    SerializationFormat.Yaml,
                    CoreUtilisation.Medium,
                    LogLevel.Debug
                ).Execute(args);

                Environment.Exit(ExitStatus.Success);
            }
        }
    }
}