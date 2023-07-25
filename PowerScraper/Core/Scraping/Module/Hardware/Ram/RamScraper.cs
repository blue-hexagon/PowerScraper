using PowerScraper.Core.Scraping.DataStructure;
using PowerScraper.Core.Scraping.DataStructure.Collection;

namespace PowerScraper.Core.Scraping.Module.Hardware.Ram
{
    public sealed class RamScraper : AbstractScraper, IScraper
    {
        public CollectionTree ScrapeWindows(CollectionTree collectionNodeInstance)
        {
            // var psObjects = TransientShell.InvokeRawScript(@"
            //     Get-CimInstance Win32_Processor | Select-Object ");
            // OutputCollection = TransientShell.ParsePsObjects(psObjects);

            // return OutputCollection;
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