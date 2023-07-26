
using PowerScraper.Core.Scraping.DataStructure;
using PowerScraper.Core.Scraping.DataStructure.Collection;

namespace PowerScraper.Core.Scraping.Module.Software.StartupSoftware
{
    public sealed class StartupSoftwareScraper :  IScraper
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