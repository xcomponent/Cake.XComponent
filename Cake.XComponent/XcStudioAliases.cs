using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.XComponent
{
    /// <summary>
    /// Cake Extension for XComponent Studio
    /// </summary>
    [CakeAliasCategory("Cake Extension for XcStudio")]
    public static class XcStudioAliases
    {
        /// <summary>
        /// This method creates a .bat file to easily launch a XComponent project using the version of XComponent Studio found in the tools folder.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="projectPath">The path of the project to launch with XComponent Studio</param>
        /// <param name="output">The output path to write the launcher</param>
        [CakeMethodAlias]
        public static void XcStudioCreateLauncher(this ICakeContext context, string projectPath, string output = "")
        {
            new XcStudio(context).CreateLauncher(projectPath, output);
        }
    }
}