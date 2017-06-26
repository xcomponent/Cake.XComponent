using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.XComponent
{
    /// <summary>
    /// Cake Extension for XComponent Build
    /// </summary>
    [CakeAliasCategory("Cake Extension for XcBuild")]
    public static class XcBuildAliases
    {
        /// <summary>
        /// This method sets the path of XcBuild that will be used by all other commands.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="xcBuildPath">The XcBuild Path</param>
        [CakeMethodAlias]
        public static void SetXcBuildPath(this ICakeContext context, string xcBuildPath)
        {
            XcBuild.XcBuildPath = xcBuildPath;
        }

        /// <summary>
        /// This method builds the XComponent project.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="project">The project to build</param>
        /// <param name="compiltationMode">The compilation mode (Debug/Release)</param>
        /// <param name="environment">The XComponent environment (Dev/Prod/...)</param>
        /// <param name="visualStudioVersion">The version of Visual Studio (VS2013/VS2015)</param>
        /// <param name="additionalArguments">Additional arguments to pass to XComponent Build</param>
        [CakeMethodAlias]
        public static void XcBuildBuild(this ICakeContext context, string project, string compiltationMode = "Debug", string environment = "Dev", string visualStudioVersion = "VS2015", string additionalArguments = "")
        {
            new XcBuild(context).Build(project, compiltationMode, environment, visualStudioVersion, additionalArguments);
        }

        /// <summary>
        /// This method exports runtimes for an XComponent project.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="project">The project to export runtimes for</param>
        /// <param name="output">The folder where to export runtimes</param>
        /// <param name="compiltationMode">The compilation mode (Debug/Release)</param>
        /// <param name="environment">The XComponent environment (Dev/Prod/...)</param>
        /// <param name="keepFolderContent">A flag to control whether to ovewrite folder content or not</param>
        /// <param name="additionalArguments">Additional arguments to pass to XComponent Build</param>
        [CakeMethodAlias]
        public static void XcBuildExportRuntimes(this ICakeContext context, string project, string output, string compiltationMode = "Debug", string environment = "Dev", bool keepFolderContent = false, string additionalArguments = "")
        {
            new XcBuild(context).ExportRuntimes(project, output, compiltationMode, environment, keepFolderContent, additionalArguments);
        }

        /// <summary>
        /// This method executes XcBuild passing arguments.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="arguments">Arguments to pass to XComponent Build</param>
        [CakeMethodAlias]
        public static void XcBuildExecuteCommand(this ICakeContext context, string arguments)
        {
            new XcBuild(context).ExecuteCommand(arguments);
        }
    }
}
