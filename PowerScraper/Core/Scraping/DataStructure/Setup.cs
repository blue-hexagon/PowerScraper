using PowerScraper.Core.Scraping;
using PowerScraper.Core.Scraping.DataStructure;
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
using PowerScraper.Core.Scraping.Module.System;
using PowerScraper.Core.Scraping.Module.System.Computer;
using PowerScraper.Core.Scraping.Module.System.OS;
using PowerScraper.Core.Scraping.Module.Uncategorized;

// ReSharper disable UnusedVariable
// @formatter:off
namespace PowerScraper.Core.Scraping.DataStructure;

public static class TreeAccessor
{
    public static DescriptorNode RootDescriptorNode { get; } = new(new AllDescriptor());
    
    
    public static void MakeTree()
    {
            var hardware = RootDescriptorNode.Insert(new HardwareDescriptor());
                hardware.Insert(new CpuDescriptor());
                hardware.Insert(new RamDescriptor());
                hardware.Insert(new HarddriveDescriptor());
            var network = RootDescriptorNode.Insert(new NetworkDescriptor());
                network.Insert(new InterfaceDescriptor());
                network.Insert(new SsidDescriptor());
            var process = RootDescriptorNode.Insert(new ProcessDescriptor());
                process.Insert(new PidDescriptor());
            var software = RootDescriptorNode.Insert(new SoftwareDescriptor());
                software.Insert(new InstalledSoftwareDescriptor());
                software.Insert(new StartupSoftDescriptor());
            var system = RootDescriptorNode.Insert(new SystemDescriptor());
                system.Insert(new ComputerDescriptor());
                system.Insert(new OperatingSystemDescriptor());
            var uncategorized = RootDescriptorNode.Insert(new UncategorizedDescriptor());
            IndexTree(RootDescriptorNode);
    }

    private static void IndexTree(DescriptorNode rootDescriptorNode)
    {
        var allNodesList = rootDescriptorNode.ReturnSubTreeNodes();
        foreach (var node in allNodesList)
            DescriptorNode.DescriptorNodeIndex.Add(node.Descriptor.CmdArg, node);
    }
}