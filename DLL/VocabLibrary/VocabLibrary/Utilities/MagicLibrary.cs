using System;

namespace MajinLib.Utilities
{
	public class MagicLibrary
	{
        public static long NowMilliseconds()
        {
            return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        }

        public static long AddDaysDuration(int days)
        {
            return new DateTimeOffset(DateTime.UtcNow).AddDays(days).ToUnixTimeMilliseconds();
        }

        public static long AddHoursDuration(int hours)
        {
            return new DateTimeOffset(DateTime.UtcNow).AddHours(hours).ToUnixTimeMilliseconds();
        }

        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Sub(int a, int b)
        {
            return a - b;
        }
    }
}


