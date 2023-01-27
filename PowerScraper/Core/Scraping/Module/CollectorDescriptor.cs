namespace PowerScraper.Core.Scraping.Module
{
    public abstract class CollectorDescriptor : AbstractDescriptor, IRegisterable
    {
        public readonly CategoryDescriptor CategoryDescriptor;
        public readonly ICollector Scraper;

        protected CollectorDescriptor(string name, string cmdArg, string parameter, string description,
            CategoryDescriptor categoryDescriptor, ICollector collector) :
            base(name, cmdArg, parameter, description)
        {
            CategoryDescriptor = categoryDescriptor;
            Scraper = collector;
            Register();
        }


        public void Register()
        {
            DescriptorController.RegisterCollectorDescriptor(this);
        }
    }
}