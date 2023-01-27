using System;
using System.Collections.Generic;
using System.Linq;
using PowerScraper.Core.Scraping;
using PowerScraper.Core.Scraping.Module;
using PowerScraper.Core.Utility;

namespace PowerScraper.Core
{
    public static class CommandLineParser
    {
        /** Parses the command line arguments and returns the corresponding collectors, or null. */
        public static List<CollectorDescriptor> ParseCommandLineArguments(string[] cliArguments)
        {
            if (cliArguments.Length == 0)
                return null;

            var collectors = new List<CollectorDescriptor>();
            foreach (var arg in cliArguments)
            {
                try
                {
                    collectors.Add(DescriptorController.GetCollectorFromCliArg(arg));
                }
                catch (KeyNotFoundException)
                {
                    try
                    {
                        collectors.AddRange(DescriptorController.GetCategoryFromCliArg(arg).Collectors);
                    }
                    catch (KeyNotFoundException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Received at least one (possibly more) bad argument(s): {arg}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Environment.Exit(ExitStatus.BadArgument);
                    }
                }
            }

            // Duplicates may exists in collectors list, therefore remove them by turning the list into a hashset and back
            return new List<CollectorDescriptor>(collectors.ToHashSet());
        }
    }
}