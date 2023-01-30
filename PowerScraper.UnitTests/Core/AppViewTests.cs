using System.ComponentModel;
using PowerScraper.Core;
using PowerScraper.Core.Utility;

namespace PowerScraper.UnitTests.Core
{
    [TestFixture]
    public class AppViewTests
    {
        [Test]
        public void SerializeScrapedOutput_GivenInvalidFormattingEnum_ThrowsException()
        {
            var invalidEnum = (SerializationFormat)9999;
            var dummyDict = new Dictionary<string, Dictionary<string, string>>();
            Assert.Throws<InvalidEnumArgumentException>(() =>
                Serializer.SerializeScrapedOutput(invalidEnum, dummyDict));
        }
    }
}