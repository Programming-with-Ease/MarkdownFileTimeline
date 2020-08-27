using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace mft
{
    class Display
    {
        struct Page
        {
            public IEnumerable<string> Lines { get; }
            public Page(IEnumerable<string> lines) { Lines = lines; }
        }

        private Page[] _pages;
        
        
        public Display(IEnumerable<Week> weeks, int pageLen = 25) {
            var lines = Render(weeks);
            _pages = Paginate(lines, pageLen).ToArray();
        }
        
        
        private static IEnumerable<string> Render(IEnumerable<Week> weeks) {
            foreach (var week in weeks.OrderByDescending(x => x.Number)) {
                yield return $"Week {week.Number:00}--------+";
                foreach (var day in week.Days.OrderByDescending(x => x.Date)) {
                    var files = day.Files.OrderBy(x => x.Filename).ToArray();
                    for (var i = 0; i < files.Length; i++) {
                        var line = "";
                        if (i==0)
                            line = $"{day.Date.ToString("yyyy-MM-dd ddd", CultureInfo.InvariantCulture)} | ";
                        else
                            line = $"               | ";
                        yield return line + $"{files[i].Filename} ({files[i].NumberOfLines} line(s))";
                    }
                }
            }
        }

        private static IEnumerable<Page> Paginate(IEnumerable<string> lines, int pageLen) {
            List<string> pagelines = null;
            foreach (var l in lines) {
                if (pagelines == null) pagelines = new List<string>();
                pagelines.Add(l);

                if (pagelines.Count == pageLen) {
                    yield return new Page(pagelines);
                    pagelines = null;
                }
            }
            if (pagelines != null) yield return new Page(pagelines);
        }

        

        private int _currentPageIndex;
        
        public void Show() {
            _currentPageIndex = 0;
            while (true) {
                ShowPage();
                if (Menu()) return;
            }
        }

        
        private void ShowPage() {
            var pageLabel = $"{_currentPageIndex + 1}/{_pages.Length}";
            Console.WriteLine($"{"".PadLeft(Console.WindowWidth - pageLabel.Length - 1)}{pageLabel}");

            foreach (var l in _pages[_currentPageIndex].Lines)
                Console.WriteLine(l);
        }
        
        
        private bool Menu() {
            Console.Write("\n::: F(irst, L(ast, P(rev, N(ext, eX(it: ");
            var cmd = Console.ReadKey().KeyChar;
            
            switch (cmd) {
                case 'p':
                case 'P':
                case 'b':
                case 'B':
                    if (_currentPageIndex > 0) _currentPageIndex--;
                    break;
                case 'n':
                case 'N':
                    if (_currentPageIndex < _pages.Length - 1) _currentPageIndex++;
                    break;

                case 'f':
                case 'F':
                    _currentPageIndex = 0;
                    break;

                case 'l':
                case 'L':
                    _currentPageIndex = _pages.Length - 1;
                    break;

                case 'x':
                case 'X':
                    return true;
            }

            Console.Write("\n\n");
            return false;
        }
    }
}