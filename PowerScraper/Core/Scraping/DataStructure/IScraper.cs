using PowerScraper.Core.Scraping.DataStructure.Collection;

namespace PowerScraper.Core.Scraping.DataStructure
{
    public interface IScraper
    {
        CollectionTree ScrapeWindows(CollectionTree collectionTreeInstance);
        CollectionTree ScrapeLinux(CollectionTree collectionTreeInstance);
        CollectionTree ScrapeOsX(CollectionTree collectionTreeInstance);
        CollectionTree ScrapeFreeBsd(CollectionTree collectionTreeInstance);
    }
    

}