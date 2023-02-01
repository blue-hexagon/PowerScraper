using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.Hardware.Cpu
{
    public sealed class CpuScraper : AbstractScraper, IScraper
    {
        public List<Dictionary<string, string>> ScrapeWindows()
        {
            
            var psObjects = TransientShell.InvokeRawScript(@"
                Get-CimInstance Win32_Processor | Select-Object DeviceID,SocketDesignation, LoadPercentage,
                Architecture,Description,
                Manufacturer,Name,NumberOfCores,NumberOfLogicalProcessors,ThreadCount, AddressWidth, DataWidth,
                L2CacheSize,L3CacheSize, MaxClockSpeed,PowerManagementSupported,
                PartNumber,SerialNumber,VirtualizationFirmwareEnabled,VMMonitorModeExtensions");
            OutputCollection = TransientShell.ParsePsObjects(psObjects);

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