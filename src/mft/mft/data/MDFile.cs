using System;

namespace mft
{
    public class MDFile {
        public int NumberOfLines { get; }
        public DateTime CreatedAt { get; }
        public DateTime LastChangedAt { get; }

        public string Filename => System.IO.Path.GetFileNameWithoutExtension(_filepath);
        public string Path => System.IO.Path.GetDirectoryName(_filepath);
        
        
        private readonly string _filepath;

        public MDFile(string filepath, int numberOfLines, DateTime createdAt, DateTime lastChangedAt) {
            NumberOfLines = numberOfLines;
            CreatedAt = createdAt;
            LastChangedAt = lastChangedAt;
            _filepath = filepath;
        }
    }
}