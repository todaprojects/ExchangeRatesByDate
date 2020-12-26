using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExchangeRatesByDate.Utils
{
    public class XmlConverter
    {
        private static readonly HttpClient HttpClient = HttpClientHandler.GetInstance();
        private static string _resourceUri;
        private static readonly XmlSerializer XmlSerializer = XmlSerializerHandler.GetInstance();
        private static string _responseBody;

        public static async Task<T> ParseObjAsync<T>(string resourceUri)
        {
            _resourceUri = resourceUri;
            _responseBody = await GetHttpResponseAsync();

            var stringReader = StringReaderFactory.GetInstance(_responseBody);

            return (T) XmlSerializer.Deserialize(stringReader);
        }

        private static async Task<string> GetHttpResponseAsync()
        {
            var response = await HttpClient.GetAsync(_resourceUri);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw new Exception("connection error");
        }
    }
}