using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.Core.Scraping.Module.System.Computer
{
    public sealed class ComputerScraper : AbstractScraper, IScraper
    {
        public List<Dictionary<string, string>> ScrapeWindows()
        {
            var psObjects = TransientShell.InvokeRawScript(@"
                Get-CimInstance Win32_ComputerSystem | Select-Object DNSHostName,Domain,DomainRole,DaylightInEffect,
                CurrentTimeZone,AdminPasswordStatus,HypervisorPresent,InfraredSupported,
                Manufacturer,Model,Name,PartOfDomain,PrimaryOwnerName,SystemFamily,SystemSKUNumber,SystemType,
                TotalPhysicalMemory,UserName
                ");
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