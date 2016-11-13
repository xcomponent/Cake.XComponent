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
            Directory.Delete(_xcToolsDirectory, true);
        }

        [Test]
        [ExpectedException(typeof(XComponentException))]
        public void IfXcToolsIsNotPresent_FindXcTools_ShouldThrowAnException()
        {
            var logSubtitute = Substitute.For<ICakeLog>();
            var pathFinder = new PathFinder(logSubtitute);
            pathFinder.FindXcTools();
        }
        
        [Test]
        public void IfXcToolsIsPresent_FindXcTools_ShouldReturnTheProperVersion()
        {
            WriteResource("Cake.XComponent.Test.Input.XComponent.XCTools.exe", _xcToolsDirectory, PathFinder.XcToolsExe);
            var logSubtitute = Substitute.For<ICakeLog>();
            var pathFinder = new PathFinder(logSubtitute);
            Assert.AreEqual(Path.Combine(_xcToolsDirectory, PathFinder.XcToolsExe), pathFinder.FindXcTools());
        }
    }
}