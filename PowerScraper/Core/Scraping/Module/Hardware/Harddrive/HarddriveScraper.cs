using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.Hardware.Harddrive
{
    public sealed class HarddriveScraper : AbstractScraper, IScraper
    {
        public List<Dictionary<string, string>> ScrapeWindows()
        {
            var psObjects = TransientShell.InvokeRawScript(@"
                Get-CimInstance Win32_LogicalDisk | Select-Object DeviceID, DriveType, ProviderName, VolumeName, Size, FreeSpace");
            var OutputCollection = TransientShell.ParsePsObjects(psObjects);

            return OutputCollection;
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