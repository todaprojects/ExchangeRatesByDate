using System.Net.Http;

namespace ExchangeRatesByDate.utils
{
    public static class HttpClientHandler
    {
        private static HttpClient _httpClientInstance;
        
        public static HttpClient GetInstance()
        {
            return _httpClientInstance ??= new HttpClient();
        }
    }
}