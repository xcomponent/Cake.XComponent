using Cake.Core;
using Cake.XComponent.Utils;
using System.Runtime.CompilerServices;
[assembly:InternalsVisibleTo("Cake.XComponent.Test")]

namespace Cake.XComponent
{
    internal sealed class XcBuild
    {
        private readonly ICommandExecutor _processCommandExecutor;
        
        internal static ICommandExecutor TestCommandExecutor { get; set; }

        internal XcBuild(ICakeContext context, Platform platform)
        {
            _processCommandExecutor = new ProcessCommandExecutor(context, new PathFinder(context.Log).FindXcBuild(platform));
        }

        internal void Build(string project, string compiltationMode = "Debug", string environment = "Dev", string visualStudioVersion = "VS2015", string additionalArguments = "")
        {
            var arguments = $"--build --project={project} --compilationmode={compiltationMode} --env={environment} --vs={visualStudioVersion} {additionalArguments}";
            GetCommandExecutor().ExecuteCommand(arguments);
        }

        internal void BuildComponent(string project, string component, string compiltationMode = "Debug", string environment = "Dev", string visualStudioVersion = "VS2015", string framework = "Framework452", string serializationtype = "Json", string logkeys = "", string additionalArguments = "")
        {
            var logKeysArgument = string.IsNullOrEmpty(logkeys) ? string.Empty : $"--logkeys={logkeys}";
            var arguments = $"--build --project={project} --component=\"{component}\" --compilationmode={compiltationMode} --env={environment} --vs={visualStudioVersion} --framework={framework} --serializationtype=\"{serializationtype}\" {logKeysArgument} {additionalArguments}";
            GetCommandExecutor().ExecuteCommand(arguments);
        }

        internal void ExportRuntimes(string project, string output, string compiltationMode = "Debug", string environment = "Dev", bool keepFolderContent = false, string additionalArguments = "")
        {
            var keepFolderContentArgument = keepFolderContent ? "--keepfoldercontent " : string.Empty;
            var arguments = $"--exportRuntimes --project={project} --compilationmode={compiltationMode} --env={environment} {keepFolderContentArgument}--output={output} {additionalArguments}";
            GetCommandExecutor().ExecuteCommand(arguments);
        }
        
        internal void ExportInterface(string project, string output, string compiltationMode = "Debug", string environment = "Dev", bool keepFolderContent = false, string additionalArguments = "")
        {
            var keepFolderContentArgument = keepFolderContent ? "--keepfoldercontent " : string.Empty;
            var arguments = $"--exportInterface --project={project} --compilationmode={compiltationMode} --env={environment} {keepFolderContentArgument}--output={output} {additionalArguments}";
            GetCommandExecutor().ExecuteCommand(arguments);
        }

        internal void ExecuteCommand(string arguments)
        {
            GetCommandExecutor().ExecuteCommand(arguments);
        }

        private ICommandExecutor GetCommandExecutor()
        {
            return TestCommandExecutor ?? _processCommandExecutor;
        }
    }
}
