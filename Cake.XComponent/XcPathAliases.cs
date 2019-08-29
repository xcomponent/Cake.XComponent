using System.IO;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.XComponent.Exception;
using Cake.XComponent.Utils;

namespace Cake.XComponent
{
    /// <summary>
    /// Cake Extension for XComponent Applications
    /// </summary>
    [CakeAliasCategory("XCPaths")]
    public static class XcPathAliases
    {
        /// <summary>
        /// This method returns the path of XcStudio specified by the user or search it in the tools directory.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="platform">The platform used to launch the application</param>
        /// <exception cref="XComponentException">Thrown when XcStudio can't be found in tools directory.</exception>
        /// <returns>The XcStudio path</returns>
        [CakeMethodAlias]
        public static string GetXcStudioPath(this ICakeContext context, Platform platform = Platform.X64)
        {
            return new PathFinder(context.Log).FindXcStudio(platform);
        }

        /// <summary>
        /// This method returns the directory of XcStudio specified by the user or search it in the tools directory.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="platform">The platform used to launch the application</param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static string GetXcStudioDirectory(this ICakeContext context, Platform platform = Platform.X64)
        {
            return new PathFinder(context.Log).FindXcStudioDirectory(platform);
        }

        /// <summary>
        /// This method sets the path of XcStudio that will be used by all other commands.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="xcStudioPath">The XcStudio Path</param>
        [CakeMethodAlias]
        public static void SetXcStudioPath(this ICakeContext context, string xcStudioPath)
        {
            PathFinder.XcStudioPath = Path.GetFullPath(xcStudioPath);
        }

        /// <summary>
        /// This method returns the path of XcBuild specified by the user or search it in the tools directory.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="platform">The platform used to launch the application</param>
        /// <exception cref="XComponentException">Thrown when XcBuild can't be found in tools directory.</exception>
        /// <returns>The XcBuild path</returns>
        [CakeMethodAlias]
        public static string GetXcBuildPath(this ICakeContext context, Platform platform = Platform.X64)
        {
            return new PathFinder(context.Log).FindXcBuild(platform);
        }

        /// <summary>
        /// This method returns the directory of XcBuild specified by the user or search it in the tools directory.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="platform">The platform used to launch the application</param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static string GetXcBuildDirectory(this ICakeContext context, Platform platform = Platform.X64)
        {
            return new PathFinder(context.Log).FindXcBuildDirectory(platform);
        }

        /// <summary>
        /// This method sets the path of XcBuild that will be used by all other commands.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="xcBuildPath">The XcBuild Path</param>
        [CakeMethodAlias]
        public static void SetXcBuildPath(this ICakeContext context, string xcBuildPath)
        {
            PathFinder.XcBuildPath = Path.GetFullPath(xcBuildPath);
        }

        /// <summary>
        /// This method returns the path of XcRuntime specified by the user or search it in the tools directory.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="platform">The platform used to launch the application</param>
        /// <exception cref="XComponentException">Thrown when XcRuntime can't be found in tools directory.</exception>
        /// <returns>The XcRuntime path</returns>
        [CakeMethodAlias]
        public static string GetXcRuntimePath(this ICakeContext context, Platform platform = Platform.X64)
        {
            return new PathFinder(context.Log).FindXcRuntime(platform);
        }

        /// <summary>
        /// This method returns the directory of XcRuntime specified by the user or search it in the tools directory.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="platform">The platform used to launch the application</param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static string GetXcRuntimeDirectory(this ICakeContext context, Platform platform = Platform.X64)
        {
            return new PathFinder(context.Log).FindXcRuntimeDirectory(platform);
        }

        /// <summary>
        /// This method sets the path of XcRuntime that will be used by all other commands.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="xcRuntimePath">The XcRuntime Path</param>
        [CakeMethodAlias]
        public static void SetXcRuntimePath(this ICakeContext context, string xcRuntimePath)
        {
            PathFinder.XcRuntimePath = Path.GetFullPath(xcRuntimePath);
        }

        /// <summary>
        /// This method returns the path of XcBridge specified by the user or search it in the tools directory.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="platform">The platform used to launch the application</param>
        /// <exception cref="XComponentException">Thrown when XcBridge can't be found in tools directory.</exception>
        /// <returns>The XcBridge path</returns>
        [CakeMethodAlias]
        public static string GetXcBridgePath(this ICakeContext context, Platform platform = Platform.X64)
        {
            return new PathFinder(context.Log).FindXcBridge(platform);
        }

        /// <summary>
        /// This method returns the directory of XcBridge specified by the user or search it in the tools directory.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="platform">The platform used to launch the application</param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static string GetXcBridgeDirectory(this ICakeContext context, Platform platform = Platform.X64)
        {
            return new PathFinder(context.Log).FindXcBridgeDirectory(platform);
        }

        /// <summary>
        /// This method sets the path of XcBridge that will be used by all other commands.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="xcBridgePath">The XcBridge Path</param>
        [CakeMethodAlias]
        public static void SetXcBridgePath(this ICakeContext context, string xcBridgePath)
        {
            PathFinder.XcBridgePath = Path.GetFullPath(xcBridgePath);
        }

        /// <summary>
        /// This method returns the path of XcSpy specified by the user or search it in the tools directory.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="platform">The platform used to launch the application</param>
        /// <exception cref="XComponentException">Thrown when XcSpy can't be found in tools directory.</exception>
        /// <returns>The XcSpy path</returns>
        [CakeMethodAlias]
        public static string GetXcSpyPath(this ICakeContext context, Platform platform = Platform.X64)
        {
            return new PathFinder(context.Log).FindXcSpy(platform);
        }
        
        /// <summary>
        /// This method returns the directory of XcSpy specified by the user or search it in the tools directory.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="platform">The platform used to launch the application</param>
        /// <returns></returns>
        [CakeMethodAlias]
        public static string GetXcSpyDirectory(this ICakeContext context, Platform platform = Platform.X64)
        {
            return new PathFinder(context.Log).FindXcSpyDirectory(platform);
        }

        /// <summary>
        /// This method sets the path of XcSpy that will be used by all other commands.
        /// </summary>
        /// <param name="context">The Cake Context</param>
        /// <param name="xcSpyPath">The XcSpy Path</param>
        [CakeMethodAlias]
        public static void SetXcSpyPath(this ICakeContext context, string xcSpyPath)
        {
            PathFinder.XcSpyPath = Path.GetFullPath(xcSpyPath);
        }
    }
}