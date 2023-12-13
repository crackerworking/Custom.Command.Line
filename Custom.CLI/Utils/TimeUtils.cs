namespace Custom.CLI.Utils
{
    internal static class TimeUtils
    {
        private static readonly DateTime _unixTime = new DateTime(1970, 1, 1, 0, 0, 0);

        public static long CurrentTimestamp()
        {
            return (long)(DateTime.UtcNow - _unixTime).TotalSeconds;
        }
    }
}