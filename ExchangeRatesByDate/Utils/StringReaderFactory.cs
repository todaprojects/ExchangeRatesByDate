using System.IO;

namespace ExchangeRatesByDate.Utils
{
    public static class StringReaderFactory
    {
        private static string _responseBody;

        public static StringReader GetInstance(string responseBody)
        {
            _responseBody = responseBody;
            return new StringReader(_responseBody);
        }
    }
}