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
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="projectPath"></param>
        /// <param name="output"></param>
        [CakeMethodAlias]
        public static void XcStudioCreateLauncher(this ICakeContext context, string projectPath, string output = "")
        {
            new XcStudio(context).CreateLauncher(projectPath, output);
        }
    }
}