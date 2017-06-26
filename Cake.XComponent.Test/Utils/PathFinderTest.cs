using System.IO;
using Cake.Core.Diagnostics;
using Cake.XComponent.Exception;
using Cake.XComponent.Utils;
using NSubstitute;
using NUnit.Framework;

namespace Cake.XComponent.Test.Utils
{
    [TestFixture]
    public class PathFinderTest : XComponentTestBase
    {
        private string _xcBuildDirectory;

        [SetUp]
        public void SetUp()
        {
            var toolsDirectory = Path.Combine(PathFinder.WorkingDirectory, "tools");
            Directory.CreateDirectory(toolsDirectory);
            _xcBuildDirectory = Path.Combine(toolsDirectory, Path.GetRandomFileName());
            Directory.CreateDirectory(_xcBuildDirectory);
        }

        [TearDown]
        public void TearDown()
        {
            Directory.Delete(_xcBuildDirectory, true);
        }

        [Test]
        [ExpectedException(typeof(XComponentException))]
        public void IfXcBuildIsNotPresent_FindXcBuild_ShouldThrowAnException()
        {
            var logSubtitute = Substitute.For<ICakeLog>();
            var pathFinder = new PathFinder(logSubtitute);
            pathFinder.FindXcBuild();
        }
        
        [Test]
        public void IfXcBuildIsPresent_FindXcBuild_ShouldReturnTheProperVersion()
        {
            WriteResource("Cake.XComponent.Test.Input.XComponent.XcBuild.exe", _xcBuildDirectory, PathFinder.XcBuildExe);
            var logSubtitute = Substitute.For<ICakeLog>();
            var pathFinder = new PathFinder(logSubtitute);
            Assert.AreEqual(Path.Combine(_xcBuildDirectory, PathFinder.XcBuildExe), pathFinder.FindXcBuild());
        }
    }
}