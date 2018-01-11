using System.IO;
using Cake.Core;
using Cake.XComponent.Utils;

namespace Cake.XComponent
{
    internal sealed class XcStudio
    {
        private const string StudioBatFile = "XComponent.Studio.bat";
        private readonly string _xcStudioPath;
        private readonly string _xcStudioProgram;

        internal XcStudio(ICakeContext context, Platform platform)
        {
            _xcStudioPath = new PathFinder(context.Log).FindXcStudio(platform);
            _xcStudioProgram = PathFinder.GetXcStudioProgram(platform);
        }

        internal void CreateLauncher(string projectPath, string output)
        {
            var outputDirectory = string.IsNullOrEmpty(output) ? Directory.GetCurrentDirectory() : output;

            var filePath = Path.Combine(outputDirectory, StudioBatFile);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            
            File.AppendAllLines(filePath,
                new[] {$"cd \"{Path.GetDirectoryName(_xcStudioPath)}\"", $"start {_xcStudioProgram} \"{Path.GetFullPath(projectPath)}\""});
        }
    }
}