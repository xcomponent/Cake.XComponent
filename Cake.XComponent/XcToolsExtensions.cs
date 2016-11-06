using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Cake.Core;
using Cake.Core.Annotations;
using LogLevel = Cake.Core.Diagnostics.LogLevel;
using Verbosity = Cake.Core.Diagnostics.Verbosity;

namespace Cake.XComponent
{
    /// <summary>
    /// Cake Extension for XCTools
    /// </summary>
    [CakeAliasCategory("Cake Extension for XCTools")]
    public static class XcToolsExtensions
    {
        private static readonly string _cakeToolsDirectory = "tools";
        private static readonly string _xcToolsExe = "XComponent.XCTools.exe";
        private static ICakeContext _context;
        private static string _xcToolsPath;

        public static string XcToolsPath
        {
            get
            {
                if (string.IsNullOrEmpty(_xcToolsPath))
                {
                    _xcToolsPath = FindXcTools();
                    _context.Log.Write(Verbosity.Normal, LogLevel.Information,
                        $@"XcTools auto-detection: using XcTools version '{FileVersionInfo.GetVersionInfo(
                                Path.Combine(XcToolsPath, _xcToolsExe))
                            .ProductVersion}' from {_xcToolsPath}");
                }

                return _xcToolsPath;
            }
            private set { _xcToolsPath = value; }
        }

        [CakeMethodAlias]
        public static void SetupXcTools(this ICakeContext context, string xcToolsPath)
        {
            XcToolsPath = xcToolsPath;
        }

        [CakeMethodAlias]
        public static void XcTools(this ICakeContext context, string arguments)
        {
            _context = context;
            var xcTools = Path.Combine(XcToolsPath, _xcToolsExe);

            if (!File.Exists(xcTools))
            {
                throw new Exception($"XCTools not found at {xcTools}");
            }

            var process = new Process
            {
                StartInfo =
                {
                    FileName = xcTools,
                    Arguments = arguments,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                }
            };
            process.OutputDataReceived += OnOutputDataReceived;
            process.ErrorDataReceived += OnErrorDataReceived;
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            
            if (process.ExitCode != 0)
            {
                throw new Exception("Error executing XCTools");
            }
        }

        private static string FindXcTools()
        {
            var toolsDirectory = Path.Combine(Directory.GetCurrentDirectory(), _cakeToolsDirectory);
            Console.WriteLine("######################################################################");
            Console.WriteLine("Cake Tools ::: "+ toolsDirectory);
            Console.WriteLine("######################################################################");

            var xcToolsFiles = new DirectoryInfo(toolsDirectory).GetFiles(_xcToolsExe, SearchOption.AllDirectories);
            if (xcToolsFiles.Any())
            {
                return xcToolsFiles.First().Directory.FullName;
            }
            else
            {
                throw new Exception($"Can't find XcTools, please make sure {_xcToolsExe} exists in the tools directory.");
            }
        }

        private static void OnOutputDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.Data))
            {
                _context.Log.Write(Verbosity.Normal, LogLevel.Information, args.Data);
            }
        }

        private static void OnErrorDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.Data))
            {
                _context.Log.Write(Verbosity.Normal, LogLevel.Error, args.Data);
            }
        }
    }
}
