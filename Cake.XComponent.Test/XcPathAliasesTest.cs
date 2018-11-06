using System.IO;
using Cake.Core;
using Cake.XComponent.Utils;
using NSubstitute;
using NUnit.Framework;

namespace Cake.XComponent.Test
{
    [TestFixture]
    public class XcPathAliasesTest : XComponentTestBase
    {
        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void TestGetXcStudioPath(Platform platform)
        {
            var cakeContext = Substitute.For<ICakeContext>();
            Assert.DoesNotThrow(() => cakeContext.GetXcStudioPath(platform));
        }
        
        [Test]
        public void TestSetXcStudioPath()
        {
            var path = Path.Combine(ToolsPath, PathFinder.GetXcStudioProgram(Platform.X64));
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.SetXcStudioPath(path);

            Assert.AreEqual(path, cakeContext.GetXcStudioPath(Platform.X64));
            Assert.AreEqual(path, cakeContext.GetXcStudioPath(Platform.X86));
        }

        [Test]
        public void TestSetXcStudioPathWithNotExistingPath()
        {
            var notExistingPath = Path.Combine(ToolsPath, Path.GetRandomFileName());
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.SetXcStudioPath(notExistingPath);

            Assert.IsNull(cakeContext.GetXcStudioPath(Platform.X64));
            Assert.IsNull(cakeContext.GetXcStudioPath(Platform.X86));
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void TestGetXcBuildPath(Platform platform)
        {
            var cakeContext = Substitute.For<ICakeContext>();
            Assert.DoesNotThrow(() => cakeContext.GetXcBuildPath(platform));
        }

        [Test]
        public void TestSetXcBuildPath()
        {
            var path = Path.Combine(ToolsPath, PathFinder.GetXcBuildProgram(Platform.X64));
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.SetXcBuildPath(path);

            Assert.AreEqual(path, cakeContext.GetXcBuildPath(Platform.X64));
            Assert.AreEqual(path, cakeContext.GetXcBuildPath(Platform.X86));
        }

        [Test]
        public void TestSetXcBuildPathWithNotExistingPath()
        {
            var notExistingPath = Path.Combine(ToolsPath, Path.GetRandomFileName());
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.SetXcBuildPath(notExistingPath);

            Assert.IsNull(cakeContext.GetXcBuildPath(Platform.X64));
            Assert.IsNull(cakeContext.GetXcBuildPath(Platform.X86));
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void TestGetXcRuntimePath(Platform platform)
        {
            var cakeContext = Substitute.For<ICakeContext>();
            Assert.DoesNotThrow(() => cakeContext.GetXcRuntimePath(platform));
        }

        [Test]
        public void TestSetXcRuntimePath()
        {
            var path = Path.Combine(ToolsPath, PathFinder.GetXcRuntimeProgram(Platform.X64));
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.SetXcRuntimePath(path);

            Assert.AreEqual(path, cakeContext.GetXcRuntimePath(Platform.X64));
            Assert.AreEqual(path, cakeContext.GetXcRuntimePath(Platform.X86));
        }

        [Test]
        public void TestSetXcRuntimePathWithNotExistingPath()
        {
            var notExistingPath = Path.Combine(ToolsPath, Path.GetRandomFileName());
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.SetXcRuntimePath(notExistingPath);

            Assert.IsNull(cakeContext.GetXcRuntimePath(Platform.X64));
            Assert.IsNull(cakeContext.GetXcRuntimePath(Platform.X86));
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void TestGetXcBridgePath(Platform platform)
        {
            var cakeContext = Substitute.For<ICakeContext>();
            Assert.DoesNotThrow(() => cakeContext.GetXcBridgePath(platform));
        }

        [Test]
        public void TestSetXcBridgePath()
        {
            var path = Path.Combine(ToolsPath, PathFinder.GetXcBridgeProgram(Platform.X64));
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.SetXcBridgePath(path);

            Assert.AreEqual(path, cakeContext.GetXcBridgePath(Platform.X64));
            Assert.AreEqual(path, cakeContext.GetXcBridgePath(Platform.X86));
        }

        [Test]
        public void TestSetXcBridgePathWithNotExistingPath()
        {
            var notExistingPath = Path.Combine(ToolsPath, Path.GetRandomFileName());
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.SetXcBridgePath(notExistingPath);

            Assert.IsNull(cakeContext.GetXcBridgePath(Platform.X64));
            Assert.IsNull(cakeContext.GetXcBridgePath(Platform.X86));
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void TestGetXcSpyPath(Platform platform)
        {
            var cakeContext = Substitute.For<ICakeContext>();
            Assert.DoesNotThrow(() => cakeContext.GetXcSpyPath(platform));
        }

        [Test]
        public void TestSetXcSpyPath()
        {
            var path = Path.Combine(ToolsPath, PathFinder.GetXcSpyProgram(Platform.X64));
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.SetXcSpyPath(path);

            Assert.AreEqual(path, cakeContext.GetXcSpyPath(Platform.X64));
            Assert.AreEqual(path, cakeContext.GetXcSpyPath(Platform.X86));
        }

        [Test]
        public void TestSetXcSpyPathWithNotExistingPath()
        {
            var notExistingPath = Path.Combine(ToolsPath, Path.GetRandomFileName());
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.SetXcSpyPath(notExistingPath);

            Assert.IsNull(cakeContext.GetXcSpyPath(Platform.X64));
            Assert.IsNull(cakeContext.GetXcSpyPath(Platform.X86));
        }
    }
}