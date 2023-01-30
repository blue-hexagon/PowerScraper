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
        throw new PlatformNotSupportedException("Unknown platform");
    }

    public static void PlatformSwitch()
    {
        switch (PlatformInUse)
        {
            case Platform.Windows:
                break;
            case Platform.Linux:
                break;
            case Platform.OsX:
                break;
            case Platform.FreeBsd:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}