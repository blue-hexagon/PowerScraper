namespace PowerScraper.Core.Scraping.Module.Hardware
{
    public class HardwareDescriptor : CategoryDescriptor
    {
        public HardwareDescriptor() : base(
            name: "Hardware",
            cmdArg: "--hardware",
            parameter: "hardware",
            description: "All hardware modules")
        {
        }
    }
}