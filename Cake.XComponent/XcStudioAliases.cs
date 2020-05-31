using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.XComponent
{
    /// <summary>
    /// Cake Extension for XComponent Studio
    /// </summary>
    [CakeAliasCategory("XCStudio")]
    public static class XcStudioAliases
    {
        /// <summary>
        /// This method creates a .bat script to easily launch a XComponent project using the version of XComponent Studio found in the tools folder.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="projectPath">The path of the project to launch with XComponent Studio</param>
        /// <param name="outputDirectory">The output directory to write the script</param>
        /// <param name="scriptFileName">The name of the script file</param>
        /// <param name="platform">The platform used to launch the application</param>
        [CakeMethodAlias]
        public static void XcStudioCreateBatLauncherScript(this ICakeContext context, string projectPath, string outputDirectory = "", string scriptFileName = "", Platform platform = Platform.X64)
        {
            new XcStudio(context, platform).CreateBatLauncherScript(projectPath, outputDirectory, scriptFileName);
        }

        /// <summary>
        /// This method creates a .ps1 script to easily launch a XComponent project using the version of XComponent Studio found in the tools folder.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="projectPath">The path of the project to launch with XComponent Studio</param>
        /// <param name="outputDirectory">The output directory to write the script</param>
        /// <param name="scriptFileName">The name of the script file</param>
        /// <param name="platform">The platform used to launch the application</param>
        [CakeMethodAlias]
        public static void XcStudioCreatePowerShellLauncherScript(this ICakeContext context, string projectPath, string outputDirectory = "", string scriptFileName = "", Platform platform = Platform.X64)
        {
            new XcStudio(context, platform).CreatePowerShellLauncherScript(projectPath, outputDirectory, scriptFileName);
        }
    }
}