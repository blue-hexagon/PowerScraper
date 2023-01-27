using System.Diagnostics;
using PowerScraper.Core.Configuration;
using PowerScraper.Core.Scraping.Module;
using PowerScraper.Core.Scraping.Module.Hardware.Cpu;
using PowerScraper.Core.Utility;
using PowerScraper.Core.View;

namespace PowerScraper.Core
{
    public class Runner
    {
        private Runner()
        {
            ConfigurationInitializer.InitializeAndConnectDescriptors();
            TransientShell.InitializeRunspace();
            Trace.Listeners.Add(new TextWriterTraceListener("errors.log"));
            Trace.AutoFlush = true;
        }

        public Runner(string[] args, OutputFormat formatting = OutputFormat.Yaml)
            : this()
        {
            IfNoArgs(args);
            IfHelpArg(args);
            var collectorDescriptors = CommandLineParser.ParseCommandLineArguments(args);
            AppView.Display(formatting, collectorDescriptors);
            Environment.Exit(ExitStatus.Success);
        }

        public Runner(List<CollectorDescriptor> collectorDescriptors, OutputFormat formatting = OutputFormat.Yaml)
            : this()
        {
            collectorDescriptors.AddRange(new List<CollectorDescriptor>()
            {
                // /* Insert the collector descriptors here! */
                //TODO: Fix so we can call the collectors directly from the Program static main function
                new CpuDescriptor()
            });

            AppView.Display(formatting, collectorDescriptors);
            Environment.Exit(ExitStatus.Success);
        }

        private static void IfHelpArg(IReadOnlyList<string> args)
        {
            if (args.Count != 0 && (args[0] != "--help" || args.Count != 1)) return;
            HelpView.VerboseDisplay();
            Environment.Exit(ExitStatus.Success);
        }

        private static void IfNoArgs(IReadOnlyCollection<string> args)
        {
            if (args.Count != 0) return;
            HelpView.BriefDisplay();
            Environment.Exit(ExitStatus.Success);
        }
    }
}