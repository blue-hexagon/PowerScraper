//using System.Net.NetworkInformation;

using PowerScraper.Core.Scraping.DataStructure;
using PowerScraper.Core.Scraping.DataStructure.Collection;

namespace PowerScraper.Core.Scraping.Module.Network.Interface
{
    public sealed class InterfaceScraper : AbstractScraper, IScraper
    {
        public CollectionTree ScrapeWindows(CollectionTree collectionNodeInstance)
        {
            // var psObjects = ReusableShell.InvokeRawCommand(@"
            // Get-NetAdapter -Physical | Select-Object Name, InterfaceDescription,
            // ifIndex, MacAddress, LinkSpeed, State, Status
            // ");
            // Output = ReusableShell.ParsePsObject(psObjects);
            
            // var adapters = NetworkInterface.GetAllNetworkInterfaces();
            // foreach (var adapter in adapters)
            // {
            //     if (adapter.OperationalStatus is not (OperationalStatus.Up or OperationalStatus.Down))
            //         continue;
            //     var properties = adapter.GetIPProperties();
            //     var nestedEntrance = new Dictionary<string, dynamic>();
            //     OutputCollection.Add(adapter.Description,nestedEntrance);
            //
            //     nestedEntrance.Add("Status", adapter.OperationalStatus.ToString());
            //     nestedEntrance.Add("ID", adapter.Id);
            //     nestedEntrance.Add("Name", adapter.Name);
            //     nestedEntrance.Add("Speed", adapter.Speed.ToString());
            //     nestedEntrance.Add("Interface Type", adapter.NetworkInterfaceType.ToString());
            //     nestedEntrance.Add("DNS Suffix", properties.DnsSuffix);
            //     // nestedEntrance.Add("DNS Enabled", properties.IsDnsEnabled.ToString());
            //     // nestedEntrance.Add("Dynamically Configured DNS", properties.IsDynamicDnsEnabled.ToString());
            // }

            return collectionNodeInstance;
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