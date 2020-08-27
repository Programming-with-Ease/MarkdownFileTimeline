using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace mft
{
    class Display
    {
        public void Render(IEnumerable<Week> weeks) {
            foreach (var week in weeks.OrderByDescending(x => x.Number)) {
                Console.WriteLine($"Week {week.Number:00}--------+");
                foreach (var day in week.Days.OrderByDescending(x => x.Date)) {
                    var files = day.Files.OrderBy(x => x.Filename).ToArray();
                    for (var i = 0; i < files.Length; i++) {
                        if (i==0)
                            Console.Write($"{day.Date.ToString("yyyy-MM-dd ddd", CultureInfo.InvariantCulture)} | ");
                        else
                            Console.Write($"               | ");
                        Console.WriteLine($"{files[i].Filename} ({files[i].NumberOfLines} line(s))");
                    }
                }
            }
        }
    }
}