using System.Collections.Generic;
using System.IO;
using System.Linq;
using mft.adapters;

namespace mft
{
    public class MDFileCollector
    {
        public IEnumerable<MDFile> Collect(string path)
            => Directory.GetFiles(path, "*.md", SearchOption.AllDirectories)
                        .Select(Load);


        private MDFile Load(string filepath) {
            var lines = File.ReadAllLines(filepath);
            
            return new MDFile(filepath,
                lines.Excerpt(),
                lines.Length,
                File.GetCreationTime(filepath),
                File.GetLastWriteTime(filepath));
        }
    }
}