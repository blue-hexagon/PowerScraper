using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.View
{
    public static class HelpView
    {
        public static void VerboseDisplay()
        {
            int nameLen = 0, cmdLen = 0;
            foreach (var node in TreeAccessor.RootDescriptorNode.ReturnSubTreeNodes())
            {
                if (nameLen < node.Descriptor.Name.Length)
                    nameLen = node.Descriptor.Name.Length;
                if (cmdLen < node.Descriptor.CmdArg.Length)
                    cmdLen = node.Descriptor.CmdArg.Length;
            }
            nameLen += 2;
            cmdLen += 2;

            foreach (var node in TreeAccessor.RootDescriptorNode.ReturnSubTreeNodes())
            {
                var descriptor = node.Descriptor;

                Console.ForegroundColor = descriptor.Scraper == null ? ConsoleColor.Green : ConsoleColor.White;
                Console.WriteLine(
                    $"{descriptor.Name.PadRight(nameLen)} {descriptor.CmdArg.PadRight(cmdLen)} {descriptor.Description}");
            }
        }
    }
}