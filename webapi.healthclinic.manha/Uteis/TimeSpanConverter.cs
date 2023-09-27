namespace webapi.healthclinic.manha.Uteis
{   
    public static class TimeSpanConverter
    {
        public static string TimeSpanToString(TimeSpan timeSpan)
        {
            return timeSpan.ToString("hh\\:mm");
        }

        public static TimeSpan StringToTimeSpan(string timeString)
        {
            TimeSpan timeSpan;
            if (TimeSpan.TryParseExact(timeString, "hh\\:mm", null, out timeSpan))
            {
                return timeSpan;
            }
            throw new ArgumentException("O formato da hora é inválido. Use o formato HH:mm.");
        }
    }

}
