using PowerScraper.Core;
using PowerScraper.Core.Utility;

namespace PowerScraper
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Runner(args: args, formatting: OutputFormat.Json);

            // ReSharper disable once ObjectCreationAsStatement
            // var collectors = new List<CollectorDescriptor>( { new CpuDescriptor() };
            // new Runner(collectorDescriptors: collectors, formatting: OutputFormat.Yaml);
        }
    }
}