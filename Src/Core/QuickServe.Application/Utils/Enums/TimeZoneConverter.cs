using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Utils.Enums
{
    public static class TimeZoneConverter
    {
        // Định nghĩa múi giờ mặc định, ví dụ "SE Asia Standard Time" (GMT+7)
        private static readonly TimeZoneInfo DefaultTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

        // Phương thức chuyển đổi thời gian từ UTC sang múi giờ của người dùng
        public static DateTime ConvertToUserTimeZone(DateTime utcDateTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, DefaultTimeZone);
        }
    }
}
