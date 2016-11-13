using System.IO;
using Cake.Core;
using Cake.XComponent.Exception;
using Cake.XComponent.Utils;
using NSubstitute;
using NUnit.Framework;

namespace Cake.XComponent.Test
{
    [TestFixture]
    public class XcToolsTest : XComponentTestBase
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
        public void IfXcToolsIsProperlyExecuted_ExecuteCommand_ShouldReturn()
        {
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _xcToolsDirectory, PathFinder.XcToolsExe);
            var cakeContext = Substitute.For<ICakeContext>();
            var xcTools = new XcTools(cakeContext);
            xcTools.ExecuteCommand("-arf -fai");
        }

        [Test]
        [ExpectedException(typeof(XComponentException))]
        public void IfXcToolsIsNotPresent_ExecuteCommand_ShouldThrowAnException()
        {
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _xcToolsDirectory, PathFinder.XcToolsExe);
            var cakeContext = Substitute.For<ICakeContext>();
            var xcTools = new XcTools(cakeContext);
            Directory.Delete(_xcToolsDirectory, true);
            xcTools.ExecuteCommand("-arf -fai");
        }


        [Test]
        [ExpectedException(typeof(XComponentException))]
        public void IfXcToolsIsPresentButExecutionFails_ExecuteCommand_ShouldThrowAnException()
        {
            WriteResource("Cake.XComponent.Test.Input.Cake.XComponent.Test.FakeExe.exe", _xcToolsDirectory, PathFinder.XcToolsExe);
            var cakeContext = Substitute.For<ICakeContext>();
            var xcTools = new XcTools(cakeContext);
            xcTools.ExecuteCommand("-arf -fail");
        }
    }
}