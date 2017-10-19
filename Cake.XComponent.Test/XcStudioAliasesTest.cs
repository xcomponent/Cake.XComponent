using System.IO;
using Cake.Core;
using NSubstitute;
using NUnit.Framework;

namespace Cake.XComponent.Test
{
    [TestFixture]
    public class XcStudioAliasesTest : XComponentTestBase
    {
        [TearDown]
        public void TearDown()
        {
            XcStudio.XcStudioPath = null;
        }

        [TestCase("XCStudio.exe")]
        [TestCase(@"subFolder\XCStudio.exe")]
        [TestCase(@"..\subFolder\XCStudio.exe")]
        public void TestSetXcStudioPath(string path)
        {
            var cakeContext = Substitute.For<ICakeContext>();
            cakeContext.SetXcStudioPath(path);
            Assert.AreEqual(Path.GetFullPath(path), XcStudio.XcStudioPath);
        }
    }
}