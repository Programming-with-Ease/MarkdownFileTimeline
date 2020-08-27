using System.Collections.Generic;

namespace mft
{
    public class Week
    {
        public int Number { get; }
        public IEnumerable<Day> Days { get; }

        public Week(int number, IEnumerable<Day> days) {
            Number = number;
            Days = days;
        }
    }
}