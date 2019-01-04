using System.IO;
using Cake.Core.Diagnostics;
using Cake.XComponent.Utils;
using NSubstitute;
using NUnit.Framework;

namespace Cake.XComponent.Test.Utils
{
    [TestFixture]
    public class PathFinderTest : XComponentTestBase
    {
        [TestCase(Platform.X64)]
        [TestCase(Platform.X86)]
        public void IfXcBuildIsPresent_FindXcBuild_ShouldReturnTheProperVersion(Platform platform)
        {
            var logSubtitute = Substitute.For<ICakeLog>();
            var pathFinder = new PathFinder(logSubtitute);
            Assert.AreEqual(Path.Combine(ToolsPath, PathFinder.GetXcBuildProgram(platform)), pathFinder.FindXcBuild(platform));
        }
    }
}