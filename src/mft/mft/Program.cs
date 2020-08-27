using System;
using System.Collections;

namespace mft
{
    class Program
    {
        static void Main(string[] args) {
            var fc = new MDFileCollector();
            var disp = new Display();
            
            var files = fc.Collect(args[0]);

            var weeks = Grouping.Group(files);
            
            disp.Render(weeks);
        }
    }
}