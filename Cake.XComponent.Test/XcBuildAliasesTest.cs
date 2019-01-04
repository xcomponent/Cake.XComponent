using System.IO;
using Cake.Core;
using Cake.XComponent.Exception;
using Cake.XComponent.Test.Utils;
using Cake.XComponent.Utils;
using NSubstitute;
using NUnit.Framework;

namespace Cake.XComponent.Test
{
    [TestFixture]
    public class XcBuildAliasesTest : XComponentTestBase
    {
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
            XcBuild.TestCommandExecutor = new OkCommandExecutor();
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.XcBuildBuild("", "", "", "", "", platform);
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void IfXcBuildIsProperlyExecuted_XcBuildBuildComponent_ShouldReturn(Platform platform)
        {
            XcBuild.TestCommandExecutor = new OkCommandExecutor();
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.XcBuildBuildComponent("", "", "", "", "", "", "", "", "", platform);
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void IfXcBuildIsProperlyExecuted_XcBuildExportRuntimes_ShouldReturn(Platform platform)
        {
            XcBuild.TestCommandExecutor = new OkCommandExecutor();
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.XcBuildExportRuntimes("", "", "Debug", "Dev", false, "", platform);
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void IfXcBuildIsProperlyExecuted_XcBuildExportInterface_ShouldReturn(Platform platform)
        {
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.XcBuildExportInterface("", "", "Debug", "Dev", false, "", platform);
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void IfXcBuildIsProperlyExecuted_XcBuildExecuteCommand_ShouldReturn(Platform platform)
        {
            XcBuild.TestCommandExecutor = new OkCommandExecutor();
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.XcBuildExecuteCommand("", platform);
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void IfXcBuildIsNotPresent_XcBuildBuild_ShouldThrowAnException(Platform platform)
        {
            XcBuild.TestCommandExecutor = new FailingCommandExecutor();
            var cakeContext = Substitute.For<ICakeContext>();
            Assert.Throws<XComponentException>(() => cakeContext.XcBuildBuild("", "", "", "", "", platform));
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void IfXcBuildIsNotPresent_XcBuildExportRuntimes_ShouldThrowAnException(Platform platform)
        {
            XcBuild.TestCommandExecutor = new FailingCommandExecutor();
            var cakeContext = Substitute.For<ICakeContext>();
            Assert.Throws<XComponentException>(() => cakeContext.XcBuildExportRuntimes("", "", "Debug", "Dev", false, "", platform));
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void IfXcBuildIsNotPresent_XcBuildExportInterface_ShouldThrowAnException(Platform platform)
        {
            XcBuild.TestCommandExecutor = new FailingCommandExecutor();
            var cakeContext = Substitute.For<ICakeContext>();
            Assert.Throws<XComponentException>(() => cakeContext.XcBuildExportInterface("", "", "Debug", "Dev", false, "", platform));
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void IfXcBuildIsPresentButExecutionFails_XcBuildBuild_ShouldThrowAnException(Platform platform)
        {
            XcBuild.TestCommandExecutor = new FailingCommandExecutor();
            var cakeContext = Substitute.For<ICakeContext>();
            Assert.Throws<XComponentException>(() => cakeContext.XcBuildBuild("", "", "", "", "--fail", platform));
        }
    }
}