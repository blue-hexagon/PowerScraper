namespace PowerScraper.Core.Utility
{
    public static class UnitConversion
    {
        public static string DetermineBinaryPrefix(long bytes)
        {
            return bytes switch
            {
                > 1_125_899_906_842_624 => Base2.ConvertBytesToPiB(bytes),
                > 1_099_511_627_776 => Base2.ConvertBytesToTiB(bytes),
                > 1_073_741_824 => Base2.ConvertBytesToGiB(bytes),
                > 1_048_576 => Base2.ConvertBytesToMiB(bytes),
                > 1_024 => Base2.ConvertBytesToKiB(bytes),
                _ => Base2.ConvertBytesToBytes(bytes)
            };
        }

        private static class Base2
        {
            public static string ConvertBytesToPiB(long bytes)
            {
                return Math.Round(((((bytes / 1024f) / 1024f) / 1024f) / 1024f) / 1024, 1) + "PiB";
            }

            public static string ConvertBytesToTiB(long bytes)
            {
                return Math.Round((((bytes / 1024f) / 1024f) / 1024f) / 1024f, 1) + "TiB";
            }

            public static string ConvertBytesToGiB(long bytes)
            {
                return Math.Round(((bytes / 1024f) / 1024f) / 1024f, 1) + "GiB";
            }

            public static string ConvertBytesToMiB(long bytes)
            {
                return Math.Round((bytes / 1024f) / 1024f, 1) + "MiB";
            }

            public static string ConvertBytesToKiB(long bytes)
            {
                return Math.Round(bytes / 1024f, 1) + "KiB";
            }

            public static string ConvertBytesToBytes(long bytes)
            {
                return bytes + "B";
            }
        }
    }
}