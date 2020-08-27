using System;
using System.Collections;

namespace mft
{
    class Program
    {
        static void Main(string[] args) {
            var fc = new MDFileCollector();
            
            var files = fc.Collect(args[0]);
            var weeks = Grouping.Group(files);
            
            var disp = new Display(weeks);
            disp.Show();
        }
    }
}