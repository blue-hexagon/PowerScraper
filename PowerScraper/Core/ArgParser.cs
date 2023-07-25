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

            if (false) // debug
            {
                Console.WriteLine("Collector Count:" + collectors.Count);
                for (int i = 0; i < collectors.Count; i++)
                {
                    Console.WriteLine($"Collector {i}: " + collectors.ToArray()[i].Name +
                                      $"\nIs Category or Scraper? {collectors.ToArray()[i].Scraper}");
                }
            }

            /* Duplicates may exists in collectors list, therefore remove them by
               turning the list into a hashset and back into a list */
            return new List<AbstractDescriptor>(collectors.ToHashSet());
        }
    }
}