using System;
using System.Collections.Generic;

namespace mft
{
    public class Day
    {
        public DateTime Date { get; }
        public IEnumerable<MDFile> Files { get; }

        public Day(DateTime date, IEnumerable<MDFile> files) {
            Date = date;
            Files = files;
        }
    }
}