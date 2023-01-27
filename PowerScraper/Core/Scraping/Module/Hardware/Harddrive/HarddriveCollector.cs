using PowerScraper.Core.Utility;

namespace PowerScraper.Core.Scraping.Module.Hardware.Harddrive
{
    public sealed class HarddriveCollector : AbstractCollector, ICollector
    {
        public Dictionary<string, string> PerformScraping()
        {
            var drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    Output.Add(drive.Name, UnitConversion.DetermineBinaryPrefix(drive.TotalSize));
                }
            }

            return Output;
        }
    }
}