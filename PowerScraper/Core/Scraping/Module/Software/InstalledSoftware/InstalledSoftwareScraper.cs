﻿using PowerScraper.Core.Scraping.DataStructure;
using PowerScraper.Core.Scraping.DataStructure.Collection;

namespace PowerScraper.Core.Scraping.Module.Software.InstalledSoftware
{
    public sealed class InstalledSoftwareScraper : AbstractScraper, IScraper
    {
        public CollectionTree ScrapeWindows(CollectionTree collectionNodeInstance)
        {
            return new CollectionTree();
        }

        public CollectionTree ScrapeLinux()
        {
            throw new NotImplementedException();
        }

        public CollectionTree ScrapeOsX()
        {
            throw new NotImplementedException();
        }

        public CollectionTree ScrapeFreeBsd()
        {
            throw new NotImplementedException();
        }
    }
}