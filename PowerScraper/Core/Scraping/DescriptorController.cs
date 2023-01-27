using PowerScraper.Core.Scraping.Module;

namespace PowerScraper.Core.Scraping
{
    public static class DescriptorController
    {
        public static List<CategoryDescriptor> CategoryDescriptorList { get; } = new();
        public static List<CollectorDescriptor> CollectorDescriptorList { get; } = new();
        public static Dictionary<string, CategoryDescriptor> CategoryDescriptorHashmap { get; } = new();
        public static Dictionary<string, CollectorDescriptor> CollectorDescriptorHashmap { get; } = new();

        public static void RegisterCategoryDescriptor(CategoryDescriptor descriptor)
        {
            if (!CategoryDescriptorList.Contains(descriptor))
                CategoryDescriptorList.Add(descriptor);
            if (!CategoryDescriptorHashmap.ContainsKey(descriptor.CmdArg))
                CategoryDescriptorHashmap.Add(descriptor.CmdArg, descriptor);
        }

        public static void RegisterCollectorDescriptor(CollectorDescriptor descriptor)
        {
            if (!CollectorDescriptorList.Contains(descriptor))
                CollectorDescriptorList.Add(descriptor);
            if (!CollectorDescriptorHashmap.ContainsKey(descriptor.CmdArg))
                CollectorDescriptorHashmap.Add(descriptor.CmdArg, descriptor);
        }


        public static CategoryDescriptor GetCategoryFromCliArg(string commandlineArgument)
        {
            if (CategoryDescriptorHashmap.ContainsKey(commandlineArgument))
                return CategoryDescriptorHashmap[commandlineArgument];
            throw new KeyNotFoundException($"Bad key: {commandlineArgument}");
        }

        public static CollectorDescriptor GetCollectorFromCliArg(string commandlineArgument)
        {
            if (CollectorDescriptorHashmap.ContainsKey(commandlineArgument))
                return CollectorDescriptorHashmap[commandlineArgument];
            throw new KeyNotFoundException($"Bad key: {commandlineArgument}");
        }
    }
}