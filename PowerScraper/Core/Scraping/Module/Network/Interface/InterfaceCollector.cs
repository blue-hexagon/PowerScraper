using System.Diagnostics;
using System.Net.NetworkInformation;

namespace PowerScraper.Core.Scraping.Module.Network.Interface
{
    public sealed class InterfaceCollector : AbstractCollector, ICollector
    {
        public Dictionary<string, string> PerformScraping()
        {
            try
            {
                // var psObjects = ReusableShell.InvokeRawCommand(@"
                // Get-NetAdapter -Physical | Select-Object Name, InterfaceDescription,
                // ifIndex, MacAddress, LinkSpeed, State, Status
                // ");
                // Output = ReusableShell.ParsePsObject(psObjects);
                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in adapters)
                {
                    if (adapter.OperationalStatus == OperationalStatus.Up ||  adapter.OperationalStatus == OperationalStatus.Down)
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        Console.WriteLine(adapter.Description);
                        Console.WriteLine("Status: {0}", adapter.OperationalStatus);
                        Console.WriteLine("ID: {0}", adapter.Id);
                        Console.WriteLine("Name: {0}", adapter.Name);
                        Console.WriteLine("Speed: {0}", adapter.Speed);
                        Console.WriteLine("IfType: {0}", adapter.NetworkInterfaceType);
                        Console.WriteLine("DNS suffix: {0}", properties.DnsSuffix);
                        Console.WriteLine("DNS enabled: {0}", properties.IsDnsEnabled);
                        Console.WriteLine("Dynamically configured DNS: {0}", properties.IsDynamicDnsEnabled);
                        Console.WriteLine();
                    }
                }

                Environment.Exit(0);
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
            }

            return Output;
        }
    }
}