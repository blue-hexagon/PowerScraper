using System.Text.Json;
using Newtonsoft.Json;
using Pastel;
using PowerScraper.Core;
using PowerScraper.Core.Utility;
using PowerScraper.Core.Scraping.DataStructure;
using PowerScraper.Core.Serializers;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using System.Diagnostics;
using System.Text.Json;
using PowerScraper.Core.Scraping.Module.Hardware.Cpu;
using PowerScraper.Core.Scraping.Module.System.Computer;

namespace PowerScraper
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            new Runner(UnitConversion.Bases.Base10, SerializationFormat.Yaml).Execute(args);
            
            //var runner = new Runner(serializer: SerializationFormat.Json);
            //runner.Execute(args: args);


            //
            //TestProgram.TestEnumerator();
            //TestProgram.TestYamlSerializer();
            //TestProgram.TestRootTraverser();

            //Environment.Exit(0);

            //TestProgram.TestJsonSerializer();

            // var collectors = new List<DescriptorNode> { new CpuDescriptor(), new ComputerDescriptor() };
        }
    }
}