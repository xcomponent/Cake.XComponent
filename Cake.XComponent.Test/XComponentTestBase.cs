using System.IO;

namespace Cake.XComponent.Test
{
    public abstract class XComponentTestBase
    {
        protected static string ToolsPath { get; set; }

        public void CreateFile(string outputDir, string file)
        {
            var outputFile = Path.Combine(outputDir, file);
            File.Create(outputFile);
        }
    }
}