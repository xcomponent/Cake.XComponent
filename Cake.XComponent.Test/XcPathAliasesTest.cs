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
        private string _applicationDirectory;

        [SetUp]
        public void SetUp()
        {
            var toolsDirectory = Path.Combine(PathFinder.WorkingDirectory, "tools");
            Directory.CreateDirectory(toolsDirectory);
            _applicationDirectory = Path.Combine(toolsDirectory, Path.GetRandomFileName());
            Directory.CreateDirectory(_applicationDirectory);
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(_applicationDirectory))
            {
                Directory.Delete(_applicationDirectory, true);
            }
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void TestGetXcStudioPath(Platform platform)
        {
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _applicationDirectory, PathFinder.GetXcStudioProgram(platform));
            var cakeContext = Substitute.For<ICakeContext>();
            Assert.DoesNotThrow(() => cakeContext.GetXcStudioPath(platform));
        }
        
        [Test]
        public void TestSetXcStudioPath()
        {
            var program = PathFinder.GetXcStudioProgram(Platform.X64);
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _applicationDirectory, program);
            var path = Path.Combine(_applicationDirectory, program);
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.SetXcStudioPath(path);

            Assert.AreEqual(path, cakeContext.GetXcStudioPath(Platform.X64));
            Assert.AreEqual(path, cakeContext.GetXcStudioPath(Platform.X86));
        }

        [Test]
        public void TestSetXcStudioPathWithNotExistingPath()
        {
            var notExistingPath = Path.Combine(_applicationDirectory, Path.GetRandomFileName());
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.SetXcStudioPath(notExistingPath);

            Assert.IsNull(cakeContext.GetXcStudioPath(Platform.X64));
            Assert.IsNull(cakeContext.GetXcStudioPath(Platform.X86));
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void TestGetXcBuildPath(Platform platform)
        {
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _applicationDirectory, PathFinder.GetXcBuildProgram(platform));
            var cakeContext = Substitute.For<ICakeContext>();
            Assert.DoesNotThrow(() => cakeContext.GetXcBuildPath(platform));
        }

        [Test]
        public void TestSetXcBuildPath()
        {
            var program = PathFinder.GetXcBuildProgram(Platform.X64);
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _applicationDirectory, program);
            var path = Path.Combine(_applicationDirectory, program);
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.SetXcBuildPath(path);

            Assert.AreEqual(path, cakeContext.GetXcBuildPath(Platform.X64));
            Assert.AreEqual(path, cakeContext.GetXcBuildPath(Platform.X86));
        }

        [Test]
        public void TestSetXcBuildPathWithNotExistingPath()
        {
            var notExistingPath = Path.Combine(_applicationDirectory, Path.GetRandomFileName());
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.SetXcBuildPath(notExistingPath);

            Assert.IsNull(cakeContext.GetXcBuildPath(Platform.X64));
            Assert.IsNull(cakeContext.GetXcBuildPath(Platform.X86));
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void TestGetXcRuntimePath(Platform platform)
        {
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _applicationDirectory, PathFinder.GetXcRuntimeProgram(platform));
            var cakeContext = Substitute.For<ICakeContext>();
            Assert.DoesNotThrow(() => cakeContext.GetXcRuntimePath(platform));
        }

        [Test]
        public void TestSetXcRuntimePath()
        {
            var program = PathFinder.GetXcRuntimeProgram(Platform.X64);
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _applicationDirectory, program);
            var path = Path.Combine(_applicationDirectory, program);
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.SetXcRuntimePath(path);

            Assert.AreEqual(path, cakeContext.GetXcRuntimePath(Platform.X64));
            Assert.AreEqual(path, cakeContext.GetXcRuntimePath(Platform.X86));
        }

        [Test]
        public void TestSetXcRuntimePathWithNotExistingPath()
        {
            var notExistingPath = Path.Combine(_applicationDirectory, Path.GetRandomFileName());
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.SetXcRuntimePath(notExistingPath);

            Assert.IsNull(cakeContext.GetXcRuntimePath(Platform.X64));
            Assert.IsNull(cakeContext.GetXcRuntimePath(Platform.X86));
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void TestGetXcBridgePath(Platform platform)
        {
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _applicationDirectory, PathFinder.GetXcBridgeProgram(platform));
            var cakeContext = Substitute.For<ICakeContext>();
            Assert.DoesNotThrow(() => cakeContext.GetXcBridgePath(platform));
        }

        [Test]
        public void TestSetXcBridgePath()
        {
            var program = PathFinder.GetXcBridgeProgram(Platform.X64);
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _applicationDirectory, program);
            var path = Path.Combine(_applicationDirectory, program);
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.SetXcBridgePath(path);

            Assert.AreEqual(path, cakeContext.GetXcBridgePath(Platform.X64));
            Assert.AreEqual(path, cakeContext.GetXcBridgePath(Platform.X86));
        }

        [Test]
        public void TestSetXcBridgePathWithNotExistingPath()
        {
            var notExistingPath = Path.Combine(_applicationDirectory, Path.GetRandomFileName());
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.SetXcBridgePath(notExistingPath);

            Assert.IsNull(cakeContext.GetXcBridgePath(Platform.X64));
            Assert.IsNull(cakeContext.GetXcBridgePath(Platform.X86));
        }

        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void TestGetXcSpyPath(Platform platform)
        {
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _applicationDirectory, PathFinder.GetXcSpyProgram(platform));
            var cakeContext = Substitute.For<ICakeContext>();
            Assert.DoesNotThrow(() => cakeContext.GetXcSpyPath(platform));
        }

        [Test]
        public void TestSetXcSpyPath()
        {
            var program = PathFinder.GetXcSpyProgram(Platform.X64);
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _applicationDirectory, program);
            var path = Path.Combine(_applicationDirectory, program);
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.SetXcSpyPath(path);

            Assert.AreEqual(path, cakeContext.GetXcSpyPath(Platform.X64));
            Assert.AreEqual(path, cakeContext.GetXcSpyPath(Platform.X86));
        }

        [Test]
        public void TestSetXcSpyPathWithNotExistingPath()
        {
            var notExistingPath = Path.Combine(_applicationDirectory, Path.GetRandomFileName());
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.SetXcSpyPath(notExistingPath);

            Assert.IsNull(cakeContext.GetXcSpyPath(Platform.X64));
            Assert.IsNull(cakeContext.GetXcSpyPath(Platform.X86));
        }
    }
}