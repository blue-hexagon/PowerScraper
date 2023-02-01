using System.Management.Automation;
using PowerScraper.Core;

namespace PowerScraper.UnitTests.Core
{
    [TestFixture]
    public class TransientShellTests
    {
        /** This test indirectly verifies that our runspace is restricted to only a handful of cmdlets */
        [Test]
        public void InvokeRawCommand_GivenCmdletIsNotContainedInRunspace_ReturnsEmptyCollection()
        {
            TransientShell.InitializeRunspace();
            var result = TransientShell.InvokeRawScript("Get-History");
            TransientShell.CloseRunspace();

            Assert.IsEmpty(result);
        }

        [Test]
        public void InvokeRawCommand_CommandIsNull_ThrowsException()
        {
            TransientShell.InitializeRunspace();
            Assert.Throws<PSArgumentNullException>(() => TransientShell.InvokeRawScript(null!));
        }

        [Test]
        public void CloseRunspace_RunspaceIsInitialized_DoesNotThrowException()
        {
            TransientShell.InitializeRunspace();
            Assert.DoesNotThrow(TransientShell.CloseRunspace);
        }
    }
}