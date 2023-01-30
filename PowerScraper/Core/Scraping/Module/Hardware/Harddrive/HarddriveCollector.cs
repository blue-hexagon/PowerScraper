using PowerScraper.Core.Utility;

namespace PowerScraper.Core.Scraping.Module.Hardware.Harddrive
{
    public sealed class HarddriveCollector : AbstractCollector, ICollector
    {
        public Dictionary<string, string> ScrapeWindows()
        {
            var drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    Output.Add(drive.Name, UnitConversion.ConvertBytesToGreatestUnit(drive.TotalSize));
                }
            }

            return Output;
        }

        public Dictionary<string, string> ScrapeLinux()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> ScrapeOsX()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> ScrapeFreeBsd()
        {
            throw new NotImplementedException();
        }
    }
}