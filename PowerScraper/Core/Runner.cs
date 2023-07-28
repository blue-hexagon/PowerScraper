using System.Diagnostics;
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
            SerializationFormat serializer = SerializationFormat.Json,
            LogLevel logLevel = LogLevel.Warning)
        {
            Logger.LoggingLevel = logLevel;

            /* Critical program initialization */
            TreeAccessor.MakeTree();
            TransientShell.InitializeRunspace();


            UnitConversion.BaseUsed = unitBase;
            PlatformReader.PlatformInUse = PlatformReader.IdentifyPlatform();

            _serializer = serializer;
        }

        public void Execute(string[] args)
        {
            // IfNoArgs(args);
            if (IfHelpArg(args))
                return;
            IfBadArg(args);
            var collectorDescriptors = ArgParser.ParseCommandLineArguments(args);
            var serializedOutput = AppView.Serialize(_serializer, collectorDescriptors);
            AppView.Display(serializedOutput);
            // Environment.Exit(ExitStatus.Success);
        }

        private static bool IfHelpArg(IReadOnlyList<string> args)
        {
            if (args.Count != 0 && (args[0] != "--help" || args.Count != 1))
                return false;
            HelpView.VerboseDisplay();
            return true;
            // Environment.Exit(ExitStatus.Success);
        }

        // private static void IfNoArgs(IReadOnlyCollection<string> args)
        // {
        // if (args.Count != 0) return;
        // HelpView.VerboseDisplay();
        // Environment.Exit(ExitStatus.Success);
        // }

        private static void IfBadArg(IEnumerable<string> args)
        {
            var badArgs = new List<string>();

            foreach (var arg in args)
            {
                try
                {
                    TreeAccessor.RootDescriptorNode.FindDescriptor(arg[2..]);
                }
                catch (KeyNotFoundException e)
                {
                    badArgs.Add(arg);
                }
            }

            if (badArgs.Count == 0) return;

            var allBadArgs = string.Join(" ", badArgs);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Received one or more bad argument(s): {allBadArgs}");
            Console.ForegroundColor = ConsoleColor.White;
            Environment.Exit(ExitStatus.BadArgument);
        }
    }
}