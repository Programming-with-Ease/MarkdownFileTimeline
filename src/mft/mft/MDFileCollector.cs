using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace mft
{
    public class MDFileCollector
    {
        public IEnumerable<MDFile> Collect(string path)
            => Directory.GetFiles(path, "*.md", SearchOption.AllDirectories)
                .Select(Load);


        private MDFile Load(string filepath)
            => new MDFile(filepath, 
                File.ReadAllLines(filepath).Length, 
                File.GetCreationTime(filepath),
                File.GetLastWriteTime(filepath));
    }
}