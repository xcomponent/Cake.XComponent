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
        /// <param name="project"></param>
        /// <param name="compiltationMode">The compilation mode (Debug/Release)</param>
        /// <param name="environment">Th XComponent environment (Dev/Prod/...)</param>
        /// <param name="visualStudioVersion">The version of Visual Studio (VS2013/VS2015)</param>
        /// <param name="additionalArguments">Additional arguments pass to XComponent Tools</param>
        [CakeMethodAlias]
        public static void XcToolsBuild(this ICakeContext context, string project, string compiltationMode = "Debug", string environment = "Dev", string visualStudioVersion = "VS2015", string additionalArguments = "")
        {
            new XcTools(context).Build(project, compiltationMode, environment, visualStudioVersion, additionalArguments);
        }

        /// <summary>
        /// This method executes XcTools passing arguments
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="arguments"></param>
        [CakeMethodAlias]
        public static void XcToolsExecuteCommand(this ICakeContext context, string arguments)
        {
            new XcTools(context).ExecuteCommand(arguments);
        }
    }
}
