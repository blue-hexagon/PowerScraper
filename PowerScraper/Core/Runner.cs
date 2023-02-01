using System.Diagnostics;
using PowerScraper.Core.Scraping;
using PowerScraper.Core.Scraping.DataStructure;
using PowerScraper.Core.Utility;
using PowerScraper.Core.Utility.OS;
using PowerScraper.Core.View;

namespace PowerScraper.Core
{
    public class Runner
    {
        
        private readonly SerializationFormat _serializer;

        public Runner(
            UnitConversion.Bases unitBase = UnitConversion.Bases.Base2,
            SerializationFormat serializer = SerializationFormat.Json
            ) 
        { 
            Trace.Listeners.Add(new TextWriterTraceListener("errors.log"));
            Trace.AutoFlush = true;

            TreeAccessor.MakeTree();
            TransientShell.InitializeRunspace();

            UnitConversion.BaseUsed = unitBase;
            PlatformReader.PlatformInUse = PlatformReader.IdentifyPlatform();

            _serializer = serializer;
        }

        public void Execute(string[] args)
        {
            IfNoArgs(args);
            IfHelpArg(args);
            IfBadArg(args);
            var collectorDescriptors = ArgParser.ParseCommandLineArguments(args);
            AppView.Display(_serializer, collectorDescriptors);
            Environment.Exit(ExitStatus.Success);
        }


        public void Execute(List<AbstractDescriptor> collectorDescriptors)
        {
            AppView.Display(_serializer, collectorDescriptors);
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
            HelpView.VerboseDisplay();
            Environment.Exit(ExitStatus.Success);
        }
        private void IfBadArg(string[] args)
        {
            foreach (var arg in args)
            {
                try
                {
                    TreeAccessor.RootDescriptorNode.FindDescriptor(arg[2..]);
                }
                catch (KeyNotFoundException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Received at least one (possibly more) bad argument(s): {arg}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Environment.Exit(ExitStatus.BadArgument);
                }
            }
        }

    }
}