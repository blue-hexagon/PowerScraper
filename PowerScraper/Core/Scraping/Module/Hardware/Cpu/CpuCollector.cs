namespace PowerScraper.Core.Scraping.Module.Hardware.Cpu
{
    public sealed class CpuCollector : AbstractCollector, ICollector
    {
        public Dictionary<string, string> PerformScraping()
        {
            var psObjects = TransientShell.InvokeRawScript(@"
                Get-WmiObject -Class Win32_Processor | Select-Object DeviceID,SocketDesignation, LoadPercentage,
                Architecture,Description,
                Manufacturer,Name,NumberOfCores,NumberOfLogicalProcessors,ThreadCount, AddressWidth, DataWidth,
                L2CacheSize,L3CacheSize, MaxClockSpeed,PowerManagementSupported,
                PartNumber,SerialNumber,VirtualizationFirmwareEnabled,VMMonitorModeExtensions
                ");
            Output = TransientShell.ParsePsObjects(psObjects);

            return Output;
        }
    }
}