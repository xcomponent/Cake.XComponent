using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.XComponent
{
    /// <summary>
    /// Cake Extension for XComponent Runtime
    /// </summary>
    [CakeAliasCategory("XCRuntime")]
    public static class XcRuntimeAliases
    {
        /// <summary>
        /// This method creates a .ps1 script to easily launch a XComponent project using the version of XComponent Runtime found in the tools folder.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="xcrPath">The path of the XComponent archive to be launched with XComponent Runtime</param>
        /// <param name="otherArguments">Other arguments to be passed to XComponent Runtime</param>
        /// <param name="outputDirectory">The output directory to write the script</param>
        /// <param name="scriptFileName">The name of the script file</param>
        /// <param name="platform">The platform used to launch the application</param>
        [CakeMethodAlias]
        public static void XcRuntimeCreatePowerShellLauncherScript(this ICakeContext context, string xcrPath, string otherArguments = "", string outputDirectory = "", string scriptFileName = "", Platform platform = Platform.X64)
        {
            new XcRuntime(context, platform).CreatePowerShellLauncherScript(xcrPath, outputDirectory, scriptFileName, otherArguments);
        }
    }
}