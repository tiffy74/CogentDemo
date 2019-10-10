using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogentDemo.Code.Extensions
{
    public static class DateExtensions
    {
        public static string ToDisplayDate(this DateTime value)
        {
            if (value != DateTime.MinValue)
            {
                return value.ToString("ddd, MMM dd, yyyy");
            }
            return string.Empty;
        }
    }
}
