using System.IO;
using Cake.XComponent.Utils;
using NUnit.Framework;

namespace Cake.XComponent.Test
{
    [SetUpFixture]
    public class XComponentSetUp : XComponentTestBase
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            PathFinder.WorkingDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            var toolsDirectory = Path.Combine(PathFinder.WorkingDirectory, "tools");
            Directory.CreateDirectory(toolsDirectory);
            ToolsPath = toolsDirectory;
            CreateFile(ToolsPath, PathFinder.GetXcStudioProgram(Platform.X86));
            CreateFile(ToolsPath, PathFinder.GetXcStudioProgram(Platform.X64));
            CreateFile(ToolsPath, PathFinder.GetXcBuildProgram(Platform.X86));
            CreateFile(ToolsPath, PathFinder.GetXcBuildProgram(Platform.X64));
            CreateFile(ToolsPath, PathFinder.GetXcRuntimeProgram(Platform.X86));
            CreateFile(ToolsPath, PathFinder.GetXcRuntimeProgram(Platform.X64));
            CreateFile(ToolsPath, PathFinder.GetXcBridgeProgram(Platform.X86));
            CreateFile(ToolsPath, PathFinder.GetXcBridgeProgram(Platform.X64));
            CreateFile(ToolsPath, PathFinder.GetXcSpyProgram(Platform.X86));
            CreateFile(ToolsPath, PathFinder.GetXcSpyProgram(Platform.X64));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Directory.Delete(PathFinder.WorkingDirectory, true);
        }
    }
}