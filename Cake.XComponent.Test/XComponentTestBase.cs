using System.IO;

namespace Cake.XComponent.Test
{
    public abstract class XComponentTestBase
    {
        public void WriteResource(string resource, string outputDir, string file)
        {
            using (var stream = typeof(XComponentTestBase).Assembly.GetManifestResourceStream(resource))
            {
                if (stream == null) return;

                using (var fileStream = new FileStream(Path.Combine(outputDir, file), FileMode.Create))
                {
                    for (var i = 0; i < stream.Length; i++)
                    {
                        fileStream.WriteByte((byte) stream.ReadByte());
                    }
                    fileStream.Close();
                }
            }
        }
    }
}