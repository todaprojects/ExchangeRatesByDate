namespace ExchangeRatesByDate.config
{
    public static class ResourceApi
    {
        private const string ExchangeApiUri =
            "http://lb.lt//webservices/ExchangeRates/ExchangeRates.asmx/getExchangeRatesByDate?Date=";

        public static string GetUri(string date)
        {
            return $"{ExchangeApiUri}{date}";
        }
    }
}