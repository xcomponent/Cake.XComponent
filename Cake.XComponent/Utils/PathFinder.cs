using System.Diagnostics;
using System.IO;
using System.Linq;
using Cake.Core.Diagnostics;
using Cake.XComponent.Exception;

namespace Cake.XComponent.Utils
{
    internal class PathFinder
    {
        internal const string XcStudioExe = "XCStudio.exe";
        internal const string XcBuildExe = "xcbuild.exe";
        private const string CakeToolsDirectory = "tools";
        private readonly ICakeLog _cakeLog;
        private static string _workingDirectory;

        internal static string WorkingDirectory
        {
            get
            {
                if (string.IsNullOrEmpty(_workingDirectory))
                {
                    _workingDirectory = Directory.GetCurrentDirectory();
                }

                return _workingDirectory;
            }
            set { _workingDirectory = value; }
        }

        public PathFinder(ICakeLog cakeLog)
        {
            _cakeLog = cakeLog;
        }

        internal string FindXcStudio()
        {
            var xcStudioPath = FindExe(XcStudioExe);
            _cakeLog.Write(Verbosity.Normal, LogLevel.Information,
                $@"XcStudio auto-detection: using XcStudio version '{FileVersionInfo.GetVersionInfo(xcStudioPath)
                    .ProductVersion}' from {xcStudioPath}");

            return xcStudioPath;
        }

        internal string FindXcBuild()
        {
            var xcBuildPath = FindExe(XcBuildExe);
            _cakeLog.Write(Verbosity.Normal, LogLevel.Information,
                $@"XcBuild auto-detection: using XcBuild version '{FileVersionInfo.GetVersionInfo(xcBuildPath)
                    .ProductVersion}' from {xcBuildPath}");

            return xcBuildPath;
        }

        private static string FindExe(string exeToFind)
        {
            var toolsDirectory = Path.Combine(WorkingDirectory, CakeToolsDirectory);

            var exeFiles = new DirectoryInfo(toolsDirectory).GetFiles(exeToFind, SearchOption.AllDirectories);
            if (exeFiles.Any())
            {
                return exeFiles.First().FullName;
            }

            throw new XComponentException($"Can't find {exeToFind}, please make sure {exeToFind} exists in the tools directory.");
        }
    }
}
