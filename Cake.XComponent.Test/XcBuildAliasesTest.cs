using System.IO;
using Cake.Core;
using Cake.XComponent.Exception;
using Cake.XComponent.Utils;
using NSubstitute;
using NUnit.Framework;

namespace Cake.XComponent.Test
{
    [TestFixture]
    public class XcBuildAliasesTest : XComponentTestBase
    {
        private string _xcBuildDirectory;

        [TestFixtureSetUp]
        public void SetUp()
        {
            var toolsDirectory = Path.Combine(PathFinder.WorkingDirectory, "tools");
            Directory.CreateDirectory(toolsDirectory);
            _xcBuildDirectory = Path.Combine(toolsDirectory, Path.GetRandomFileName());
            Directory.CreateDirectory(_xcBuildDirectory);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            if (Directory.Exists(_xcBuildDirectory))
            {
                Directory.Delete(_xcBuildDirectory, true);
            }
        }

        [Test]
        public void IfXcBuildIsProperlyExecuted_XcBuildBuild_ShouldReturn()
        {
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _xcBuildDirectory, PathFinder.XcBuildExe);
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.XcBuildBuild("", "", "", "", "");
        }

        [Test]
        public void IfXcBuildIsProperlyExecuted_XcBuildExportRuntimes_ShouldReturn()
        {
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _xcBuildDirectory, PathFinder.XcBuildExe);
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.XcBuildExportRuntimes("", "");
        }

        [Test]
        [ExpectedException(typeof(XComponentException))]
        public void IfXcBuildIsNotPresent_XcBuildBuild_ShouldThrowAnException()
        {
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.XcBuildBuild("", "", "", "", "");
        }

        [Test]
        [ExpectedException(typeof(XComponentException))]
        public void IfXcBuildIsNotPresent_XcBuildExportRuntimes_ShouldThrowAnException()
        {
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.XcBuildExportRuntimes("", "");
        }

        [Test]
        [ExpectedException(typeof(XComponentException))]
        public void IfXcBuildIsPresentButExecutionFails_XcBuildBuild_ShouldThrowAnException()
        {
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _xcBuildDirectory, PathFinder.XcBuildExe);
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.XcBuildBuild("", "", "", "", "--fail");
        }
    }
}