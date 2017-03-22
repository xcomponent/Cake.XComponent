using System.Diagnostics;
using System.IO;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.XComponent.Exception;
using Cake.XComponent.Utils;

namespace Cake.XComponent
{
    internal sealed class XcTools
    {
        private readonly ICakeContext _context;
        private readonly string _xcToolsPath;

        internal static string XcToolsPath { get; set; }

        internal XcTools(ICakeContext context)
        {
            _context = context;
            _xcToolsPath = string.IsNullOrEmpty(XcToolsPath)
                ? new PathFinder(context.Log).FindXcTools()
                : XcToolsPath;
        }

        internal void Build(string project, string compiltationMode = "Debug", string environment = "Dev", string visualStudioVersion = "VS2015", string additionalArguments = "")
        {
            var arguments = $"--build --project={project} --compilationmode={compiltationMode} --env={environment}  --vs={visualStudioVersion} {additionalArguments}";
            ExecuteCommand(arguments);
        }

        internal void ExecuteCommand(string arguments)
        {
            if (!File.Exists(_xcToolsPath))
            {
                throw new XComponentException($"XcTools not found at {_xcToolsPath}");
            }

            var process = new Process
            {
                StartInfo =
                {
                    FileName = _xcToolsPath,
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
                throw new XComponentException("Error executing XcTools");
            }
        }
        
        private void OnOutputDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.Data))
            {
                _context.Log.Write(Verbosity.Normal, LogLevel.Information, args.Data);
            }
        }

        private void OnErrorDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.Data))
            {
                _context.Log.Write(Verbosity.Normal, LogLevel.Error, args.Data);
            }
        }
    }
}