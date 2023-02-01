using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.Hardware.Ram
{
    public sealed class RamScraper : AbstractScraper, IScraper
    {
        public List<Dictionary<string, string>> ScrapeWindows()
        {
            // var psObjects = TransientShell.InvokeRawScript(@"
            //     Get-CimInstance Win32_Processor | Select-Object ");
            // OutputCollection = TransientShell.ParsePsObjects(psObjects);

            // return OutputCollection;
            return new List<Dictionary<string, string>>();
        }

        public List<Dictionary<string, string>> ScrapeLinux()
        {
            throw new NotImplementedException();
        }

        public List<Dictionary<string, string>> ScrapeOsX()
        {
            throw new NotImplementedException();
        }

        public List<Dictionary<string, string>> ScrapeFreeBsd()
        {
            throw new NotImplementedException();
        }
    }
}