using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.XComponent
{
    /// <summary>
    /// Cake Extension for XComponent Tools
    /// </summary>
    [CakeAliasCategory("Cake Extension for XcTools")]
    public static class XcToolsAliases
    {
        /// <summary>
        /// This method sets the path of XcTools that will be used by all other commands.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="xcToolsPath">The XcTools Path</param>
        [CakeMethodAlias]
        public static void SetXcToolsPath(this ICakeContext context, string xcToolsPath)
        {
            XcTools.XcToolsPath = xcToolsPath;
        }

        /// <summary>
        /// This method builds the XComponent project using the version of XComponent Tools found in the tools folder.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="project">The project to build</param>
        /// <param name="compiltationMode">The compilation mode (Debug/Release)</param>
        /// <param name="environment">The XComponent environment (Dev/Prod/...)</param>
        /// <param name="visualStudioVersion">The version of Visual Studio (VS2013/VS2015)</param>
        /// <param name="additionalArguments">Additional arguments to pass to XComponent Tools</param>
        [CakeMethodAlias]
        public static void XcToolsBuild(this ICakeContext context, string project, string compiltationMode = "Debug", string environment = "Dev", string visualStudioVersion = "VS2015", string additionalArguments = "")
        {
            new XcTools(context).Build(project, compiltationMode, environment, visualStudioVersion, additionalArguments);
        }

        /// <summary>
        /// This method exports runtimes for an XComponent project using the version of XComponent Tools found in the tools folder.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="project">The project to export runtimes for</param>
        /// <param name="output">The folder where to export runtimes</param>
        /// <param name="compiltationMode">The compilation mode (Debug/Release)</param>
        /// <param name="environment">The XComponent environment (Dev/Prod/...)</param>
        /// <param name="keepFolderContent">A flag to control whether to ovewrite folder content or not</param>
        /// <param name="additionalArguments">Additional arguments to pass to XComponent Tools</param>
        [CakeMethodAlias]
        public static void XcToolsExportRuntimes(this ICakeContext context, string project, string output, string compiltationMode = "Debug", string environment = "Dev", bool keepFolderContent = false, string additionalArguments = "")
        {
            new XcTools(context).ExportRuntimes(project, output, compiltationMode, environment, keepFolderContent, additionalArguments);
        }

        /// <summary>
        /// This method executes XcTools passing arguments
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="arguments">Arguments to pass to XComponent Tools</param>
        [CakeMethodAlias]
        public static void XcToolsExecuteCommand(this ICakeContext context, string arguments)
        {
            new XcTools(context).ExecuteCommand(arguments);
        }
    }
}
