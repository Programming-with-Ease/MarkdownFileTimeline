using System;
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


        private MDFile Load(string filepath)
        {
            string[] lines;
            string excerpt;

            try {
                lines = File.ReadAllLines(filepath);
                excerpt = lines.Excerpt();
            }
            catch (Exception) {
                lines = new string[0];
                excerpt = "*** POSSIBLY SYMLINK FILE. COULD NOT LOAD.";
            }
            
            return new MDFile(filepath,
                excerpt,
                lines.Length,
                File.GetCreationTime(filepath),
                File.GetLastWriteTime(filepath));
        }
    }
}