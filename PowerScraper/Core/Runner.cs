using System.Diagnostics;
using System.Text.RegularExpressions;
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
            CoreUtilisation coreUtilisation = CoreUtilisation.Max,
            LogLevel logLevel = LogLevel.Warning)
        {
            Logger.LoggingLevel = logLevel;
            Logger.ToConsole(LogLevel.Debug, $"Logging level: {logLevel.ToString()}");
            Logger.ToConsole(LogLevel.Debug, $"UnitConversion Base: {unitBase.ToString()}");
            Logger.ToConsole(LogLevel.Debug, $"Serialization Format: {serializer.ToString()}");
            Logger.ToConsole(LogLevel.Debug, $"Platform: {PlatformReader.IdentifyPlatform().ToString()}");

            /* Critical program initialization */
            TreeAccessor.MakeTree();
            ThreadingOptions.SetCores(coreUtilisation);
            TransientShell.InitializeRunspace();
            PlatformReader.PlatformInUse = PlatformReader.IdentifyPlatform();
            UnitConversion.BaseUsed = unitBase;
            _serializer = serializer;
        }

        // TODO: Refactor Execute and ExecuteInteractively
        public void Execute(string[] args)
        {
            if (IfHelpArg(args))
                return;
            if (IfBadArg(args).Count > 0)
            {
                var allBadArgs = string.Join(" ", IfBadArg(args));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Received one or more bad argument(s): {allBadArgs}");
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(ExitStatus.BadArgument);
            }

            var collectorDescriptors = ArgParser.ParseCommandLineArguments(args);
            var serializedOutput = AppView.Serialize(_serializer, collectorDescriptors);
            AppView.Display(serializedOutput);
        }

        // TODO: Refactor Execute and ExecuteInteractively
        // ReSharper disable once FunctionNeverReturns
        public void ExecuteInteractively()
        {
            while (true)
            {
                Console.Write("Enter arguments (empty to exit): ");
                var argsInput = Console.ReadLine()?.Split(" ");
                if (argsInput == null || argsInput.First() == "" || argsInput.First().ToLower() == "exit")
                    Environment.Exit(ExitStatus.Success);
                if (IfHelpArg(argsInput))
                    continue;
                if (IfBadArg(argsInput).Count > 0)
                {
                    var allBadArgs = string.Join(" ", IfBadArg(argsInput));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Received one or more bad argument(s): {allBadArgs}");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                var collectorDescriptors = ArgParser.ParseCommandLineArguments(argsInput);
                var serializedOutput = AppView.Serialize(_serializer, collectorDescriptors);
                AppView.Display(serializedOutput);
            }
        }

        private static bool IfHelpArg(IReadOnlyList<string> args)
        {
            if (args.Count != 0 && (args[0] != "--help" || args.Count != 1))
                return false;
            HelpView.VerboseDisplay();
            return true;
        }

        private static List<string> IfBadArg(IEnumerable<string> args)
        {
            var badArgs = new List<string>();

            foreach (var arg in args)
            {
                try
                {
                    TreeAccessor.RootDescriptorNode.FindDescriptor(arg[2..]);
                }
                catch (KeyNotFoundException)
                {
                    badArgs.Add(arg.Trim());
                }
            }

            if (badArgs.Count == 0)
                return new List<string>();

            return badArgs;
        }
    }
}