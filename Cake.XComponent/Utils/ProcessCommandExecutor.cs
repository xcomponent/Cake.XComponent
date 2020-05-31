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
        private readonly string _processPath;
        private readonly string _processName;

        public ProcessCommandExecutor(ICakeContext context,string programPath, string processName)
        {
            _context = context;
            _processPath = programPath;
            _processName = processName;
        }

        public void ExecuteCommand(string arguments)
        {
            if (!File.Exists(_processPath))
            {
                throw new XComponentException($"{_processName} not found at {_processPath}");
            }

            var process = new Process
            {
                StartInfo =
                {
                    WorkingDirectory = Path.GetDirectoryName(_processName),
                    FileName = _processPath,
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
                throw new XComponentException($"Error executing {_processName}");
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