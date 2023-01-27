using PowerScraper.Core.Scraping;
using PowerScraper.Core.Scraping.Module;
using PowerScraper.Core.Scraping.Module.All;
using PowerScraper.Core.Scraping.Module.Hardware;
using PowerScraper.Core.Scraping.Module.Hardware.Cpu;
using PowerScraper.Core.Scraping.Module.Hardware.Harddrive;
using PowerScraper.Core.Scraping.Module.Hardware.Ram;
using PowerScraper.Core.Scraping.Module.Network;
using PowerScraper.Core.Scraping.Module.Network.Interface;
using PowerScraper.Core.Scraping.Module.Network.Ssid;
using PowerScraper.Core.Scraping.Module.Process;
using PowerScraper.Core.Scraping.Module.Process.Pid;
using PowerScraper.Core.Scraping.Module.Software;
using PowerScraper.Core.Scraping.Module.Software.InstalledSoftware;
using PowerScraper.Core.Scraping.Module.Software.StartupSoftware;
using PowerScraper.Core.Scraping.Module.Uncategorized;
using PowerScraper.Core.Scraping.Module.Uncategorized.System;

namespace PowerScraper.Core.Configuration;

public static class ConfigurationInitializer
{
    /** Modify as needed:
         * - If you add a new category descriptor and implement collectors for it, connect it to it's collectors here; like so:
         * <code>ConnectNodes(new CategoryDescriptor(), new CollectorDescriptor1() ... new CollectorDescriptorN());</code>
         */
    public static void InitializeAndConnectDescriptors()
    {
        ConnectNodes(new HardwareDescriptor(), new CpuDescriptor(), new RamDescriptor(), new HarddriveDescriptor());
        ConnectNodes(new NetworkDescriptor(), new InterfaceDescriptor(), new SsidDescriptor());
        ConnectNodes(new SoftwareDescriptor(), new InstalledSoftwareDescriptor(), new StartupSoftDescriptor());
        ConnectNodes(new ProcessDescriptor(), new PidDescriptor());
        ConnectNodes(new UncategorizedDescriptor(), new ComputerDescriptor(), new OperatingSystemDescriptor());

        /*Leave this line as is*/
        InitializeRootDescriptor();
    }

    /** Initializes and registers the category descriptor along with each category's corresponding collectors.
            (each CollectorDescriptor instance registers itself upon creation, this behaviour is defined in CollectorDescriptor.cs.)
        */
    private static void InitializeRootDescriptor()
    {
        var allDescriptor = new AllDescriptor();
        foreach (var collectorList in DescriptorController.CategoryDescriptorList)
        {
            foreach (var collector in collectorList.Collectors)
            {
                allDescriptor.AttachNode(collector);
            }
        }

        DescriptorController.RegisterCategoryDescriptor(allDescriptor);
    }

    /** Each CollectorDescriptor attaches itself to its parent which is an instance of a CategoryDescriptor
            Afterwards the CategoryDescriptor instance registers itself in DescriptorController.cs.
        */
    private static void ConnectNodes(CategoryDescriptor categoryDescriptor,
        params CollectorDescriptor[] collectorDescriptors)
    {
        categoryDescriptor.AttachNode(collectorDescriptors);
        DescriptorController.RegisterCategoryDescriptor(categoryDescriptor);
    }
}