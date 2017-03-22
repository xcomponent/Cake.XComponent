using System.IO;
using Cake.Core;
using Cake.XComponent.Utils;

namespace Cake.XComponent
{
    internal sealed class XcStudio
    {
        private const string StudioBatFile = "XComponent.Studio.bat";
        private readonly ICakeContext _context;
        private readonly string _xcStudioPath;

        internal static string XcStudioPath { get; set; }

        internal XcStudio(ICakeContext context)
        {
            _context = context;
            _xcStudioPath = string.IsNullOrEmpty(XcStudioPath)
                ? new PathFinder(context.Log).FindXcStudio()
                : XcStudioPath;
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
                new[] {$"cd \"{Path.GetDirectoryName(_xcStudioPath)}\"", $"start {PathFinder.XcStudioExe} \"{Path.GetFullPath(projectPath)}\""});
        }
    }
}