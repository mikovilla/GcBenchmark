namespace GCB.Utility.Extensions
{
    public static class NumericExtension
    {
        public static decimal NsToMs(this long nanoseconds)
        {
            return nanoseconds / 1_000_000;
        }

        public static string MsToReadableTime(this long milliseconds)
        {
            long rawSeconds = milliseconds / 1_000;
            long seconds = rawSeconds % 60;
            long rawMinutes = (rawSeconds - seconds) / 60;
            long minutes = rawMinutes % 60;
            long rawHours = (rawMinutes - minutes) / 60;

            return $"{AppendZeroToOneDigitNumber(rawHours)}HH:{AppendZeroToOneDigitNumber(minutes)}mm:{AppendZeroToOneDigitNumber(seconds)}SS";
        }

        private static string AppendZeroToOneDigitNumber(object number)
        {
            var rawNumber = number?.ToString() ?? string.Empty;
            return rawNumber.Length == 1 ? $"0{rawNumber}" : rawNumber;
        }
    }
}
