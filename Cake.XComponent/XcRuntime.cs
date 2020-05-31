using System.IO;
using Cake.Core;
using Cake.XComponent.Utils;

namespace Cake.XComponent
{
    internal sealed class XcRuntime
    {
        private const string DefaultRunStudioPowerShellFile = "Run.Runtime.ps1";
        private readonly string _xcRuntimePath;
        private readonly string _xcRuntimeProgram;

        internal XcRuntime(ICakeContext context, Platform platform)
        {
            _xcRuntimePath = new PathFinder(context.Log).FindXcRuntime(platform);
            _xcRuntimeProgram = PathFinder.GetXcRuntimeProgram(platform);
        }

        internal void CreatePowerShellLauncherScript(string xcrPath, string outputDirectory, string scriptFileName, string otherArguments)
        {
            scriptFileName = string.IsNullOrEmpty(scriptFileName) ? DefaultRunStudioPowerShellFile : scriptFileName;
            outputDirectory = string.IsNullOrEmpty(outputDirectory) ? Directory.GetCurrentDirectory() : outputDirectory;

            var filePath = Path.Combine(outputDirectory, scriptFileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            
            File.AppendAllLines(filePath,
                new[] {$"Push-Location \"{Path.GetDirectoryName(_xcRuntimePath)}\"",
                $"Start-Process {_xcRuntimeProgram} \"{Path.GetFullPath(xcrPath)}\" {otherArguments}",
                "Pop-Location"});
        }
    }
}