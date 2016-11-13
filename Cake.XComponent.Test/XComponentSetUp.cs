using System.IO;
using Cake.XComponent.Utils;
using NUnit.Framework;

namespace Cake.XComponent.Test
{
    [SetUpFixture]
    public class XComponentSetUp
    {
        [SetUp]
        public void SetUp()
        {
            PathFinder.WorkingDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        }

        [TearDown]
        public void TearDown()
        {
            Directory.Delete(PathFinder.WorkingDirectory, true);
        }
    }
}