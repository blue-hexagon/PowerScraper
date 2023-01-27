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

            var result = CommandLineParser.ParseCommandLineArguments(args);

            Assert.Null(result);
        }
    }
}