using System.Runtime.InteropServices;

namespace PowerScraper.Core.Utility.OS;

public static class PlatformReader
{
    public static Platform PlatformInUse { get; set; }

    public static Platform IdentifyPlatform()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            return Platform.Windows;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return Platform.Linux;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            return Platform.OsX;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD))
            return Platform.FreeBsd;
        throw new PlatformNotSupportedException("Unsupported platform: supported platforms are: Windows, Linux, OS X and FreeBSD.");
    }
}