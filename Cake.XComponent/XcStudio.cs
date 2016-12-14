using System.IO;
using Cake.Core;
using Cake.XComponent.Utils;

namespace Cake.XComponent
{
    internal sealed class XcStudio
    {
        private const string StudioBatFile = "XComponent.Studio.bat";
        private readonly ICakeContext _context;
        internal string XcStudioPath { get; }

        internal XcStudio(ICakeContext context)
        {
            _context = context;
            XcStudioPath = new PathFinder(context.Log).FindXcStudio();
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
                new[] {$"cd \"{XcStudioPath}\"", $"start XCStudio.exe \"{Path.GetFullPath(projectPath)}\""});
        }
    }
}