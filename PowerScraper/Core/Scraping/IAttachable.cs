using PowerScraper.Core.Scraping.Module;

namespace PowerScraper.Core.Scraping
{
    public interface IAttachable
    {
        void AttachNode(params CollectorDescriptor[] collectorDescriptors);
    }
}