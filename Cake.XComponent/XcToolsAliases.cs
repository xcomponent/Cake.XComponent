using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.XComponent
{
    /// <summary>
    /// Cake Extension for XCTools
    /// </summary>
    [CakeAliasCategory("Cake Extension for XCTools")]
    public static class XcToolsAliases
    {
        private static ICakeContext _context;
        private static XcTools _tools;
        private static XcTools Tools => _tools ?? (_tools = new XcTools(_context));
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="arguments"></param>
        /// <exception cref="Exception"></exception>
        [CakeMethodAlias]
        public static void XcTools(this ICakeContext context, string arguments)
        {
            _context = context;
            Tools.ExecuteCommand(arguments);
        }
    }
}
