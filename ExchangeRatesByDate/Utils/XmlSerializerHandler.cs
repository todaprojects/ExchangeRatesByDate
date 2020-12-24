using System.Xml.Serialization;
using ExchangeRatesByDate.Models;

namespace ExchangeRatesByDate.Utils
{
    public static class XmlSerializerHandler
    {
        private static XmlSerializer _xmlSerializerInstance;

        public static XmlSerializer GetInstance()
        {
            return _xmlSerializerInstance ??=
                new XmlSerializer(typeof(ExchangeRate));
        }
    }
}