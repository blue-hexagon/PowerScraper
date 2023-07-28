using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core
{
    public static class ArgParser
    {
        public static List<AbstractDescriptor> ParseCommandLineArguments(string[] arguments)
        {
            var collectors = new List<AbstractDescriptor>();

            foreach (var arg in arguments)
            {
                Logger.ToConsole(LogLevel.Debug, $"Parsing args, current is: {arg}");
                if (!DescriptorNode.DescriptorNodeIndex.ContainsKey(arg))
                    continue;
                if (DescriptorNode.DescriptorNodeIndex[arg].Descriptor.Scraper != null)
                    collectors.Add(DescriptorNode.DescriptorNodeIndex[arg].Descriptor);
                else
                {
                    foreach (var leafNode in DescriptorNode.DescriptorNodeIndex[arg].GetLeafNodes())
                    {
                        collectors.Add(leafNode.Descriptor);
                    }
                }
            }

            for (var i = 0; i < collectors.Count; i++)
            {
                Logger.ToConsole(
                    LogLevel.Debug,
                    $"Collector {i + 1}/{collectors.Count}: {collectors.ToArray()[i].Name}"
                );
            }

            /* Duplicates may exists in collectors list, therefore remove them by
               turning the list into a hashset and back into a list */
            return new List<AbstractDescriptor>(collectors.ToHashSet());
        }
    }
}