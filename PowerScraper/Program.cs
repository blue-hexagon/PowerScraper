using PowerScraper.Core;
using PowerScraper.Core.Utility;
using System.Runtime.InteropServices;

namespace PowerScraper
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var runner = new Runner(serializer: SerializationFormat.Json);
            runner.Execute(args: args);

            // var collectors = new List<CollectorDescriptor>( { new CpuDescriptor() };
            // new Runner(collectorDescriptors: collectors, formatting: OutputFormat.Yaml);
        }
    }
}