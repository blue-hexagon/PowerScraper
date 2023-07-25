using System.Management.Automation;
using PowerScraper.Core;

namespace PowerScraper.UnitTests.Core
{
    [TestFixture]
    public class TransientShellTests
    {
        [Test]
        public void InvokeRawCommand_GivenCmdletIsNotContainedInRunspace_ShouldReturnEmptyCollection()
        {
            TransientShell.InitializeRunspace();
            var result = TransientShell.InvokeRawScript("Get-History");
            TransientShell.CloseRunspace();

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void InvokeRawCommand_CommandIsNull_ShouldThrowException()
        {
            TransientShell.InitializeRunspace();
            Assert.Throws<PSArgumentNullException>(() => TransientShell.InvokeRawScript(null!));
        }

        [Test]
        public void CloseRunspace_RunspaceIsInitialized_ShouldNotThrowException()
        {
            TransientShell.InitializeRunspace();
            Assert.DoesNotThrow(TransientShell.CloseRunspace);
        }
    }
}