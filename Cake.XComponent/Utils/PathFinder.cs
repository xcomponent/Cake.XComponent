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
        internal const string XcToolsExe = "XComponent.XCTools.exe";
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
            var xcToolsPath = FindExe(XcStudioExe);
            _cakeLog.Write(Verbosity.Normal, LogLevel.Information,
                $@"XcStudio auto-detection: using XcStudio version '{FileVersionInfo.GetVersionInfo(xcToolsPath)
                    .ProductVersion}' from {xcToolsPath}");

            return xcToolsPath;
        }

        internal string FindXcTools()
        {
            var xcToolsPath = FindExe(XcToolsExe);
            _cakeLog.Write(Verbosity.Normal, LogLevel.Information,
                $@"XcTools auto-detection: using XcTools version '{FileVersionInfo.GetVersionInfo(xcToolsPath)
                    .ProductVersion}' from {xcToolsPath}");

            return xcToolsPath;
        }

        private static string FindExe(string exeToFind)
        {
            var toolsDirectory = Path.Combine(WorkingDirectory, CakeToolsDirectory);

            var xcToolsFiles = new DirectoryInfo(toolsDirectory).GetFiles(exeToFind, SearchOption.AllDirectories);
            if (xcToolsFiles.Any())
            {
                return xcToolsFiles.First().FullName;
            }

            throw new XComponentException($"Can't find {exeToFind}, please make sure {exeToFind} exists in the tools directory.");
        }
    }
}
