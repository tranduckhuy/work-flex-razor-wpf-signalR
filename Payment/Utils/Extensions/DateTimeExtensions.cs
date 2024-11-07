namespace WorkFlex.Payment.Utils.Extensions
{
    public static class DateTimeExtensions
    {
        public static long GetTimeStamp(this DateTime date)
        {
            return (long)(date.ToUniversalTime() - DateTime.UnixEpoch).TotalMilliseconds;
        }
    }
}
