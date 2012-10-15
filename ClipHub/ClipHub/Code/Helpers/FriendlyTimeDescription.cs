using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace ClipHub.Code.Helpers
{

    [ValueConversion(typeof(DateTime), typeof(string))]
    public class FriendlyTimeDescription : IValueConverter
    {
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            var time = System.Convert.ToDateTime(value);
            return Describe(DateTime.Now - time);
        }

        static readonly string[] NAMES = {
                                         "day",
                                         "hour",
                                         "minute",
                                         "second"
                                     };

        public static string Describe(TimeSpan t)
        {
            int[] ints = {
                         t.Days,
                         t.Hours,
                         t.Minutes,
                         t.Seconds
                     };

            double[] doubles = {
                               t.TotalDays,
                               t.TotalHours,
                               t.TotalMinutes,
                               t.TotalSeconds
                           };

            var firstNonZero = ints
                .Select((value, index) => new { value, index })
                .FirstOrDefault(x => x.value != 0);
            if (firstNonZero == null)
            {
                return "now";
            }
            int i = firstNonZero.index;
            //string prefix = (i >= 3) ? "" : "about ";
            string prefix = (i >= 3) ? "" : "";
            int quantity = (int)Math.Round(doubles[i]);
            return prefix + Tense(quantity, NAMES[i]) + " ago";
        }

        public static string Tense(int quantity, string noun)
        {
            return quantity == 1
                ? "1 " + noun
                : string.Format("{0} {1}s", quantity, noun);
        }

        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
