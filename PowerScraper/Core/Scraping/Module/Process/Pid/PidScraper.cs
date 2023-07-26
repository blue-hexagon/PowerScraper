using PowerScraper.Core.Scraping.DataStructure;
using PowerScraper.Core.Scraping.DataStructure.Collection;

namespace PowerScraper.Core.Scraping.Module.Process.Pid
{
    public sealed class PidScraper :  IScraper
    {
        public CollectionTree ScrapeWindows(CollectionTree collectionNodeInstance)
        {
            return new CollectionTree();
        }

        public CollectionTree ScrapeLinux(CollectionTree collectionNodeInstance)
        {
            throw new NotImplementedException();
        }

        public CollectionTree ScrapeOsX(CollectionTree collectionNodeInstance)
        {
            throw new NotImplementedException();
        }

        public CollectionTree ScrapeFreeBsd(CollectionTree collectionNodeInstance)
        {
            throw new NotImplementedException();
        }
    }
}