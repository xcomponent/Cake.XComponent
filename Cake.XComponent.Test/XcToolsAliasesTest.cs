using System.IO;
using Cake.Core;
using Cake.XComponent.Exception;
using Cake.XComponent.Utils;
using NSubstitute;
using NUnit.Framework;

namespace Cake.XComponent.Test
{
    [TestFixture]
    public class XcToolsAliasesTest : XComponentTestBase
    {
        private string _xcToolsDirectory;

        [SetUp]
        public void SetUp()
        {
            var toolsDirectory = Path.Combine(PathFinder.WorkingDirectory, "tools");
            Directory.CreateDirectory(toolsDirectory);
            _xcToolsDirectory = Path.Combine(toolsDirectory, Path.GetRandomFileName());
            Directory.CreateDirectory(_xcToolsDirectory);
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(_xcToolsDirectory))
            {
                Directory.Delete(_xcToolsDirectory, true);
            }
        }

        [Test]
        public void IfXcToolsIsProperlyExecuted_XcToolsBuild_ShouldReturn()
        {
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _xcToolsDirectory, PathFinder.XcToolsExe);
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.XcToolsBuild("", "", "", "", "");
        }
        
        [Test]
        [ExpectedException(typeof(XComponentException))]
        public void IfXcToolsIsNotPresent_XcToolsBuild_ShouldThrowAnException()
        {
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.XcToolsBuild("", "", "", "", "");
        }
        
        [Test]
        [ExpectedException(typeof(XComponentException))]
        public void IfXcToolsIsPresentButExecutionFails_XcToolsBuild_ShouldThrowAnException()
        {
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _xcToolsDirectory, PathFinder.XcToolsExe);
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.XcToolsBuild("", "", "", "", "--fail");
        }
    }
}