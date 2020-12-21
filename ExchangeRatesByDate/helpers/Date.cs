using System;

namespace ExchangeRatesByDate.helpers
{
    public static class Date
    {
        private static readonly DateTime MinDate = new DateTime(1993, 6, 25);
        private static readonly DateTime MaxDate = new DateTime(2015, 01, 01);
        private static string _previousDate;

        public static string Parse(string input)
        {
            try
            {
                var date = Convert.ToDateTime(input);
                if (!IsValid(date)) return null;
                _previousDate = $"{date.AddDays(-1):yyyy.MM.dd}";
                return $"{date:yyyy.MM.dd}";
            }
            catch (Exception)
            {
                throw new Exception("Not valid date format. You should enter e.g. 2010-12-30");
            }
        }

        public static string GetPrevious()
        {
            return _previousDate;
        }

        private static bool IsValid(DateTime date)
        {
            return date < MaxDate && date > MinDate;
        }
    }
}