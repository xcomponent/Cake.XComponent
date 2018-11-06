using System.Diagnostics;
using System.IO;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.XComponent.Exception;

namespace Cake.XComponent.Utils
{
    internal class ProcessCommandExecutor : ICommandExecutor
    {
        private readonly ICakeContext _context;
        private readonly string _xcBuildPath;

        public ProcessCommandExecutor(ICakeContext context,string xcBuildPath)
        {
            _context = context;
            _xcBuildPath = xcBuildPath;
        }

        public void ExecuteCommand(string arguments)
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
                catch
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
                catch
                {
                }
            }
        }
    }
}