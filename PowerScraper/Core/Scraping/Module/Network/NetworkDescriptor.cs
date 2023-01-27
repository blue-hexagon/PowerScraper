namespace PowerScraper.Core.Scraping.Module.Network
{
    public class NetworkDescriptor : CategoryDescriptor
    {
        public NetworkDescriptor() : base(
            name: "Network",
            cmdArg: "--network",
            parameter: "network",
            description: "All network modules"
        )
        {
        }
    }
}