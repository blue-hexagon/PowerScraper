using PowerScraper.Core;
using PowerScraper.Core.Utility;

namespace PowerScraper
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            // Base2 is the default, but if you wish you can use base10.
            UnitConversion.BaseUsed = UnitConversion.Bases.Base10;

            new Runner(args: args, formatting: OutputFormat.Json);

            // var collectors = new List<CollectorDescriptor>( { new CpuDescriptor() };
            // new Runner(collectorDescriptors: collectors, formatting: OutputFormat.Yaml);
        }
    }
}