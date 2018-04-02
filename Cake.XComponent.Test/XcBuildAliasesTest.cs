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
        public void TestFixtureSetUp()
        {
            var toolsDirectory = Path.Combine(PathFinder.WorkingDirectory, "tools");
            Directory.CreateDirectory(toolsDirectory);
            _xcBuildDirectory = Path.Combine(toolsDirectory, Path.GetRandomFileName());
            Directory.CreateDirectory(_xcBuildDirectory);
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            if (Directory.Exists(_xcBuildDirectory))
            {
                Directory.Delete(_xcBuildDirectory, true);
            }
        }

        [TearDown]
        public void TearDown()
        {
            PathFinder.XcBuildPath = null;
        }

        [TestCase("xcbuild.exe")]
        [TestCase(@"subFolder\xcbuild.exe")]
        [TestCase(@"..\subFolder\xcbuild.exe")]
        public void TestSetXcBuildPath(string path)
        {
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.SetXcBuildPath(path);
            Assert.AreEqual(Path.GetFullPath(path), PathFinder.XcBuildPath);
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void IfXcBuildIsProperlyExecuted_XcBuildBuild_ShouldReturn(Platform platform)
        {
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _xcBuildDirectory, PathFinder.GetXcBuildProgram(platform));
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.XcBuildBuild("", "", "", "", "", platform);
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void IfXcBuildIsProperlyExecuted_XcBuildBuildComponent_ShouldReturn(Platform platform)
        {
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _xcBuildDirectory, PathFinder.GetXcBuildProgram(platform));
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.XcBuildBuildComponent("", "", "", "", "", "", "", "", "", platform);
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void IfXcBuildIsProperlyExecuted_XcBuildExportRuntimes_ShouldReturn(Platform platform)
        {
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _xcBuildDirectory, PathFinder.GetXcBuildProgram(platform));
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.XcBuildExportRuntimes("", "", "Debug", "Dev", false, "", platform);
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void IfXcBuildIsProperlyExecuted_XcBuildExportInterface_ShouldReturn(Platform platform)
        {
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _xcBuildDirectory, PathFinder.GetXcBuildProgram(platform));
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.XcBuildExportInterface("", "", "Debug", "Dev", false, "", platform);
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void IfXcBuildIsProperlyExecuted_XcBuildExecuteCommand_ShouldReturn(Platform platform)
        {
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _xcBuildDirectory, PathFinder.GetXcBuildProgram(platform));
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.XcBuildExecuteCommand("", platform);
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        [ExpectedException(typeof(XComponentException))]
        public void IfXcBuildIsNotPresent_XcBuildBuild_ShouldThrowAnException(Platform platform)
        {
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.XcBuildBuild("", "", "", "", "", platform);
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        [ExpectedException(typeof(XComponentException))]
        public void IfXcBuildIsNotPresent_XcBuildExportRuntimes_ShouldThrowAnException(Platform platform)
        {
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.XcBuildExportRuntimes("", "", "Debug", "Dev", false, "", platform);
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        [ExpectedException(typeof(XComponentException))]
        public void IfXcBuildIsNotPresent_XcBuildExportInterface_ShouldThrowAnException(Platform platform)
        {
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.XcBuildExportInterface("", "", "Debug", "Dev", false, "", platform);
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        [ExpectedException(typeof(XComponentException))]
        public void IfXcBuildIsPresentButExecutionFails_XcBuildBuild_ShouldThrowAnException(Platform platform)
        {
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _xcBuildDirectory, PathFinder.GetXcBuildProgram(platform));
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.XcBuildBuild("", "", "", "", "--fail", platform);
        }
    }
}