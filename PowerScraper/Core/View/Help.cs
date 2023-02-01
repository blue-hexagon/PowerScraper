
using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.View
{
    public static class HelpView
    {
        public static void VerboseDisplay()
        {
            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (var node in TreeAccessor.RootDescriptorNode.ReturnSubTreeNodes())
            {
                var descriptor = node.Descriptor;
                Console.ForegroundColor = descriptor.Scraper == null ? ConsoleColor.Green : ConsoleColor.White;
                Console.WriteLine($"{descriptor.Name,-38} {descriptor.CmdArg,-24} {descriptor.Description}");
            }
        }

    }
}