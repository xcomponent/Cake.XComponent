using System.IO;
using Cake.Core;
using Cake.XComponent.Utils;

namespace Cake.XComponent
{
    internal sealed class XcStudio
    {
        private const string DefaultRunStudioBatFile = "Run.Studio.bat";
        private const string DefaultRunStudioPowerShellFile = "Run.Studio.ps1";
        private readonly string _xcStudioPath;
        private readonly string _xcStudioProgram;

        internal XcStudio(ICakeContext context, Platform platform)
        {
            _xcStudioPath = new PathFinder(context.Log).FindXcStudio(platform);
            _xcStudioProgram = PathFinder.GetXcStudioProgram(platform);
        }

        internal void CreateBatLauncherScript(string projectPath, string outputDirectory, string scriptFileName)
        {
            scriptFileName = string.IsNullOrEmpty(scriptFileName) ? DefaultRunStudioBatFile : scriptFileName;
            outputDirectory = string.IsNullOrEmpty(outputDirectory) ? Directory.GetCurrentDirectory() : outputDirectory;

            var filePath = Path.Combine(outputDirectory, scriptFileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            
            File.AppendAllLines(filePath,
                new[] {$"cd \"{Path.GetDirectoryName(_xcStudioPath)}\"", $"start {_xcStudioProgram} \"{Path.GetFullPath(projectPath)}\""});
        }

        internal void CreatePowerShellLauncherScript(string projectPath, string outputDirectory, string scriptFileName)
        {
            scriptFileName = string.IsNullOrEmpty(scriptFileName) ? DefaultRunStudioPowerShellFile : scriptFileName;
            outputDirectory = string.IsNullOrEmpty(outputDirectory) ? Directory.GetCurrentDirectory() : outputDirectory;

            var filePath = Path.Combine(outputDirectory, scriptFileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            
            File.AppendAllLines(filePath,
                new[] {$"Push-Location \"{Path.GetDirectoryName(_xcStudioPath)}\"",
                $"Start-Process {_xcStudioProgram} \"{Path.GetFullPath(projectPath)}\"",
                "Pop-Location"});
        }
    }
}