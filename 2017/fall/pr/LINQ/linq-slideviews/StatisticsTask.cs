using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_slideviews
{
    public class StatisticsTask
    {
        public static double GetMedianTimePerSlide(List<VisitRecord> visits, SlideType slideType)
        {
            if (visits == null)
                throw new ArgumentNullException(nameof(visits));

            if (visits.Count == 0)
                return 0;

            var usersActivity = visits
            .GroupBy(v => v.UserId)
            .OrderBy(group => group.Key)
            .ToArray();

            return usersActivity
            .SelectMany(userActivity => GetUserSessionDurations(userActivity, slideType))
            .Median();
        }

        private static IEnumerable<double> GetUserSessionDurations
            (
            IEnumerable<VisitRecord> activity, 
            SlideType slideType
            )
        {
            return activity
            .OrderBy(record => record.DateTime)
            .Bigrams()
            .Where(interval => interval.Item1.SlideType == slideType)
            .Select(interval => (interval.Item2.DateTime - interval.Item1.DateTime).TotalMinutes)
            .Where(time => time >= 1 && time <= 120);
        }
    }
}