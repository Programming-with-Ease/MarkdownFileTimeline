using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace mft
{
    public class Grouping
    {
        public static IEnumerable<Week> Group(IEnumerable<MDFile> files)
        {
            files = files.OrderByDescending(x => x.CreatedAt);

            var days = files.GroupBy(x => x.CreatedAt.Date)
                                                           .OrderByDescending(x => x.Key);
            
            var weeks = days.GroupBy(x => ISOWeek.GetWeekOfYear(x.Key));

            return weeks.Select(MapWeek);

            Week MapWeek(IGrouping<int, IGrouping<DateTime, MDFile>> weekGroup)
                => new Week(weekGroup.Key,
                    weekGroup.Select(MapDay));

            Day MapDay(IGrouping<DateTime, MDFile> dayGroup)
                => new Day(dayGroup.Key, dayGroup);
        }
    }
}