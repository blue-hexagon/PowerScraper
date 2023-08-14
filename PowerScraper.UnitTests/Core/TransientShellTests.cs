using System.Management.Automation;
using PowerScraper.Core;
using PowerScraper.Core.ExtractionTooling.Powershell;
using PowerScraper.Core.Utility;

namespace PowerScraper.UnitTests.Core
{
    [TestFixture]
    public class TransientShellTests
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            ThreadingOptions.SetCores(CoreUtilisation.Min);
        }
        [Test]
        public void InvokeRawCommand_GivenCmdletIsNotContainedInRunspace_ShouldReturnEmptyCollection()
        {
            ShellInstance.InitializeRunspace();
            var result = ShellInstance.InvokePsScript("Get-History");
            ShellInstance.CloseRunspace();

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void InvokeRawCommand_CommandIsNull_ShouldThrowException()
        {
            ShellInstance.InitializeRunspace();
            Assert.Throws<PSArgumentNullException>(() => ShellInstance.InvokePsScript(null!));
        }

        [Test]
        public void CloseRunspace_RunspaceIsInitialized_ShouldNotThrowException()
        {
            ShellInstance.InitializeRunspace();
            Assert.DoesNotThrow(ShellInstance.CloseRunspace);
        }
    }
}