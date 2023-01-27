namespace PowerScraper.Core.Scraping.Module.Uncategorized
{
    public class UncategorizedDescriptor : CategoryDescriptor
    {
        public UncategorizedDescriptor() : base(
            name: "Uncategorized",
            cmdArg: "--uncategorized",
            parameter: "uncategorized",
            description: "All uncategorized modules"
        )
        {
        }
    }
}