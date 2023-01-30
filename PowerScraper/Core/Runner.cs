using System.Diagnostics;
using System.Runtime.InteropServices;
using PowerScraper.Core.Configuration;
using PowerScraper.Core.Scraping.Module;
using PowerScraper.Core.Scraping.Module.Hardware.Cpu;
using PowerScraper.Core.Utility;
using PowerScraper.Core.Utility.OS;
using PowerScraper.Core.View;

namespace PowerScraper.Core
{
    public class Runner
    {
        private readonly SerializationFormat serializer;

        public Runner(UnitConversion.Bases unitBase = UnitConversion.Bases.Base2,
            SerializationFormat serializer = SerializationFormat.Json)
        {
            ConfigurationInitializer.InitializeAndConnectDescriptors();
            TransientShell.InitializeRunspace();
            Trace.Listeners.Add(new TextWriterTraceListener("errors.log"));
            Trace.AutoFlush = true;
            UnitConversion.BaseUsed = unitBase;
            this.serializer = serializer;
            PlatformReader.PlatformInUse = PlatformReader.IdentifyPlatform();
        }

        public void Execute(string[] args)
        {
            IfNoArgs(args);
            IfHelpArg(args);
            var collectorDescriptors = CommandLineParser.ParseCommandLineArguments(args);
            AppView.Display(serializer, collectorDescriptors);
            Environment.Exit(ExitStatus.Succes);
        }

        public void Execute(List<CollectorDescriptor> collectorDescriptors)
        {
            collectorDescriptors.AddRange(new List<CollectorDescriptor>()
            {
                // /* Insert the collector descriptors here! */
                //TODO: Fix so we can call the collectors directly from the Program static main function
                new CpuDescriptor()
            });

            AppView.Display(serializer, collectorDescriptors);
            Environment.Exit(ExitStatus.Succes);
        }

        private static void IfHelpArg(IReadOnlyList<string> args)
        {
            if (args.Count != 0 && (args[0] != "--help" || args.Count != 1)) return;
            HelpView.VerboseDisplay();
            Environment.Exit(ExitStatus.Succes);
        }

        private static void IfNoArgs(IReadOnlyCollection<string> args)
        {
            if (args.Count != 0) return;
            HelpView.BriefDisplay();
            Environment.Exit(ExitStatus.Succes);
        }
    }
}