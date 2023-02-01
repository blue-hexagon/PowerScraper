using PowerScraper.Core;

namespace PowerScraper.UnitTests.Core
{
    [TestFixture]
    public class ArgParserTests
    {
        [Test]
        public void ParseCommandLineArguments_ReceivesZeroArguments_ReturnsNull()
        {
            var args = Array.Empty<string>();

            var result = ArgParser.ParseCommandLineArguments(args);

            Assert.That(result, Is.Null);
        }
    }
}