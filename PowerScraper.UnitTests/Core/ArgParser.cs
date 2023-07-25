using PowerScraper.Core;
using PowerScraper.Core.Scraping.DataStructure;

namespace PowerScraper.UnitTests.Core
{
    /// <summary>
    /// Test fixture for ArgParser class.
    /// Tests various commandline arguments and the collection count which the ArgParser returns
    /// </summary>
    [TestFixture]
    public class ArgParserTests
    {
        /// <summary>
        /// Initialize the Tree once before starting to run the tests
        /// This couples All as the master node so that All contains all other nodes
        /// Likewise it couples the Hardware node to contain Ram and Cpu nodes, as well as being a child of the master node
        /// And so on.
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            TreeAccessor.MakeTree();
        }

        [Test]
        public void ParseCommandLineArguments_ReceivesZeroArguments_ShouldReturnEmptyList()
        {
            var args = Array.Empty<string>();

            var result = ArgParser.ParseCommandLineArguments(args);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void ParseCommandLineArguments_ReceivesOneInvalidArgument_ShouldReturnEmptyList()
        {
            string[] args = { "--bad-1" };

            var result = ArgParser.ParseCommandLineArguments(args);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void ParseCommandLineArguments_ReceivesMultipleInvalidArguments_ShouldReturnEmptyList()
        {
            string[] args = { "--bad-1", "--bad-2" };

            var result = ArgParser.ParseCommandLineArguments(args);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void ParseCommandLineArguments_ReceivesOneAcceptedArguments_ShouldReturnNonEmptyList()
        {
            string[] args = { "--ram", "--cpu", "--all" };

            var result = ArgParser.ParseCommandLineArguments(args);

            Assert.That(result, Is.InstanceOf<List<AbstractDescriptor>>());
            Assert.That(result.Count, Is.GreaterThan(2));
        }

        [Test]
        public void ParseCommandLineArguments_ReceivesMultipleAcceptedArguments_ShouldReturnNonEmptyList()
        {
            string[] args = { "--cpu", "--ram" };

            var result = ArgParser.ParseCommandLineArguments(args);

            Assert.That(result, Is.InstanceOf<List<AbstractDescriptor>>());
            Assert.That(result.Count, Is.EqualTo(2));
        }
    }
}