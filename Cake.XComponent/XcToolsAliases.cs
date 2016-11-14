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
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="project"></param>
        /// <param name="compiltationMode"></param>
        /// <param name="environment"></param>
        /// <param name="visualStudioVersion"></param>
        /// <param name="additionalArguments"></param>
        [CakeMethodAlias]
        public static void XcToolsBuild(this ICakeContext context, string project, string compiltationMode = "Debug", string environment = "Dev", string visualStudioVersion = "VS2015", string additionalArguments = "")
        {
            new XcTools(context).Build(project, compiltationMode, environment, visualStudioVersion, additionalArguments);
        }
    }
}
