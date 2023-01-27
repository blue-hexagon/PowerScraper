using PowerScraper.Core.Scraping.Module;

namespace PowerScraper.Core.Scraping
{
    public class CategoryDescriptor : AbstractDescriptor, IAttachable
    {
        public List<CollectorDescriptor> Collectors { get; set; } = new();

        protected CategoryDescriptor(string name, string cmdArg, string parameter, string description) :
            base(name, cmdArg, parameter, description)
        {
        }


        public void AttachNode(params CollectorDescriptor[] collectorDescriptors)
        {
            foreach (var descriptor in collectorDescriptors)
            {
                Collectors.Add(descriptor);
            }
        }
    }
}