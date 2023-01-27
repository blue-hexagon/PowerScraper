namespace PowerScraper.Core.Utility
{
    /** Set the BaseUsed to a Bases enum before executing the program if you wish to use Base10 units. */
    public static class UnitConversion
    {
        public static Enum? BaseUsed { get; set; } = Bases.Base2;

        public enum Bases
        {
            Base2,
            Base10
        }

        public static string DetermineUnitSuffix(long bytes)
        {
            if (BaseUsed == null)
                throw new ArgumentNullException($"Set the base BaseUsed enum");
            if (BaseUsed.Equals(Bases.Base2))
                return Base2.DetermineBase2Suffix(bytes);
            if (BaseUsed.Equals(Bases.Base10))
                return Base10.DetermineBase10Suffix(bytes);
            throw new ArgumentNullException($"Set the base BaseUsed BaseUsed");
        }

        private static class Base10
        {
            public static string DetermineBase10Suffix(long bytes)
            {
                return bytes switch
                {
                    > 1_000_000_000_000_000 => ConvertBytesToPB(bytes),
                    > 1_000_000_000_000 => ConvertBytesToTB(bytes),
                    > 1_000_000_000 => ConvertBytesToGB(bytes),
                    > 1_000_000 => ConvertBytesToMB(bytes),
                    > 1_000 => ConvertBytesToKB(bytes),
                    _ => AddByteSuffix(bytes)
                };
            }

            private static string ConvertBytesToPB(long bytes)
            {
                return Math.Round(bytes / 1000f / 1000f / 1000f / 1000f / 1000f, 1) + "PB";
            }

            private static string ConvertBytesToTB(long bytes)
            {
                return Math.Round(bytes / 1000f / 1000f / 1000f / 1000f, 1) + "TB";
            }


            private static string ConvertBytesToGB(long bytes)
            {
                return Math.Round(bytes / 1000f / 1000f / 1000f, 1) + "GB";
            }

            private static string ConvertBytesToMB(long bytes)
            {
                return Math.Round(bytes / 1000f / 1000f, 1) + "MB";
            }

            private static string ConvertBytesToKB(long bytes)
            {
                return Math.Round(bytes / 1000f, 1) + "KB";
            }
        }

        private static class Base2
        {
            public static string DetermineBase2Suffix(long bytes)
            {
                return bytes switch
                {
                    > 1_125_899_906_842_624 => ConvertBytesToPiB(bytes),
                    > 1_099_511_627_776 => ConvertBytesToTiB(bytes),
                    > 1_073_741_824 => ConvertBytesToGiB(bytes),
                    > 1_048_576 => ConvertBytesToMiB(bytes),
                    > 1_024 => ConvertBytesToKiB(bytes),
                    _ => AddByteSuffix(bytes)
                };
            }

            private static string ConvertBytesToPiB(long bytes)
            {
                return Math.Round(bytes / 1024f / 1024f / 1024f / 1024f / 1024, 1) + "PiB";
            }

            private static string ConvertBytesToTiB(long bytes)
            {
                return Math.Round(bytes / 1024f / 1024f / 1024f / 1024f, 1) + "TiB";
            }

            private static string ConvertBytesToGiB(long bytes)
            {
                return Math.Round(bytes / 1024f / 1024f / 1024f, 1) + "GiB";
            }

            private static string ConvertBytesToMiB(long bytes)
            {
                return Math.Round(bytes / 1024f / 1024f, 1) + "MiB";
            }

            private static string ConvertBytesToKiB(long bytes)
            {
                return Math.Round(bytes / 1024f, 1) + "KiB";
            }
        }

        private static string AddByteSuffix(long bytes)
        {
            return bytes + "B";
        }
    }
}