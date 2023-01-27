using System.Collections.Generic;
using System.ComponentModel;
using NUnit.Framework;
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
            var invalidEnum = (OutputFormat)9999;
            var dummyDict = new Dictionary<string, Dictionary<string, string>>();
            Assert.Throws<InvalidEnumArgumentException>(() =>
                Serializer.SerializeScrapedOutput(invalidEnum, dummyDict));
        }
    }
}