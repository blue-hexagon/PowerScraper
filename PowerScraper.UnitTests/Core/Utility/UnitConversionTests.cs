using PowerScraper.Core.Utility;

namespace PowerScraper.UnitTests.Core.Utility
{
    [TestFixture]
    public class UnitConversionTests
    {
        [Test]
        [TestCase(1_125_899_906_842_624+1, "1PiB")]
        [TestCase(1_099_511_627_776+1, "1TiB")]
        [TestCase(1_073_741_824+1, "1GiB")]
        [TestCase(1_048_576+1, "1MiB")]
        [TestCase(1_024+1, "1KiB")]
        [TestCase(128, "128B")]
        public void DetermineBinaryPrefix_WhenUsingBase2_ReturnsTheGreatestUnitUpToPetabytes(long bytes,
            string expectedResult)
        { 
            UnitConversion.BaseUsed = UnitConversion.Bases.Base2;
            var result = UnitConversion.DetermineUnitSuffix(bytes);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        [Test]
        [TestCase(1_000_000_000_000_000+1, "1PB")]
        [TestCase(1_000_000_000_000+1, "1TB")]
        [TestCase(1_000_000_000+1, "1GB")]
        [TestCase(1_000_000+1, "1MB")]
        [TestCase(1_000+1, "1KB")]
        [TestCase(128, "128B")]
        public void DetermineBinaryPrefix_WhenUsingBase10_ReturnsTheGreatestUnitUpToPetabytes(long bytes,
            string expectedResult)
        {
            UnitConversion.BaseUsed = UnitConversion.Bases.Base10;
            var result = UnitConversion.DetermineUnitSuffix(bytes);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}