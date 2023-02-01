using PowerScraper.Core.Scraping;
using PowerScraper.Core.Scraping.DataStructure;
using PowerScraper.Core.Scraping.Module.Hardware.Cpu;
using PowerScraper.Core.Utility;

namespace PowerScraper.Core
{
    public static class ArgParser
    {
        public static List<AbstractDescriptor> ParseCommandLineArguments(string[] arguments)
        {
            var collectors = new List<AbstractDescriptor>();
            // TreeAccessor.MakeTree();
            // var leafs  = TreeAccessor.RootNode.FindChild("hardware").ReturnSubTreeNodes();
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

            // Debug Start
            Console.WriteLine("Collector Count:" + collectors.Count);
            for (int i = 0; i < collectors.Count; i++)
            {
                Console.WriteLine($"Collector {i}: " + collectors.ToArray()[i].Name +
                                  $"\nIs Category or Scraper? {collectors.ToArray()[i].Scraper}");
            } // Debug End


            /* Duplicates may exists in collectors list, therefore remove them by
             turning the list into a hashset and back into a list */
            return new List<AbstractDescriptor>(collectors.ToHashSet());
        }
    }
}