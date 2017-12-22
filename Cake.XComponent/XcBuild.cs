using System.Diagnostics;
using System.IO;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.XComponent.Exception;
using Cake.XComponent.Utils;

namespace Cake.XComponent
{
    internal sealed class XcBuild
    {
        private readonly ICakeContext _context;
        private readonly string _xcBuildPath;

        internal static string XcBuildPath { get; set; }

        internal XcBuild(ICakeContext context)
        {
            _context = context;
            _xcBuildPath = string.IsNullOrEmpty(XcBuildPath)
                ? new PathFinder(context.Log).FindXcBuild()
                : XcBuildPath;
        }

        internal void Build(string project, string compiltationMode = "Debug", string environment = "Dev", string visualStudioVersion = "VS2015", string additionalArguments = "")
        {
            var arguments = $"--build --project={project} --compilationmode={compiltationMode} --env={environment} --vs={visualStudioVersion} {additionalArguments}";
            ExecuteCommand(arguments);
        }

        internal void BuildComponent(string project, string component, string compiltationMode = "Debug", string environment = "Dev", string visualStudioVersion = "VS2015", string framework = "Framework452", string serializationtype = "Json", string logkeys = "", string additionalArguments = "")
        {
            var logKeysArgument = string.IsNullOrEmpty(logkeys) ? string.Empty : $"--logkeys={logkeys}";
            var arguments = $"--build --project={project} --component=\"{component}\" --compilationmode={compiltationMode} --env={environment} --vs={visualStudioVersion} --framework={framework} --serializationtype=\"{serializationtype}\" {logKeysArgument} {additionalArguments}";
            ExecuteCommand(arguments);
        }

        internal void ExportRuntimes(string project, string output, string compiltationMode = "Debug", string environment = "Dev", bool keepFolderContent = false, string additionalArguments = "")
        {
            var keepFolderContentArgument = keepFolderContent ? "--keepfoldercontent " : string.Empty;
            var arguments = $"--exportRuntimes --project={project} --compilationmode={compiltationMode} --env={environment} {keepFolderContentArgument}--output={output} {additionalArguments}";
            ExecuteCommand(arguments);
        }

        internal void ExecuteCommand(string arguments)
        {
            if (!File.Exists(_xcBuildPath))
            {
                throw new XComponentException($"XcBuild not found at {_xcBuildPath}");
            }

            var process = new Process
            {
                StartInfo =
                {
                    FileName = _xcBuildPath,
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
                throw new XComponentException("Error executing XcBuild");
            }
        }
        
        private void OnOutputDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.Data))
            {
                try
                {
                     _context.Log.Write(Verbosity.Normal, LogLevel.Information, args.Data);
                }
                catch(Exception e)
                {
                }
            }
        }

        private void OnErrorDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.Data))
            {
                try
                {           
                    _context.Log.Write(Verbosity.Normal, LogLevel.Error, args.Data);
                }
                catch(Exception e)
                {
                }
            }
        }
    }
}
